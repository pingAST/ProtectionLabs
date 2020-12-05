using Eneter.Messaging.DataProcessing.Serializing;
using Eneter.Messaging.Diagnostic;
using Eneter.Messaging.EndPoints.TypedMessages;
using Eneter.Messaging.MessagingSystems.Composites.AuthenticatedConnection;
using Eneter.Messaging.MessagingSystems.ConnectionProtocols;
using Eneter.Messaging.MessagingSystems.MessagingSystemBase;
using Eneter.Messaging.MessagingSystems.TcpMessagingSystem;
using Eneter.SecureRemotePassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Service
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

    class Program
    {
        private class User
        {
            public User (string userName, byte[] salt, byte[] verifier)
            {
                UserName = userName;
                Salt = salt;
                Verifier = verifier;
            }

            public string UserName { get; private set; }
            public byte[] Salt { get; private set; }
            public byte[] Verifier { get; private set; }
        }

        // Имитирует базу данных пользователей
        private static HashSet<User> myUsers = new HashSet<User>();


        // Контекст подключения для каждого подключенного клиента
        private class ConnectionContext
        {
            public ConnectionContext(string responseReceiverId, string userName)
            {
                ResponseReceiverId = responseReceiverId;
                UserName = userName;
            }

            // Идентифицирует сеанс подключения
            public string ResponseReceiverId { get; private set; }

            // Логин
            public string UserName { get; private set; }

            // Значения SRP, используемые в процессе аутентификации
            public byte[] K { get; set; }
            public byte[] A { get; set; }
            public byte[] B { get; set; }
            public byte[] s { get; set; }

            // Сериализатор для однократной сериализации / десериализации сообщений
            // аутентифицированное соединение установлено
            // Он использует сеансовый ключ (вычисленный во время аутентификации RSP) для шифрования / дешифрования сообщений 
            public ISerializer Serializer { get; set; }
        }

        // Список подключенных клиентов
        private static List<ConnectionContext> myConnections = new List<ConnectionContext>();



        static void Main(string[] args)
        {
            // Имитация базы данных пользователей
            CreateUser("Boris", "pwd123");
            CreateUser("Alex", "pwd456");
            CreateUser("Peter", "qwe123");
            CreateUser("Andrey", "qwe456");

            try
            {
                // Создаем многотипный получатель
                // Примечание: этот получатель может получать несколько типов сообщений
                IMultiTypedMessagesFactory aFactory = new MultiTypedMessagesFactory()
                {
                    // Примечание: это позволяет шифровать / дешифровать сообщения для каждого клиента индивидуально
                    // на основе рассчитанного сеансового ключа.
                    SerializerProvider = OnGetSerializer
                };
                IMultiTypedMessageReceiver aReceiver = aFactory.CreateMultiTypedMessageReceiver();

                // Регистрируем типы сообщений, которые может обрабатывать получатель
                aReceiver.RegisterRequestMessageReceiver<CalculateRequestMessage>(OnCalculateRequest);
                aReceiver.RegisterRequestMessageReceiver<int>(OnFactorialRequest);

                // Используем TCP для связи
                IMessagingSystemFactory anUnderlyingMessaging =
                    new TcpMessagingSystemFactory(new EasyProtocolFormatter());

                // Использовать аутентифицированную связь
                IMessagingSystemFactory aMessaging =
                    new AuthenticatedMessagingFactory(anUnderlyingMessaging,
                    OnGetLoginResponseMessage, OnAuthenticate, OnAuthenticationCancelled);

                // Создаем входной канал и присоединяем его к приемнику, чтобы начать прослушивание
                IDuplexInputChannel anInputChannel = aMessaging.CreateDuplexInputChannel("tcp://127.0.0.1:8033/");
                anInputChannel.ResponseReceiverConnected += OnClientConnected;
                anInputChannel.ResponseReceiverDisconnected += OnClientDisconnected;
                aReceiver.AttachDuplexInputChannel(anInputChannel);

                Console.WriteLine("Сервис запущен. Для остановки нажмите ENTER.");
                Console.ReadLine();

                // Отсоединить входной канал, чтобы остановить прослушивающий поток
                aReceiver.DetachDuplexInputChannel();
            }
            catch (Exception err)
            {
                EneterTrace.Error("Сбой сервиса.", err);
            }
        }



        // Он вызывается AuthenticationMessaging для обработки запроса на вход от клиента.
        private static object OnGetLoginResponseMessage(string channelId,
            string responseReceiverId, object loginRequestMessage)
        {
            // Десериализуем запрос на вход
            ISerializer aSerializer = new BinarySerializer();
            LoginRequestMessage aLoginRequest = aSerializer.Deserialize<LoginRequestMessage>(loginRequestMessage);

            // Пытаемся найти пользователя в базе данных
            User aUser = GetUser(aLoginRequest.UserName);
            if (aUser != null &&
                SRP.IsValid_A(aLoginRequest.A))
            {
                
                // Генерация случайного временного значения 
                byte[] b = SRP.b();

               //Рассчитать временное значение сервиса
                byte[] B = SRP.B(b, aUser.Verifier);

                // Вычислить случайное скремблированое значение 
                byte[] u = SRP.u(aLoginRequest.A, B);

                // Рассчитываем ключ сеанса
                byte[] K = SRP.K_Service(aLoginRequest.A, aUser.Verifier, u, b);

                // Готовим ответное сообщение для клиента
                // Примечание: клиент должен вычислить сеансовый ключ
                // и отправляем обратно сообщение, подтверждающее, что он смог вычислить тот же ключ сеанса.
                LoginResponseMessage aLoginResponse = new LoginResponseMessage();
                aLoginResponse.s = aUser.Salt; // пользователь salt
                aLoginResponse.B = B;       
                object aLoginResponseMessage = aSerializer.Serialize<LoginResponseMessage>(aLoginResponse);

                // Сохраняем контекст подключения
                ConnectionContext aConnection = new ConnectionContext(responseReceiverId, aUser.UserName);
                aConnection.A = aLoginRequest.A;
                aConnection.B = B;
                aConnection.K = K;
                aConnection.s = aUser.Salt;
                lock (myConnections)
                {
                    myConnections.Add(aConnection);
                }

                // Отправляем ответ клиенту
                return aLoginResponseMessage;
            }

            // Клиент будет отключен
            return null;
        }

        // Он вызывается AuthenticationMessaging для обработки сообщения от клиента
        // который должен подтвердить, что пользователь ввел правильный пароль, и поэтому клиенту была
        // возможность вычислить тот же ключ сеанса, что и сервис.
        private static bool OnAuthenticate(string channelId, string responseReceiverId,
            object login, object handshakeMessage, object M1)
        {
            ConnectionContext aConnection;
            lock (myConnections)
            {
                aConnection = myConnections.FirstOrDefault(
                    x => x.ResponseReceiverId == responseReceiverId);
            }
            if (aConnection != null)
            {
                // Подтверждение сообщения от клиента
                byte[] aClientM1 = (byte[])M1;

                // Сервис также вычисляет сообщение подтверждения
                byte[] aServiceM1 = SRP.M1(aConnection.A, aConnection.B, aConnection.K);

                // Если оба сообщения - equql, значит, клиент подтвердил свою личность
                // и соединение может быть установлено
                if (aServiceM1.SequenceEqual(aClientM1))
                {
                    // Создаем сериализатор.
                    Rfc2898DeriveBytes anRfc = new Rfc2898DeriveBytes(aConnection.K, aConnection.s, 1000);
                    ISerializer aSerializer = new AesSerializer(new BinarySerializer(true), anRfc, 256);

                    // Сохраняем сериализатор, который будет шифровать вычисленный ключ.
                    aConnection.Serializer = aSerializer;

                    // Очистить свойства, которые больше не нужны.
                    aConnection.A = null;
                    aConnection.B = null;
                    aConnection.K = null;
                    aConnection.s = null;
                    
                    return true;
                }
            }

            lock (myConnections)
            {
                myConnections.RemoveAll(x => x.ResponseReceiverId == responseReceiverId);
            }

            return false;
        }

        // Удаляем контекст подключения, если клиент отключается во время аутентификации.
        private static void OnAuthenticationCancelled(
            string channelId, string responseReceiverId, object loginMessage)
        {
            lock (myConnections)
            {
                myConnections.RemoveAll(x => x.ResponseReceiverId == responseReceiverId);
            }
        }

        private static void OnClientConnected(object sender, ResponseReceiverEventArgs e)
        {
            string aUserName = "";
            lock (myConnections)
            {
                ConnectionContext aConnection = myConnections.FirstOrDefault(
                    x => x.ResponseReceiverId == e.ResponseReceiverId);
                if (aConnection != null)
                {
                    aUserName = aConnection.UserName;
                }
            }

            Console.WriteLine(aUserName + " авторизован.");
        }

        // Удаляем контекст подключения, если клиент отключается после подключения
        // был установлен после успешной аутентификации
        private static void OnClientDisconnected(object sender, ResponseReceiverEventArgs e)
        {
            string aUserName = "";
            lock (myConnections)
            {
                ConnectionContext aConnection = myConnections.FirstOrDefault(
                    x => x.ResponseReceiverId == e.ResponseReceiverId);
                aUserName = aConnection.UserName;
                myConnections.Remove(aConnection);
            }

            Console.WriteLine(aUserName + " вышел из системы.");
        }

        // Он вызывается MultiTypedReceiver всякий раз, когда он отправляет или получает сообщение от подключенного клиента.
        // Возвращает сериализатор для конкретного соединения (которое использует согласованный сеансовый ключ).
        private static ISerializer OnGetSerializer(string responseReceiverId)
        {
            ConnectionContext aUserContext;
            lock (myConnections)
            {
                aUserContext = myConnections.FirstOrDefault(x => x.ResponseReceiverId == responseReceiverId);
            }
            if (aUserContext != null)
            {
                return aUserContext.Serializer;
            }

            throw new InvalidOperationException("Не удалось получить сериализатор для данного подключения.");
        }


        // Он обрабатывает сообщение запроса от клиента для вычисления двух чисел.
        private static void OnCalculateRequest(
            Object eventSender, TypedRequestReceivedEventArgs<CalculateRequestMessage> e)
        {
            ConnectionContext aUserContext;
            lock (myConnections)
            {
                aUserContext = myConnections.FirstOrDefault(
                    x => x.ResponseReceiverId == e.ResponseReceiverId);
            }
            double aResult = e.RequestMessage.Number1 + e.RequestMessage.Number2;

            Console.WriteLine("Пользователь: " + aUserContext.UserName
                + " -> " + e.RequestMessage.Number1
                + " + " + e.RequestMessage.Number2 + " = " + aResult);

            // Отправляем результат обратно
            IMultiTypedMessageReceiver aReceiver = (IMultiTypedMessageReceiver)eventSender;
            try
            {
                CalculateResponseMessage aResponse = new CalculateResponseMessage()
                {
                    Result = aResult
                };
                aReceiver.SendResponseMessage<CalculateResponseMessage>(e.ResponseReceiverId, aResponse);
            }
            catch (Exception err)
            {
                EneterTrace.Error("Не удалось отправить ответное сообщение.", err);
            }
        }

       // Он обрабатывает сообщение запроса от клиента для вычисления факториала
        private static void OnFactorialRequest(Object eventSender, TypedRequestReceivedEventArgs<int> e)
        {
            ConnectionContext aUserContext;
            lock (myConnections)
            {
                aUserContext = myConnections.FirstOrDefault(x => x.ResponseReceiverId == e.ResponseReceiverId);
            }
            int aResult = 1;
            for (int i = 2; i <= e.RequestMessage; i++)
            {
                aResult *= i;
            }

            Console.WriteLine("Пользователь: " + aUserContext.UserName + " -> " + e.RequestMessage + "! = " + aResult);

            // Отправляем результат обратно.
            IMultiTypedMessageReceiver aReceiver = (IMultiTypedMessageReceiver)eventSender;
            try
            {
                aReceiver.SendResponseMessage<int>(e.ResponseReceiverId, aResult);
            }
            catch (Exception err)
            {
                EneterTrace.Error("Не удалось отправить ответное сообщение.", err);
            }
        }


        private static void CreateUser(string userName, string password)
        {
            // Создать случайный salt.
            byte[] s = SRP.s();

            // Вычислить закрытый ключ из пароля и salt
            byte[] x = SRP.x(password, s);

            // Вычислить верификатор
            byte[] v = SRP.v(x);

            // Сохраняем имя пользователя, salt и верификатор.
            // Примечание: не хранить пароль и закрытый ключ!
            User aUser = new User(userName, s, v);
            lock (myUsers)
            {
                myUsers.Add(aUser);
            }
        }

        private static User GetUser(string userName)
        {
            lock (myUsers)
            {
                User aUser = myUsers.FirstOrDefault(x => x.UserName == userName);
                return aUser;
            }
        }
    }
}
