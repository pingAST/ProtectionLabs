namespace ProtectionLabs
{
    partial class FormStart
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.лаболаторная1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лаболаторная2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лаболаторная3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лаболаторная4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonBrouse = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лаболаторная1ToolStripMenuItem,
            this.лаболаторная2ToolStripMenuItem,
            this.лаболаторная3ToolStripMenuItem,
            this.лаболаторная4ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // лаболаторная1ToolStripMenuItem
            // 
            this.лаболаторная1ToolStripMenuItem.Name = "лаболаторная1ToolStripMenuItem";
            this.лаболаторная1ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.лаболаторная1ToolStripMenuItem.Text = "Лаболаторная №1";
            this.лаболаторная1ToolStripMenuItem.Click += new System.EventHandler(this.лаболаторная1ToolStripMenuItem_Click);
            // 
            // лаболаторная2ToolStripMenuItem
            // 
            this.лаболаторная2ToolStripMenuItem.Name = "лаболаторная2ToolStripMenuItem";
            this.лаболаторная2ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.лаболаторная2ToolStripMenuItem.Text = "Лаболаторная №2";
            this.лаболаторная2ToolStripMenuItem.Click += new System.EventHandler(this.лаболаторная2ToolStripMenuItem_Click);
            // 
            // лаболаторная3ToolStripMenuItem
            // 
            this.лаболаторная3ToolStripMenuItem.Name = "лаболаторная3ToolStripMenuItem";
            this.лаболаторная3ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.лаболаторная3ToolStripMenuItem.Text = "Лаболаторная №3";
            this.лаболаторная3ToolStripMenuItem.Click += new System.EventHandler(this.лаболаторная3ToolStripMenuItem1_Click);
            // 
            // лаболаторная4ToolStripMenuItem
            // 
            this.лаболаторная4ToolStripMenuItem.Name = "лаболаторная4ToolStripMenuItem";
            this.лаболаторная4ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.лаболаторная4ToolStripMenuItem.Text = "Лаболаторная №4";
            this.лаболаторная4ToolStripMenuItem.Click += new System.EventHandler(this.лаболаторная4ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите файл сервера для тестирования SRP (Лаболаторная №4)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "EXE";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "exe files (*.exe) | *.exe";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.Title = "Выбор exe скрвера SRP";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(36, 357);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(664, 22);
            this.textBoxFile.TabIndex = 2;
            // 
            // buttonBrouse
            // 
            this.buttonBrouse.Image = global::ProtectionLabs.Properties.Resources.FolderBottomPanel_16x;
            this.buttonBrouse.Location = new System.Drawing.Point(717, 357);
            this.buttonBrouse.Name = "buttonBrouse";
            this.buttonBrouse.Size = new System.Drawing.Size(34, 22);
            this.buttonBrouse.TabIndex = 3;
            this.buttonBrouse.UseVisualStyleBackColor = true;
            this.buttonBrouse.Click += new System.EventHandler(this.buttonBrouse_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(42, 395);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(171, 31);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonBrouse);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormStart";
            this.Text = "Курс \"Защита информации\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem лаболаторная1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лаболаторная2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лаболаторная3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лаболаторная4ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonBrouse;
        private System.Windows.Forms.Button buttonStart;
    }
}

