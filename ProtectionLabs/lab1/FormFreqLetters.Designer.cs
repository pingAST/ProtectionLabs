namespace ProtectionLabs
{
    partial class FormFreqLetters
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
            this.dataGridViewAllLetersNovel = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewPart = new System.Windows.Forms.DataGridView();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.textBoxEncryptText = new System.Windows.Forms.TextBox();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUP = new System.Windows.Forms.Button();
            this.buttonViewText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllLetersNovel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAllLetersNovel
            // 
            this.dataGridViewAllLetersNovel.AllowUserToAddRows = false;
            this.dataGridViewAllLetersNovel.AllowUserToDeleteRows = false;
            this.dataGridViewAllLetersNovel.AllowUserToOrderColumns = true;
            this.dataGridViewAllLetersNovel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAllLetersNovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllLetersNovel.Location = new System.Drawing.Point(17, 52);
            this.dataGridViewAllLetersNovel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAllLetersNovel.Name = "dataGridViewAllLetersNovel";
            this.dataGridViewAllLetersNovel.ReadOnly = true;
            this.dataGridViewAllLetersNovel.RowHeadersWidth = 51;
            this.dataGridViewAllLetersNovel.RowTemplate.Height = 24;
            this.dataGridViewAllLetersNovel.Size = new System.Drawing.Size(255, 289);
            this.dataGridViewAllLetersNovel.TabIndex = 0;
            this.dataGridViewAllLetersNovel.SelectionChanged += new System.EventHandler(this.dataGridViewAllLetersNovel_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Частота букв во всем романе";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Частота букв в зашифрованой части";
            // 
            // dataGridViewPart
            // 
            this.dataGridViewPart.AllowUserToOrderColumns = true;
            this.dataGridViewPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPart.Location = new System.Drawing.Point(352, 52);
            this.dataGridViewPart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPart.Name = "dataGridViewPart";
            this.dataGridViewPart.ReadOnly = true;
            this.dataGridViewPart.RowHeadersWidth = 51;
            this.dataGridViewPart.RowTemplate.Height = 24;
            this.dataGridViewPart.Size = new System.Drawing.Size(264, 289);
            this.dataGridViewPart.TabIndex = 3;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(17, 357);
            this.buttonDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(312, 23);
            this.buttonDecrypt.TabIndex = 4;
            this.buttonDecrypt.Text = "Расшифровать на основе частоты букв";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // textBoxEncryptText
            // 
            this.textBoxEncryptText.Location = new System.Drawing.Point(21, 398);
            this.textBoxEncryptText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEncryptText.Name = "textBoxEncryptText";
            this.textBoxEncryptText.ReadOnly = true;
            this.textBoxEncryptText.Size = new System.Drawing.Size(612, 22);
            this.textBoxEncryptText.TabIndex = 5;
            // 
            // buttonDown
            // 
            this.buttonDown.Image = global::ProtectionLabs.Properties.Resources.Download_16x;
            this.buttonDown.Location = new System.Drawing.Point(677, 194);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(39, 44);
            this.buttonDown.TabIndex = 8;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUP
            // 
            this.buttonUP.Image = global::ProtectionLabs.Properties.Resources.Upload_16x;
            this.buttonUP.Location = new System.Drawing.Point(679, 124);
            this.buttonUP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(39, 44);
            this.buttonUP.TabIndex = 7;
            this.buttonUP.UseVisualStyleBackColor = true;
            this.buttonUP.Click += new System.EventHandler(this.buttonUP_Click);
            // 
            // buttonViewText
            // 
            this.buttonViewText.Image = global::ProtectionLabs.Properties.Resources.Text_16x;
            this.buttonViewText.Location = new System.Drawing.Point(661, 396);
            this.buttonViewText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonViewText.Name = "buttonViewText";
            this.buttonViewText.Size = new System.Drawing.Size(29, 23);
            this.buttonViewText.TabIndex = 6;
            this.buttonViewText.UseVisualStyleBackColor = true;
            this.buttonViewText.Click += new System.EventHandler(this.buttonViewText_Click);
            // 
            // FormFreqLetters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.buttonViewText);
            this.Controls.Add(this.textBoxEncryptText);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.dataGridViewPart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAllLetersNovel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormFreqLetters";
            this.Text = "Частота букв";
            this.Load += new System.EventHandler(this.FormFreqLetters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllLetersNovel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAllLetersNovel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewPart;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.TextBox textBoxEncryptText;
        private System.Windows.Forms.Button buttonViewText;
        private System.Windows.Forms.Button buttonUP;
        private System.Windows.Forms.Button buttonDown;
    }
}