
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
            this.textBoxShadow1 = new System.Windows.Forms.TextBox();
            this.buttonShadow1 = new System.Windows.Forms.Button();
            this.labelShadow1 = new System.Windows.Forms.Label();
            this.labelShadow2 = new System.Windows.Forms.Label();
            this.buttonShadow2 = new System.Windows.Forms.Button();
            this.textBoxShadow2 = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.buttonKey = new System.Windows.Forms.Button();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBoxShadow1
            // 
            this.textBoxShadow1.Location = new System.Drawing.Point(12, 25);
            this.textBoxShadow1.Name = "textBoxShadow1";
            this.textBoxShadow1.Size = new System.Drawing.Size(314, 20);
            this.textBoxShadow1.TabIndex = 0;
            // 
            // buttonShadow1
            // 
            this.buttonShadow1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonShadow1.Location = new System.Drawing.Point(332, 23);
            this.buttonShadow1.Name = "buttonShadow1";
            this.buttonShadow1.Size = new System.Drawing.Size(75, 23);
            this.buttonShadow1.TabIndex = 1;
            this.buttonShadow1.Text = "Обзор";
            this.buttonShadow1.UseVisualStyleBackColor = true;
            this.buttonShadow1.Click += new System.EventHandler(this.buttonShadow1_Click);
            // 
            // labelShadow1
            // 
            this.labelShadow1.AutoSize = true;
            this.labelShadow1.ForeColor = System.Drawing.Color.Red;
            this.labelShadow1.Location = new System.Drawing.Point(12, 9);
            this.labelShadow1.Name = "labelShadow1";
            this.labelShadow1.Size = new System.Drawing.Size(149, 13);
            this.labelShadow1.TabIndex = 2;
            this.labelShadow1.Text = "Укажите папку первой тени";
            // 
            // labelShadow2
            // 
            this.labelShadow2.AutoSize = true;
            this.labelShadow2.ForeColor = System.Drawing.Color.Red;
            this.labelShadow2.Location = new System.Drawing.Point(12, 49);
            this.labelShadow2.Name = "labelShadow2";
            this.labelShadow2.Size = new System.Drawing.Size(148, 13);
            this.labelShadow2.TabIndex = 5;
            this.labelShadow2.Text = "Укажите папку второй тени";
            // 
            // buttonShadow2
            // 
            this.buttonShadow2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonShadow2.Location = new System.Drawing.Point(332, 63);
            this.buttonShadow2.Name = "buttonShadow2";
            this.buttonShadow2.Size = new System.Drawing.Size(75, 23);
            this.buttonShadow2.TabIndex = 4;
            this.buttonShadow2.Text = "Обзор";
            this.buttonShadow2.UseVisualStyleBackColor = true;
            this.buttonShadow2.Click += new System.EventHandler(this.buttonShadow2_Click);
            // 
            // textBoxShadow2
            // 
            this.textBoxShadow2.Location = new System.Drawing.Point(12, 65);
            this.textBoxShadow2.Name = "textBoxShadow2";
            this.textBoxShadow2.Size = new System.Drawing.Size(314, 20);
            this.textBoxShadow2.TabIndex = 3;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelKey.Location = new System.Drawing.Point(12, 91);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(261, 13);
            this.labelKey.TabIndex = 8;
            this.labelKey.Text = "Укажите путь записи восстанавливаемого ключа";
            // 
            // buttonKey
            // 
            this.buttonKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonKey.Location = new System.Drawing.Point(332, 105);
            this.buttonKey.Name = "buttonKey";
            this.buttonKey.Size = new System.Drawing.Size(75, 23);
            this.buttonKey.TabIndex = 7;
            this.buttonKey.Text = "Обзор";
            this.buttonKey.UseVisualStyleBackColor = true;
            this.buttonKey.Click += new System.EventHandler(this.buttonKey_Click);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(12, 107);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(314, 20);
            this.textBoxKey.TabIndex = 6;
            // 
            // buttonStart
            // 
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(413, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(87, 104);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Восстановить ключ";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 139);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.buttonKey);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.labelShadow2);
            this.Controls.Add(this.buttonShadow2);
            this.Controls.Add(this.textBoxShadow2);
            this.Controls.Add(this.labelShadow1);
            this.Controls.Add(this.buttonShadow1);
            this.Controls.Add(this.textBoxShadow1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Восстановление ключа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxShadow1;
        private System.Windows.Forms.Button buttonShadow1;
        private System.Windows.Forms.Label labelShadow1;
        private System.Windows.Forms.Label labelShadow2;
        private System.Windows.Forms.Button buttonShadow2;
        private System.Windows.Forms.TextBox textBoxShadow2;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Button buttonKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

