using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProtectionLabs
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void лаболаторная1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCeaserCiper formCeaserCiper = new FormCeaserCiper();
            formCeaserCiper.ShowDialog();
            formCeaserCiper.Dispose();
        }

        private void лаболаторная2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiffeHelman formDiffeHelman = new FormDiffeHelman();
            formDiffeHelman.ShowDialog();
            formDiffeHelman.Dispose();
        }

       
        private void лаболаторная3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRSA formRSA = new FormRSA();
            formRSA.ShowDialog();
            formRSA.Dispose();
        }

        private void buttonBrouse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = openFileDialog1.FileName;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                System.Diagnostics.Process.Start(textBoxFile.Text);
            }    
        }

        private void лаболаторная4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSRP formSRP = new FormSRP();
            formSRP.ShowDialog();
            formSRP.Dispose();
        }
    }
}
