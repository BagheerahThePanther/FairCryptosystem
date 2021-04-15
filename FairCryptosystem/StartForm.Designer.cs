
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
            this.pathToFolderTextBox = new System.Windows.Forms.TextBox();
            this.labelPathToFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.labelNext = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSNILS = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.labelSNILS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathToFolderTextBox
            // 
            this.pathToFolderTextBox.Location = new System.Drawing.Point(13, 149);
            this.pathToFolderTextBox.Name = "pathToFolderTextBox";
            this.pathToFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pathToFolderTextBox.Size = new System.Drawing.Size(252, 20);
            this.pathToFolderTextBox.TabIndex = 4;
            // 
            // labelPathToFolder
            // 
            this.labelPathToFolder.AutoSize = true;
            this.labelPathToFolder.Location = new System.Drawing.Point(13, 133);
            this.labelPathToFolder.Name = "labelPathToFolder";
            this.labelPathToFolder.Size = new System.Drawing.Size(168, 13);
            this.labelPathToFolder.TabIndex = 6;
            this.labelPathToFolder.Text = "Укажите путь к каталогу ключа";
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(271, 133);
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
            this.labelNext.Location = new System.Drawing.Point(13, 173);
            this.labelNext.Name = "labelNext";
            this.labelNext.Size = new System.Drawing.Size(227, 39);
            this.labelNext.TabIndex = 12;
            this.labelNext.Text = "Нажмите \"Создать учетную запись\" чтобы \r\nзарегистрироваться, сгенерировать ключ \r" +
    "\nи записать его по выбранному пути";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(12, 25);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSurname.Size = new System.Drawing.Size(369, 20);
            this.textBoxSurname.TabIndex = 16;
            this.textBoxSurname.TextChanged += new System.EventHandler(this.textBoxSurname_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 51);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxName.Size = new System.Drawing.Size(369, 20);
            this.textBoxName.TabIndex = 17;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(12, 77);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPatronymic.Size = new System.Drawing.Size(369, 20);
            this.textBoxPatronymic.TabIndex = 18;
            this.textBoxPatronymic.TextChanged += new System.EventHandler(this.textBoxPatronymic_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Укажите фамилию, имя, отчество и номер СНИЛС";
            // 
            // textBoxSNILS
            // 
            this.textBoxSNILS.Location = new System.Drawing.Point(12, 103);
            this.textBoxSNILS.Name = "textBoxSNILS";
            this.textBoxSNILS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSNILS.Size = new System.Drawing.Size(369, 20);
            this.textBoxSNILS.TabIndex = 20;
            this.textBoxSNILS.TextChanged += new System.EventHandler(this.textBoxSNILS_TextChanged);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(271, 171);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(110, 41);
            this.buttonNext.TabIndex = 21;
            this.buttonNext.Text = "Создать учетную запись";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.BackColor = System.Drawing.SystemColors.Window;
            this.labelSurname.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelSurname.Location = new System.Drawing.Point(16, 28);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(56, 13);
            this.labelSurname.TabIndex = 22;
            this.labelSurname.Text = "Фамилия";
            this.labelSurname.Click += new System.EventHandler(this.labelSurname_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.SystemColors.Window;
            this.labelName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelName.Location = new System.Drawing.Point(16, 54);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 13);
            this.labelName.TabIndex = 23;
            this.labelName.Text = "Имя";
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.BackColor = System.Drawing.SystemColors.Window;
            this.labelPatronymic.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPatronymic.Location = new System.Drawing.Point(16, 80);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(54, 13);
            this.labelPatronymic.TabIndex = 24;
            this.labelPatronymic.Text = "Отчество";
            this.labelPatronymic.Click += new System.EventHandler(this.labelPatronymic_Click);
            // 
            // labelSNILS
            // 
            this.labelSNILS.AutoSize = true;
            this.labelSNILS.BackColor = System.Drawing.SystemColors.Window;
            this.labelSNILS.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelSNILS.Location = new System.Drawing.Point(16, 106);
            this.labelSNILS.Name = "labelSNILS";
            this.labelSNILS.Size = new System.Drawing.Size(45, 13);
            this.labelSNILS.TabIndex = 25;
            this.labelSNILS.Text = "СНИЛС";
            this.labelSNILS.Click += new System.EventHandler(this.labelSNILS_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(390, 227);
            this.Controls.Add(this.labelSNILS);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxSNILS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelNext);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.labelPathToFolder);
            this.Controls.Add(this.pathToFolderTextBox);
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
        private System.Windows.Forms.TextBox pathToFolderTextBox;
        private System.Windows.Forms.Label labelPathToFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Label labelNext;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSNILS;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.Label labelSNILS;
    }
}

