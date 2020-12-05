namespace ProtectionLabs
{
    partial class FormRSA
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbHacker = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInput2 = new System.Windows.Forms.TextBox();
            this.tbInput1 = new System.Windows.Forms.TextBox();
            this.bSend2 = new System.Windows.Forms.Button();
            this.bSend1 = new System.Windows.Forms.Button();
            this.tbClient2 = new System.Windows.Forms.TextBox();
            this.tbClient1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Шифрованное сообщение в канале";
            // 
            // tbHacker
            // 
            this.tbHacker.Location = new System.Drawing.Point(70, 323);
            this.tbHacker.Multiline = true;
            this.tbHacker.Name = "tbHacker";
            this.tbHacker.ReadOnly = true;
            this.tbHacker.Size = new System.Drawing.Size(672, 101);
            this.tbHacker.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Второй";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Первый";
            // 
            // tbInput2
            // 
            this.tbInput2.Location = new System.Drawing.Point(455, 53);
            this.tbInput2.Multiline = true;
            this.tbInput2.Name = "tbInput2";
            this.tbInput2.ReadOnly = true;
            this.tbInput2.Size = new System.Drawing.Size(319, 163);
            this.tbInput2.TabIndex = 15;
            // 
            // tbInput1
            // 
            this.tbInput1.Location = new System.Drawing.Point(30, 53);
            this.tbInput1.Multiline = true;
            this.tbInput1.Name = "tbInput1";
            this.tbInput1.ReadOnly = true;
            this.tbInput1.Size = new System.Drawing.Size(303, 163);
            this.tbInput1.TabIndex = 14;
            // 
            // bSend2
            // 
            this.bSend2.Location = new System.Drawing.Point(455, 266);
            this.bSend2.Name = "bSend2";
            this.bSend2.Size = new System.Drawing.Size(160, 25);
            this.bSend2.TabIndex = 13;
            this.bSend2.Text = "Отправить";
            this.bSend2.UseVisualStyleBackColor = true;
            this.bSend2.Click += new System.EventHandler(this.bSend2_Click);
            // 
            // bSend1
            // 
            this.bSend1.Location = new System.Drawing.Point(37, 266);
            this.bSend1.Name = "bSend1";
            this.bSend1.Size = new System.Drawing.Size(160, 25);
            this.bSend1.TabIndex = 12;
            this.bSend1.Text = "Отправить";
            this.bSend1.UseVisualStyleBackColor = true;
            this.bSend1.Click += new System.EventHandler(this.bSend1_Click);
            // 
            // tbClient2
            // 
            this.tbClient2.Location = new System.Drawing.Point(455, 230);
            this.tbClient2.Name = "tbClient2";
            this.tbClient2.Size = new System.Drawing.Size(319, 22);
            this.tbClient2.TabIndex = 11;
            // 
            // tbClient1
            // 
            this.tbClient1.Location = new System.Drawing.Point(30, 230);
            this.tbClient1.Name = "tbClient1";
            this.tbClient1.Size = new System.Drawing.Size(303, 22);
            this.tbClient1.TabIndex = 10;
            // 
            // FormRSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHacker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInput2);
            this.Controls.Add(this.tbInput1);
            this.Controls.Add(this.bSend2);
            this.Controls.Add(this.bSend1);
            this.Controls.Add(this.tbClient2);
            this.Controls.Add(this.tbClient1);
            this.Name = "FormRSA";
            this.Text = "Реализация протокола  Ривеста, Шамира, Адлемана (RSA)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHacker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInput2;
        private System.Windows.Forms.TextBox tbInput1;
        private System.Windows.Forms.Button bSend2;
        private System.Windows.Forms.Button bSend1;
        private System.Windows.Forms.TextBox tbClient2;
        private System.Windows.Forms.TextBox tbClient1;
    }
}