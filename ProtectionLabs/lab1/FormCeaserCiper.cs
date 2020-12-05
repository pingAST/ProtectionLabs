using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtectionLabs
{
    public partial class FormCeaserCiper : Form
    {
        public static string TextAllNovela;
        public static string TextEncryptPart;
        public static int GramSize;
        public FormCeaserCiper()
        {
            InitializeComponent();
        }

        private void buttonSourceFile_Click(object sender, EventArgs e)
        {
            if (openSourceFile.ShowDialog() == DialogResult.OK)
            {
                textBoxSourceFile.Text = openSourceFile.FileName;
            }
        }

        private void buttonViewSourceFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxSourceFile.Text);
        }

        private void buttonStartEncrypt_Click(object sender, EventArgs e)
        {
            string sourceText = File.ReadAllText(textBoxSourceFile.Text);
            string encryptText = CaesarCipher.Encryption(sourceText, (int)numericUpDown1.Value);
            var path = Path.GetTempPath();
            var sfileName = Guid.NewGuid().ToString() + ".txt";
            var fileName = Path.Combine(path, sfileName);
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, encryptText);
                textBoxEncryptFile.Text = fileName;
            }
        }

        private void buttonViewEncryptFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxEncryptFile.Text);
        }

        private void buttonStartDecrypt_Click(object sender, EventArgs e)
        {
            string sourceText = File.ReadAllText(textBoxEncryptFile.Text);
            string encryptText = CaesarCipher.Encryption(sourceText, -(int)numericUpDown1.Value);
            var path = Path.GetTempPath();
            var sfileName = Guid.NewGuid().ToString() + ".txt";
            var fileName = Path.Combine(path, sfileName);
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, encryptText);
                textBoxEncryptFile.Text = fileName;
            }
        }

        private void buttonFreq_Click(object sender, EventArgs e)
        {
            TextAllNovela = textBoxAllText.Text;
            TextEncryptPart = textBoxEncryptFile.Text;
            GramSize = 1;
            FormFreqLetters formFL = new FormFreqLetters();
            formFL.ShowDialog();
            formFL.Dispose();

        }

        private void buttonAllText_Click(object sender, EventArgs e)
        {
            if (openSourceFile.ShowDialog() == DialogResult.OK)
            {
                textBoxAllText.Text = openSourceFile.FileName;
            }
        }

        private void buttonViewAllText_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxAllText.Text);
        }

        private void buttonFreqBigramm_Click(object sender, EventArgs e)
        {
            TextAllNovela = textBoxAllText.Text;
            TextEncryptPart = textBoxEncryptFile.Text;
            GramSize = 2;
            FormFreqLetters formFL = new FormFreqLetters();
            formFL.ShowDialog();
            formFL.Dispose();

        }
    }
}
