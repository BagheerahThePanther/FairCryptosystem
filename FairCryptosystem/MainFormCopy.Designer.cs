
namespace FairCryptosystem
{
    partial class MainFormCopy
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
            this.SecretTextBox = new System.Windows.Forms.TextBox();
            this.ShadowsTextBox = new System.Windows.Forms.TextBox();
            this.buttonGenerateKey = new System.Windows.Forms.Button();
            this.buttonGenerateShadows = new System.Windows.Forms.Button();
            this.RestoredSecretTextBox = new System.Windows.Forms.TextBox();
            this.buttonRestoreKey = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelShadows = new System.Windows.Forms.Label();
            this.labelRestored = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SecretTextBox
            // 
            this.SecretTextBox.Location = new System.Drawing.Point(12, 39);
            this.SecretTextBox.Multiline = true;
            this.SecretTextBox.Name = "SecretTextBox";
            this.SecretTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SecretTextBox.Size = new System.Drawing.Size(513, 127);
            this.SecretTextBox.TabIndex = 0;
            // 
            // ShadowsTextBox
            // 
            this.ShadowsTextBox.Location = new System.Drawing.Point(12, 303);
            this.ShadowsTextBox.Multiline = true;
            this.ShadowsTextBox.Name = "ShadowsTextBox";
            this.ShadowsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ShadowsTextBox.Size = new System.Drawing.Size(1026, 135);
            this.ShadowsTextBox.TabIndex = 1;
            // 
            // buttonGenerateKey
            // 
            this.buttonGenerateKey.Location = new System.Drawing.Point(12, 198);
            this.buttonGenerateKey.Name = "buttonGenerateKey";
            this.buttonGenerateKey.Size = new System.Drawing.Size(160, 61);
            this.buttonGenerateKey.TabIndex = 2;
            this.buttonGenerateKey.Text = "Сгенерировать ключ";
            this.buttonGenerateKey.UseVisualStyleBackColor = true;
            this.buttonGenerateKey.Click += new System.EventHandler(this.buttonGenerateKey_Click);
            // 
            // buttonGenerateShadows
            // 
            this.buttonGenerateShadows.Location = new System.Drawing.Point(365, 198);
            this.buttonGenerateShadows.Name = "buttonGenerateShadows";
            this.buttonGenerateShadows.Size = new System.Drawing.Size(160, 61);
            this.buttonGenerateShadows.TabIndex = 3;
            this.buttonGenerateShadows.Text = "Сгенерировать тени";
            this.buttonGenerateShadows.UseVisualStyleBackColor = true;
            this.buttonGenerateShadows.Click += new System.EventHandler(this.buttonGenerateShadows_Click);
            // 
            // RestoredSecretTextBox
            // 
            this.RestoredSecretTextBox.Location = new System.Drawing.Point(559, 106);
            this.RestoredSecretTextBox.Multiline = true;
            this.RestoredSecretTextBox.Name = "RestoredSecretTextBox";
            this.RestoredSecretTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RestoredSecretTextBox.Size = new System.Drawing.Size(479, 63);
            this.RestoredSecretTextBox.TabIndex = 4;
            // 
            // buttonRestoreKey
            // 
            this.buttonRestoreKey.Location = new System.Drawing.Point(559, 39);
            this.buttonRestoreKey.Name = "buttonRestoreKey";
            this.buttonRestoreKey.Size = new System.Drawing.Size(160, 61);
            this.buttonRestoreKey.TabIndex = 5;
            this.buttonRestoreKey.Text = "Восстановить ключ";
            this.buttonRestoreKey.UseVisualStyleBackColor = true;
            this.buttonRestoreKey.Click += new System.EventHandler(this.buttonRestoreKey_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(12, 23);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(218, 13);
            this.labelKey.TabIndex = 6;
            this.labelKey.Text = "Здесь отображен сгенерированный ключ";
            // 
            // labelShadows
            // 
            this.labelShadows.AutoSize = true;
            this.labelShadows.Location = new System.Drawing.Point(12, 287);
            this.labelShadows.Name = "labelShadows";
            this.labelShadows.Size = new System.Drawing.Size(125, 13);
            this.labelShadows.TabIndex = 7;
            this.labelShadows.Text = "Сгенерированные тени";
            // 
            // labelRestored
            // 
            this.labelRestored.AutoSize = true;
            this.labelRestored.Location = new System.Drawing.Point(760, 90);
            this.labelRestored.Name = "labelRestored";
            this.labelRestored.Size = new System.Drawing.Size(127, 13);
            this.labelRestored.TabIndex = 8;
            this.labelRestored.Text = "Восстановленный ключ";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(555, 187);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(376, 86);
            this.treeView1.TabIndex = 9;
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(956, 225);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(82, 48);
            this.buttonOpenFolder.TabIndex = 10;
            this.buttonOpenFolder.Text = "Открыть каталог";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 450);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.labelRestored);
            this.Controls.Add(this.labelShadows);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.buttonRestoreKey);
            this.Controls.Add(this.RestoredSecretTextBox);
            this.Controls.Add(this.buttonGenerateShadows);
            this.Controls.Add(this.buttonGenerateKey);
            this.Controls.Add(this.ShadowsTextBox);
            this.Controls.Add(this.SecretTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SecretTextBox;
        private System.Windows.Forms.TextBox ShadowsTextBox;
        private System.Windows.Forms.Button buttonGenerateKey;
        private System.Windows.Forms.Button buttonGenerateShadows;
        private System.Windows.Forms.TextBox RestoredSecretTextBox;
        private System.Windows.Forms.Button buttonRestoreKey;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelShadows;
        private System.Windows.Forms.Label labelRestored;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonOpenFolder;
    }
}

