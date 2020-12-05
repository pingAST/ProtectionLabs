namespace ProtectionLabs
{
    partial class FormCeaserCiper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.textBoxSourceFile = new System.Windows.Forms.TextBox();
            this.groupBoxSourceFile = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStartDecrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonViewEncryptFile = new System.Windows.Forms.Button();
            this.buttonViewSourceFile = new System.Windows.Forms.Button();
            this.textBoxEncryptFile = new System.Windows.Forms.TextBox();
            this.buttonStartEncrypt = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.buttonSourceFile = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonViewAllText = new System.Windows.Forms.Button();
            this.textBoxAllText = new System.Windows.Forms.TextBox();
            this.buttonAllText = new System.Windows.Forms.Button();
            this.buttonFreq = new System.Windows.Forms.Button();
            this.buttonFreqBigramm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxSourceFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openSourceFile
            // 
            this.openSourceFile.DefaultExt = "TXT";
            this.openSourceFile.Filter = "txt files (*.txt) | *.txt";
            this.openSourceFile.ReadOnlyChecked = true;
            this.openSourceFile.RestoreDirectory = true;
            this.openSourceFile.ShowReadOnly = true;
            this.openSourceFile.Title = "Выбор txt файла";
            // 
            // textBoxSourceFile
            // 
            this.textBoxSourceFile.Location = new System.Drawing.Point(147, 21);
            this.textBoxSourceFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSourceFile.Name = "textBoxSourceFile";
            this.textBoxSourceFile.ReadOnly = true;
            this.textBoxSourceFile.Size = new System.Drawing.Size(537, 22);
            this.textBoxSourceFile.TabIndex = 1;
            // 
            // groupBoxSourceFile
            // 
            this.groupBoxSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSourceFile.Controls.Add(this.label2);
            this.groupBoxSourceFile.Controls.Add(this.buttonStartDecrypt);
            this.groupBoxSourceFile.Controls.Add(this.label1);
            this.groupBoxSourceFile.Controls.Add(this.buttonViewEncryptFile);
            this.groupBoxSourceFile.Controls.Add(this.buttonViewSourceFile);
            this.groupBoxSourceFile.Controls.Add(this.textBoxEncryptFile);
            this.groupBoxSourceFile.Controls.Add(this.buttonStartEncrypt);
            this.groupBoxSourceFile.Controls.Add(this.textBoxSourceFile);
            this.groupBoxSourceFile.Controls.Add(this.labelKey);
            this.groupBoxSourceFile.Controls.Add(this.buttonSourceFile);
            this.groupBoxSourceFile.Controls.Add(this.numericUpDown1);
            this.groupBoxSourceFile.Location = new System.Drawing.Point(11, 11);
            this.groupBoxSourceFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSourceFile.Name = "groupBoxSourceFile";
            this.groupBoxSourceFile.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSourceFile.Size = new System.Drawing.Size(780, 114);
            this.groupBoxSourceFile.TabIndex = 3;
            this.groupBoxSourceFile.TabStop = false;
            this.groupBoxSourceFile.Text = "1. Зашифровать фрагмент романа шифром цезаря";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Зашифрованный фрагмент романа";
            // 
            // buttonStartDecrypt
            // 
            this.buttonStartDecrypt.Location = new System.Drawing.Point(400, 47);
            this.buttonStartDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStartDecrypt.Name = "buttonStartDecrypt";
            this.buttonStartDecrypt.Size = new System.Drawing.Size(117, 23);
            this.buttonStartDecrypt.TabIndex = 5;
            this.buttonStartDecrypt.Text = "Расшифровать";
            this.buttonStartDecrypt.UseVisualStyleBackColor = true;
            this.buttonStartDecrypt.Visible = false;
            this.buttonStartDecrypt.Click += new System.EventHandler(this.buttonStartDecrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фрагмент романа";
            // 
            // buttonViewEncryptFile
            // 
            this.buttonViewEncryptFile.Image = global::ProtectionLabs.Properties.Resources.Text_16x;
            this.buttonViewEncryptFile.Location = new System.Drawing.Point(704, 78);
            this.buttonViewEncryptFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonViewEncryptFile.Name = "buttonViewEncryptFile";
            this.buttonViewEncryptFile.Size = new System.Drawing.Size(23, 22);
            this.buttonViewEncryptFile.TabIndex = 4;
            this.buttonViewEncryptFile.UseVisualStyleBackColor = true;
            this.buttonViewEncryptFile.Click += new System.EventHandler(this.buttonViewEncryptFile_Click);
            // 
            // buttonViewSourceFile
            // 
            this.buttonViewSourceFile.Image = global::ProtectionLabs.Properties.Resources.Text_16x;
            this.buttonViewSourceFile.Location = new System.Drawing.Point(728, 22);
            this.buttonViewSourceFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonViewSourceFile.Name = "buttonViewSourceFile";
            this.buttonViewSourceFile.Size = new System.Drawing.Size(27, 21);
            this.buttonViewSourceFile.TabIndex = 3;
            this.buttonViewSourceFile.UseVisualStyleBackColor = true;
            this.buttonViewSourceFile.Click += new System.EventHandler(this.buttonViewSourceFile_Click);
            // 
            // textBoxEncryptFile
            // 
            this.textBoxEncryptFile.Location = new System.Drawing.Point(256, 76);
            this.textBoxEncryptFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEncryptFile.Name = "textBoxEncryptFile";
            this.textBoxEncryptFile.ReadOnly = true;
            this.textBoxEncryptFile.Size = new System.Drawing.Size(427, 22);
            this.textBoxEncryptFile.TabIndex = 3;
            // 
            // buttonStartEncrypt
            // 
            this.buttonStartEncrypt.Location = new System.Drawing.Point(275, 47);
            this.buttonStartEncrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStartEncrypt.Name = "buttonStartEncrypt";
            this.buttonStartEncrypt.Size = new System.Drawing.Size(117, 23);
            this.buttonStartEncrypt.TabIndex = 2;
            this.buttonStartEncrypt.Text = "Зашифровать";
            this.buttonStartEncrypt.UseVisualStyleBackColor = true;
            this.buttonStartEncrypt.Click += new System.EventHandler(this.buttonStartEncrypt_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(15, 53);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(200, 17);
            this.labelKey.TabIndex = 1;
            this.labelKey.Text = "Выберети ключ шифрования";
            // 
            // buttonSourceFile
            // 
            this.buttonSourceFile.Image = global::ProtectionLabs.Properties.Resources.FolderBottomPanel_16x;
            this.buttonSourceFile.Location = new System.Drawing.Point(692, 22);
            this.buttonSourceFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSourceFile.Name = "buttonSourceFile";
            this.buttonSourceFile.Size = new System.Drawing.Size(27, 21);
            this.buttonSourceFile.TabIndex = 2;
            this.buttonSourceFile.UseVisualStyleBackColor = true;
            this.buttonSourceFile.Click += new System.EventHandler(this.buttonSourceFile_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(221, 48);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonViewAllText);
            this.groupBox1.Controls.Add(this.textBoxAllText);
            this.groupBox1.Controls.Add(this.buttonAllText);
            this.groupBox1.Controls.Add(this.buttonFreq);
            this.groupBox1.Location = new System.Drawing.Point(11, 130);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(779, 92);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Частотный анализ на основе букв";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Весь роман";
            // 
            // buttonViewAllText
            // 
            this.buttonViewAllText.Image = global::ProtectionLabs.Properties.Resources.Text_16x;
            this.buttonViewAllText.Location = new System.Drawing.Point(728, 22);
            this.buttonViewAllText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonViewAllText.Name = "buttonViewAllText";
            this.buttonViewAllText.Size = new System.Drawing.Size(27, 21);
            this.buttonViewAllText.TabIndex = 7;
            this.buttonViewAllText.UseVisualStyleBackColor = true;
            this.buttonViewAllText.Enter += new System.EventHandler(this.buttonViewAllText_Enter);
            // 
            // textBoxAllText
            // 
            this.textBoxAllText.Location = new System.Drawing.Point(147, 21);
            this.textBoxAllText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAllText.Name = "textBoxAllText";
            this.textBoxAllText.ReadOnly = true;
            this.textBoxAllText.Size = new System.Drawing.Size(537, 22);
            this.textBoxAllText.TabIndex = 5;
            // 
            // buttonAllText
            // 
            this.buttonAllText.Image = global::ProtectionLabs.Properties.Resources.FolderBottomPanel_16x;
            this.buttonAllText.Location = new System.Drawing.Point(692, 22);
            this.buttonAllText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAllText.Name = "buttonAllText";
            this.buttonAllText.Size = new System.Drawing.Size(27, 21);
            this.buttonAllText.TabIndex = 6;
            this.buttonAllText.UseVisualStyleBackColor = true;
            this.buttonAllText.Click += new System.EventHandler(this.buttonAllText_Click);
            // 
            // buttonFreq
            // 
            this.buttonFreq.Location = new System.Drawing.Point(12, 49);
            this.buttonFreq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFreq.Name = "buttonFreq";
            this.buttonFreq.Size = new System.Drawing.Size(351, 25);
            this.buttonFreq.TabIndex = 0;
            this.buttonFreq.Text = "Расшифровать фрагмент романа";
            this.buttonFreq.UseVisualStyleBackColor = true;
            this.buttonFreq.Click += new System.EventHandler(this.buttonFreq_Click);
            // 
            // buttonFreqBigramm
            // 
            this.buttonFreqBigramm.Location = new System.Drawing.Point(5, 21);
            this.buttonFreqBigramm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFreqBigramm.Name = "buttonFreqBigramm";
            this.buttonFreqBigramm.Size = new System.Drawing.Size(351, 25);
            this.buttonFreqBigramm.TabIndex = 0;
            this.buttonFreqBigramm.Text = "Расшифровать фрагмент романа";
            this.buttonFreqBigramm.UseVisualStyleBackColor = true;
            this.buttonFreqBigramm.Click += new System.EventHandler(this.buttonFreqBigramm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonFreqBigramm);
            this.groupBox2.Location = new System.Drawing.Point(12, 228);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(779, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3. Частотный анализ на основе биграмм";
            // 
            // FormCeaserCiper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 316);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSourceFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormCeaserCiper";
            this.Text = "Частотный анализ текста Л.В. Толстого Война и мир";
            this.groupBoxSourceFile.ResumeLayout(false);
            this.groupBoxSourceFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openSourceFile;
        private System.Windows.Forms.TextBox textBoxSourceFile;
        private System.Windows.Forms.Button buttonSourceFile;
        private System.Windows.Forms.GroupBox groupBoxSourceFile;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonViewSourceFile;
        private System.Windows.Forms.Button buttonStartEncrypt;
        private System.Windows.Forms.Button buttonViewEncryptFile;
        private System.Windows.Forms.TextBox textBoxEncryptFile;
        private System.Windows.Forms.Button buttonStartDecrypt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonViewAllText;
        private System.Windows.Forms.TextBox textBoxAllText;
        private System.Windows.Forms.Button buttonAllText;
        private System.Windows.Forms.Button buttonFreqBigramm;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}