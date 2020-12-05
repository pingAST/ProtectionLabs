using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectionLabs

{
    public partial class FormDiffeHelman : Form
    {
        public FormDiffeHelman()
        {
            InitializeComponent();
        }

        private void FormDiffeHelman_Load(object sender, EventArgs e)
        {

        }
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        private void bSend1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbClient1.Text))
            {
                using (var clientOne = new DiffieHellman())
                {
                    using (var cLientTwo = new DiffieHellman())
                    {
                        
                        byte[] secretMessage = clientOne.Encrypt(cLientTwo.PublicKey, tbClient1.Text);
                        tbHacker.Text = ByteConverter.GetString(secretMessage);
                        string decryptedMessage = cLientTwo.Decrypt(clientOne.PublicKey, secretMessage, clientOne.IV);
                        tbInput2.Text = $"{tbInput2.Text}  {decryptedMessage}";
                        tbClient1.Clear();
                    }
                }
            }


        }

        private void bSend2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tbClient2.Text))
            {
                using (var clientTwo = new DiffieHellman())
                {
                    using (var cLientOne = new DiffieHellman())
                    {

                        byte[] secretMessage = clientTwo.Encrypt(cLientOne.PublicKey, tbClient2.Text);
                        tbHacker.Text = ByteConverter.GetString(secretMessage);

                        string decryptedMessage = cLientOne.Decrypt(clientTwo.PublicKey, secretMessage, clientTwo.IV);
                        tbInput1.Text = $"{tbInput1.Text}  {decryptedMessage}";
                        tbClient2.Clear();
                    }
                }
            }
        }
    }
}
