
namespace FairCryptosystem
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.buttonKey = new System.Windows.Forms.Button();
            this.pathToFolderTextBox = new System.Windows.Forms.TextBox();
            this.labelPathToFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.labelNext = new System.Windows.Forms.Label();
            this.buttonShadow1 = new System.Windows.Forms.Button();
            this.buttonShadow2 = new System.Windows.Forms.Button();
            this.buttonShadow3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonKey
            // 
            this.buttonKey.Location = new System.Drawing.Point(270, 56);
            this.buttonKey.Name = "buttonKey";
            this.buttonKey.Size = new System.Drawing.Size(110, 26);
            this.buttonKey.TabIndex = 2;
            this.buttonKey.Text = "Далее";
            this.buttonKey.UseVisualStyleBackColor = true;
            this.buttonKey.Click += new System.EventHandler(this.buttonNext_ClickKey);
            // 
            // pathToFolderTextBox
            // 
            this.pathToFolderTextBox.Location = new System.Drawing.Point(12, 25);
            this.pathToFolderTextBox.Name = "pathToFolderTextBox";
            this.pathToFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pathToFolderTextBox.Size = new System.Drawing.Size(252, 20);
            this.pathToFolderTextBox.TabIndex = 4;
            // 
            // labelPathToFolder
            // 
            this.labelPathToFolder.AutoSize = true;
            this.labelPathToFolder.Location = new System.Drawing.Point(12, 9);
            this.labelPathToFolder.Name = "labelPathToFolder";
            this.labelPathToFolder.Size = new System.Drawing.Size(172, 13);
            this.labelPathToFolder.TabIndex = 6;
            this.labelPathToFolder.Text = "Укажите путь к носителю ключа";
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(270, 18);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(110, 32);
            this.buttonOpenFolder.TabIndex = 10;
            this.buttonOpenFolder.Text = "Открыть каталог";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // labelNext
            // 
            this.labelNext.AutoSize = true;
            this.labelNext.Location = new System.Drawing.Point(9, 56);
            this.labelNext.Name = "labelNext";
            this.labelNext.Size = new System.Drawing.Size(252, 26);
            this.labelNext.TabIndex = 12;
            this.labelNext.Text = "Нажмите \"Далее\" чтобы сгенерировать ключ и \r\nзаписать его на выбранный носитель";
            // 
            // buttonShadow1
            // 
            this.buttonShadow1.Location = new System.Drawing.Point(270, 56);
            this.buttonShadow1.Name = "buttonShadow1";
            this.buttonShadow1.Size = new System.Drawing.Size(110, 26);
            this.buttonShadow1.TabIndex = 13;
            this.buttonShadow1.Text = "Далее";
            this.buttonShadow1.UseVisualStyleBackColor = true;
            this.buttonShadow1.Visible = false;
            this.buttonShadow1.Click += new System.EventHandler(this.buttonShadow1_Click);
            // 
            // buttonShadow2
            // 
            this.buttonShadow2.Location = new System.Drawing.Point(270, 56);
            this.buttonShadow2.Name = "buttonShadow2";
            this.buttonShadow2.Size = new System.Drawing.Size(110, 26);
            this.buttonShadow2.TabIndex = 14;
            this.buttonShadow2.Text = "Далее";
            this.buttonShadow2.UseVisualStyleBackColor = true;
            this.buttonShadow2.Visible = false;
            this.buttonShadow2.Click += new System.EventHandler(this.buttonShadow2_Click);
            // 
            // buttonShadow3
            // 
            this.buttonShadow3.Location = new System.Drawing.Point(270, 56);
            this.buttonShadow3.Name = "buttonShadow3";
            this.buttonShadow3.Size = new System.Drawing.Size(110, 26);
            this.buttonShadow3.TabIndex = 15;
            this.buttonShadow3.Text = "Далее";
            this.buttonShadow3.UseVisualStyleBackColor = true;
            this.buttonShadow3.Visible = false;
            this.buttonShadow3.Click += new System.EventHandler(this.buttonShadow3_Click);
            // 
            // StartForm
            // 
            this.AcceptButton = this.buttonKey;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(392, 96);
            this.Controls.Add(this.buttonShadow3);
            this.Controls.Add(this.buttonShadow2);
            this.Controls.Add(this.buttonShadow1);
            this.Controls.Add(this.labelNext);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.labelPathToFolder);
            this.Controls.Add(this.pathToFolderTextBox);
            this.Controls.Add(this.buttonKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор ключевой информации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonKey;
        private System.Windows.Forms.TextBox pathToFolderTextBox;
        private System.Windows.Forms.Label labelPathToFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Label labelNext;
        private System.Windows.Forms.Button buttonShadow1;
        private System.Windows.Forms.Button buttonShadow2;
        private System.Windows.Forms.Button buttonShadow3;
    }
}

