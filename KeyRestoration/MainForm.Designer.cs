
namespace KeyRestoration
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelShadow1 = new System.Windows.Forms.Label();
            this.labelShadow2 = new System.Windows.Forms.Label();
            this.textBoxCaseNumber = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxUserInfo = new System.Windows.Forms.ComboBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonRegisterNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.textBoxNewLogin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.labelPathToFolder = new System.Windows.Forms.Label();
            this.pathToFolderTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelShadow1
            // 
            this.labelShadow1.AutoSize = true;
            this.labelShadow1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelShadow1.Location = new System.Drawing.Point(12, 20);
            this.labelShadow1.Name = "labelShadow1";
            this.labelShadow1.Size = new System.Drawing.Size(303, 13);
            this.labelShadow1.TabIndex = 2;
            this.labelShadow1.Text = "Введите данные пользователя и выберите нужную строку";
            this.labelShadow1.Visible = false;
            // 
            // labelShadow2
            // 
            this.labelShadow2.AutoSize = true;
            this.labelShadow2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelShadow2.Location = new System.Drawing.Point(12, 60);
            this.labelShadow2.Name = "labelShadow2";
            this.labelShadow2.Size = new System.Drawing.Size(169, 13);
            this.labelShadow2.TabIndex = 5;
            this.labelShadow2.Text = "Укажите номер судебного дела";
            this.labelShadow2.Visible = false;
            // 
            // textBoxCaseNumber
            // 
            this.textBoxCaseNumber.Location = new System.Drawing.Point(12, 76);
            this.textBoxCaseNumber.Name = "textBoxCaseNumber";
            this.textBoxCaseNumber.Size = new System.Drawing.Size(383, 20);
            this.textBoxCaseNumber.TabIndex = 3;
            this.textBoxCaseNumber.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(234, 155);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(161, 22);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Восстановить ключ";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Visible = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboBoxUserInfo
            // 
            this.comboBoxUserInfo.FormattingEnabled = true;
            this.comboBoxUserInfo.Location = new System.Drawing.Point(12, 36);
            this.comboBoxUserInfo.Name = "comboBoxUserInfo";
            this.comboBoxUserInfo.Size = new System.Drawing.Size(383, 21);
            this.comboBoxUserInfo.TabIndex = 10;
            this.comboBoxUserInfo.Visible = false;
            this.comboBoxUserInfo.TextUpdate += new System.EventHandler(this.comboBoxUserInfo_TextUpdate);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(12, 69);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(383, 20);
            this.textBoxLogin.TabIndex = 11;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 109);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(383, 20);
            this.textBoxPassword.TabIndex = 12;
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSignIn.Location = new System.Drawing.Point(311, 157);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(84, 22);
            this.buttonSignIn.TabIndex = 13;
            this.buttonSignIn.Text = "Войти";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Пароль";
            // 
            // buttonRegister
            // 
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRegister.Location = new System.Drawing.Point(12, 157);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(132, 22);
            this.buttonRegister.TabIndex = 16;
            this.buttonRegister.Text = "К регистрации";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonRegisterNew
            // 
            this.buttonRegisterNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRegisterNew.Location = new System.Drawing.Point(263, 183);
            this.buttonRegisterNew.Name = "buttonRegisterNew";
            this.buttonRegisterNew.Size = new System.Drawing.Size(132, 22);
            this.buttonRegisterNew.TabIndex = 22;
            this.buttonRegisterNew.Text = "Зарегистрироваться";
            this.buttonRegisterNew.UseVisualStyleBackColor = true;
            this.buttonRegisterNew.Visible = false;
            this.buttonRegisterNew.Click += new System.EventHandler(this.buttonRegisterNew_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Пароль";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Логин";
            this.label4.Visible = false;
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Location = new System.Drawing.Point(12, 157);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.PasswordChar = '*';
            this.textBoxNewPass.Size = new System.Drawing.Size(383, 20);
            this.textBoxNewPass.TabIndex = 18;
            this.textBoxNewPass.Visible = false;
            this.textBoxNewPass.TextChanged += new System.EventHandler(this.textBoxNewPass_TextChanged);
            // 
            // textBoxNewLogin
            // 
            this.textBoxNewLogin.Location = new System.Drawing.Point(12, 117);
            this.textBoxNewLogin.Name = "textBoxNewLogin";
            this.textBoxNewLogin.Size = new System.Drawing.Size(383, 20);
            this.textBoxNewLogin.TabIndex = 17;
            this.textBoxNewLogin.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Укажите фамилию, имя и отчество, а также придумайте логин и пароль";
            this.label5.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBack.Location = new System.Drawing.Point(12, 183);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(84, 22);
            this.buttonBack.TabIndex = 27;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Visible = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonExit.Location = new System.Drawing.Point(12, 155);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(95, 22);
            this.buttonExit.TabIndex = 28;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Visible = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenFolder.Location = new System.Drawing.Point(285, 116);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(110, 22);
            this.buttonOpenFolder.TabIndex = 31;
            this.buttonOpenFolder.Text = "Открыть каталог";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Visible = false;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // labelPathToFolder
            // 
            this.labelPathToFolder.AutoSize = true;
            this.labelPathToFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPathToFolder.Location = new System.Drawing.Point(15, 102);
            this.labelPathToFolder.Name = "labelPathToFolder";
            this.labelPathToFolder.Size = new System.Drawing.Size(168, 13);
            this.labelPathToFolder.TabIndex = 30;
            this.labelPathToFolder.Text = "Укажите путь к каталогу ключа";
            this.labelPathToFolder.Visible = false;
            // 
            // pathToFolderTextBox
            // 
            this.pathToFolderTextBox.Location = new System.Drawing.Point(12, 118);
            this.pathToFolderTextBox.Name = "pathToFolderTextBox";
            this.pathToFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pathToFolderTextBox.Size = new System.Drawing.Size(264, 20);
            this.pathToFolderTextBox.TabIndex = 29;
            this.pathToFolderTextBox.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(56, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Войдите в систему, введя логин и пароль в поля ниже";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(363, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Если вы еще не зарегистрированы, нажмите кнопку \"К регистрации\"";
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.BackColor = System.Drawing.SystemColors.Window;
            this.labelPatronymic.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelPatronymic.Location = new System.Drawing.Point(16, 81);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(54, 13);
            this.labelPatronymic.TabIndex = 39;
            this.labelPatronymic.Text = "Отчество";
            this.labelPatronymic.Visible = false;
            this.labelPatronymic.Click += new System.EventHandler(this.labelPatronymic_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.SystemColors.Window;
            this.labelName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelName.Location = new System.Drawing.Point(16, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 13);
            this.labelName.TabIndex = 38;
            this.labelName.Text = "Имя";
            this.labelName.Visible = false;
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.BackColor = System.Drawing.SystemColors.Window;
            this.labelSurname.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelSurname.Location = new System.Drawing.Point(16, 29);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(56, 13);
            this.labelSurname.TabIndex = 37;
            this.labelSurname.Text = "Фамилия";
            this.labelSurname.Visible = false;
            this.labelSurname.Click += new System.EventHandler(this.labelSurname_Click);
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(12, 78);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPatronymic.Size = new System.Drawing.Size(383, 20);
            this.textBoxPatronymic.TabIndex = 36;
            this.textBoxPatronymic.Visible = false;
            this.textBoxPatronymic.TextChanged += new System.EventHandler(this.textBoxPatronymic_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 52);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxName.Size = new System.Drawing.Size(383, 20);
            this.textBoxName.TabIndex = 35;
            this.textBoxName.Visible = false;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(12, 26);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSurname.Size = new System.Drawing.Size(383, 20);
            this.textBoxSurname.TabIndex = 34;
            this.textBoxSurname.Visible = false;
            this.textBoxSurname.TextChanged += new System.EventHandler(this.textBoxSurname_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 216);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.labelPathToFolder);
            this.Controls.Add(this.pathToFolderTextBox);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonRegisterNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNewPass);
            this.Controls.Add(this.textBoxNewLogin);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.comboBoxUserInfo);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelShadow2);
            this.Controls.Add(this.textBoxCaseNumber);
            this.Controls.Add(this.labelShadow1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Восстановление ключа: авторизация";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelShadow1;
        private System.Windows.Forms.Label labelShadow2;
        private System.Windows.Forms.TextBox textBoxCaseNumber;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboBoxUserInfo;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonRegisterNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.TextBox textBoxNewLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Label labelPathToFolder;
        private System.Windows.Forms.TextBox pathToFolderTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
    }
}

