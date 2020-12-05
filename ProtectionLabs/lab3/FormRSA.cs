using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectionLabs
{
    public partial class FormRSA : Form
    {
        public FormRSA()
        {
            InitializeComponent();
        }

        #region-----Encryptionand Decryption Function-----
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
        #endregion

        #region--variables area
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        #endregion

        private void bSend1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbClient1.Text))
            {
                plaintext = ByteConverter.GetBytes(tbClient1.Text);
                encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
                tbHacker.Text = ByteConverter.GetString(encryptedtext);
                byte[] decryptedText = Decryption(encryptedtext, RSA.ExportParameters(true), false);
                tbInput2.Text = $"{tbInput2.Text}  {ByteConverter.GetString(decryptedText)}";
                tbClient1.Clear();

            }    
        }

        private void bSend2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbClient2.Text))
            {
                plaintext = ByteConverter.GetBytes(tbClient2.Text);
                encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
                tbHacker.Text = ByteConverter.GetString(encryptedtext);
                byte[] decryptedText = Decryption(encryptedtext, RSA.ExportParameters(true), false);
                tbInput1.Text = $"{tbInput1.Text}  {ByteConverter.GetString(decryptedText)}";
                tbClient2.Clear();

            }
        }
    }
}
