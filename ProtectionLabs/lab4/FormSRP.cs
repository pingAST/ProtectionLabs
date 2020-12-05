using Eneter.Messaging.DataProcessing.Serializing;
using Eneter.Messaging.EndPoints.TypedMessages;
using Eneter.Messaging.MessagingSystems.Composites.AuthenticatedConnection;
using Eneter.Messaging.MessagingSystems.ConnectionProtocols;
using Eneter.Messaging.MessagingSystems.MessagingSystemBase;
using Eneter.Messaging.MessagingSystems.TcpMessagingSystem;
using Eneter.Messaging.Threading.Dispatching;
using Eneter.SecureRemotePassword;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ProtectionLabs
{
    public partial class FormSRP : Form
    {
        [Serializable]
        public class CalculateRequestMessage
        {
            public double Number1 { get; set; }
            public double Number2 { get; set; }
        }

        [Serializable]
        public class CalculateResponseMessage
        {
            public double Result { get; set; }
        }

        private IMultiTypedMessageSender mySender;
        private LoginRequestMessage myLoginRequest;
        private byte[] myPrivateKey_a;
        private ISerializer mySerializer;

        public FormSRP()
        {
            InitializeComponent();
            EnableUiControls(false);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseConnection();
        }

        private void OpenConnection()
        {
            IMessagingSystemFactory anUnderlyingMessaging = new TcpMessagingSystemFactory(new EasyProtocolFormatter());
            IMessagingSystemFactory aMessaging =
                new AuthenticatedMessagingFactory(anUnderlyingMessaging, OnGetLoginRequestMessage, OnGetProveMessage)
            {
                    // Получение ответных сообщений в основном потоке пользовательского интерфейса.
                    // Примечание: к элементам управления пользовательского интерфейса можно получить доступ только из потока пользовательского интерфейса.
                   
                    OutputChannelThreading = new WinFormsDispatching(this),

                    // Тайм-аут для аутентификации.
                    // Если значение -1, то оно бесконечно 
                    AuthenticationTimeout = TimeSpan.FromMilliseconds(30000)
            };

            IDuplexOutputChannel anOutputChannel = aMessaging.CreateDuplexOutputChannel("tcp://127.0.0.1:8033/");
            anOutputChannel.ConnectionClosed += OnConnectionClosed;

            IMultiTypedMessagesFactory aFactory = new MultiTypedMessagesFactory()
            {
                SerializerProvider = OnGetSerializer
            };
            mySender = aFactory.CreateMultiTypedMessageSender();

            // Регистрируем обработчики для определенных типов ответных сообщений
            mySender.RegisterResponseMessageReceiver<CalculateResponseMessage>(OnCalculateResponseMessage);
            mySender.RegisterResponseMessageReceiver<int>(OnFactorialResponseMessage);

            try
            {
                // Присоединить выходной канал и иметь возможность отправлять сообщения и получать ответы.
                mySender.AttachDuplexOutputChannel(anOutputChannel);
                EnableUiControls(true);
            }
            catch
            {
                MessageBox.Show("Неправильное имя пользователя или пароль.",
                    "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сервер закрывает соединение
        private void OnConnectionClosed(object sender, DuplexChannelEventArgs e)
        {
            CloseConnection();
        }

        private void CloseConnection()
        {
            // Отсоединяем выходной канал и освобождаем поток, слушающий ответы.
            if (mySender != null && mySender.IsDuplexOutputChannelAttached)
            {
                mySender.DetachDuplexOutputChannel();
            }
            EnableUiControls(false);
        }

        private void EnableUiControls(bool isLoggedIn)
        {
            LoginTextBox.Enabled = !isLoggedIn;
            PasswordTextBox.Enabled = !isLoggedIn;
            LoginBtn.Enabled = !isLoggedIn;

            LogoutBtn.Enabled = isLoggedIn;
            Number1TextBox.Enabled = isLoggedIn;
            Number2TextBox.Enabled = isLoggedIn;
            CalculateBtn.Enabled = isLoggedIn;
            ResultTextBox.Enabled = isLoggedIn;
            FactorialNumberTextBox.Enabled = isLoggedIn;
            CalculateFactorialBtn.Enabled = isLoggedIn;
            FactorialResultTextBox.Enabled = isLoggedIn;
        }

        // Вызывается Authentication Messaging для получения сообщения для входа
        private object OnGetLoginRequestMessage(string channelId, string responseReceiverId)
        {
            myPrivateKey_a = SRP.a();
            byte[] A = SRP.A(myPrivateKey_a);

            myLoginRequest = new LoginRequestMessage();
            myLoginRequest.UserName = LoginTextBox.Text;
            myLoginRequest.A = A;

            // Сериализатор для сериализации LoginRequestMessage
            ISerializer aSerializer = new BinarySerializer();
            object aSerializedLoginRequest = aSerializer.Serialize<LoginRequestMessage>(myLoginRequest);

            // Отправляем запрос на вход, чтобы начать переговоры о сеансовом ключе.
            return aSerializedLoginRequest;
        }

        // Вызывается AuthenticationMessaging для обработки полученного LoginResponseMessage из сервиса
        private object OnGetProveMessage(
            string channelId, string responseReceiverId, object loginResponseMessage)
        {
            // Десериализуем LoginResponseMessage
            ISerializer aSerializer = new BinarySerializer();
            LoginResponseMessage aLoginResponse =
                aSerializer.Deserialize<LoginResponseMessage>(loginResponseMessage);

            // Рассчитываем параметр скремблирования
            byte[] u = SRP.u(myLoginRequest.A, aLoginResponse.B);

            if (SRP.IsValid_B_u(aLoginResponse.B, u))
            {
                // Вычислить закрытый ключ пользователя.
                byte[] x = SRP.x(PasswordTextBox.Text, aLoginResponse.s);

                // Рассчитываем сеансовый ключ, который будет использоваться для шифрования.
                // Примечание: если все в порядке, то этот ключ будет таким же, как и на стороне сервиса.
                byte[] K = SRP.K_Client(aLoginResponse.B, x, u, myPrivateKey_a);
               
                // Создаем сериализатор для шифрования связи.
                Rfc2898DeriveBytes anRfc = new Rfc2898DeriveBytes(K, aLoginResponse.s, 1000);
                mySerializer = new AesSerializer(new BinarySerializer(true), anRfc, 256);

                // Создаем сообщение M1, чтобы доказать, что у клиента правильный сеансовый ключ.
                byte[] M1 = SRP.M1(myLoginRequest.A, aLoginResponse.B, K);
                return M1;
            }

            // Закрываем соединение с сервисом.
            return null;
        }

        // Он вызывается всякий раз, когда клиент отправляет или получает сообщение от службы.
        // Он вернет сериализатор, который сериализует / десериализует сообщения, используя
        // пароль для подключения.
        private ISerializer OnGetSerializer(string responseReceiverId)
        {
            return mySerializer;
        }


        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            /// Создать сообщение
            CalculateRequestMessage aRequest = new CalculateRequestMessage();
            aRequest.Number1 = double.Parse(Number1TextBox.Text);
            aRequest.Number2 = double.Parse(Number2TextBox.Text);

            // Отправить сообщение
            mySender.SendRequestMessage<CalculateRequestMessage>(aRequest);
        }

        private void CalculateFactorialBtn_Click(object sender, EventArgs e)
        {
            // Создать сообщение
            int aNumber = int.Parse(FactorialNumberTextBox.Text);

            // Отправить сообщение
            mySender.SendRequestMessage<int>(aNumber);
        }

        // Вызывается, когда сервис отправляет ответ на вычисление двух чисел.
        private void OnCalculateResponseMessage(object sender,
            TypedResponseReceivedEventArgs<CalculateResponseMessage> e)
        {
            ResultTextBox.Text = e.ResponseMessage.Result.ToString();
        }

        // Вызывается, когда сервис отправляет ответ для факториального расчета
        private void OnFactorialResponseMessage(object sender,
            TypedResponseReceivedEventArgs<int> e)
        {
            FactorialResultTextBox.Text = e.ResponseMessage.ToString();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            OpenConnection();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            CloseConnection();
        }
    }
}
