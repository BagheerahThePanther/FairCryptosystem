
namespace DigitalSignatureGOST
{
    partial class Form1
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
            this.textBoxSK = new System.Windows.Forms.TextBox();
            this.textBoxPK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGenerateKeys = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxText2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHash = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSig2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPK2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSK2 = new System.Windows.Forms.TextBox();
            this.buttonHash = new System.Windows.Forms.Button();
            this.buttonSign = new System.Windows.Forms.Button();
            this.textBoxCheck = new System.Windows.Forms.TextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSK
            // 
            this.textBoxSK.Location = new System.Drawing.Point(12, 33);
            this.textBoxSK.Name = "textBoxSK";
            this.textBoxSK.Size = new System.Drawing.Size(224, 20);
            this.textBoxSK.TabIndex = 0;
            // 
            // textBoxPK
            // 
            this.textBoxPK.Location = new System.Drawing.Point(15, 92);
            this.textBoxPK.Name = "textBoxPK";
            this.textBoxPK.Size = new System.Drawing.Size(221, 20);
            this.textBoxPK.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Секретный ключ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Открытый ключ";
            // 
            // buttonGenerateKeys
            // 
            this.buttonGenerateKeys.Location = new System.Drawing.Point(122, 59);
            this.buttonGenerateKeys.Name = "buttonGenerateKeys";
            this.buttonGenerateKeys.Size = new System.Drawing.Size(114, 23);
            this.buttonGenerateKeys.TabIndex = 4;
            this.buttonGenerateKeys.Text = "Сгенерить ключи";
            this.buttonGenerateKeys.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Подписываемый текст";
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(12, 271);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(221, 86);
            this.textBoxText.TabIndex = 5;
            this.textBoxText.Text = "fbe2e5f0eee3c820fbeafaebef20fffbf0e1e0f0f520e0ed20e8ece0ebe5f0f2f120fff0eeec20f12" +
    "0faf2fee5e2202ce8f6f3ede220e8e6eee1e8f0f2d1202ce8f0f2e5e220e5d1";
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Проверяемый текст";
            // 
            // textBoxText2
            // 
            this.textBoxText2.Location = new System.Drawing.Point(555, 33);
            this.textBoxText2.Name = "textBoxText2";
            this.textBoxText2.Size = new System.Drawing.Size(221, 20);
            this.textBoxText2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Вычисленный хэш";
            // 
            // textBoxHash
            // 
            this.textBoxHash.Location = new System.Drawing.Point(299, 271);
            this.textBoxHash.Name = "textBoxHash";
            this.textBoxHash.Size = new System.Drawing.Size(435, 20);
            this.textBoxHash.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Вычисленная подпись";
            // 
            // textBoxSig
            // 
            this.textBoxSig.Location = new System.Drawing.Point(299, 328);
            this.textBoxSig.Name = "textBoxSig";
            this.textBoxSig.Size = new System.Drawing.Size(221, 20);
            this.textBoxSig.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(552, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Проверяемая подпись";
            // 
            // textBoxSig2
            // 
            this.textBoxSig2.Location = new System.Drawing.Point(555, 90);
            this.textBoxSig2.Name = "textBoxSig2";
            this.textBoxSig2.Size = new System.Drawing.Size(221, 20);
            this.textBoxSig2.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(552, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Открытый ключ";
            // 
            // textBoxPK2
            // 
            this.textBoxPK2.Location = new System.Drawing.Point(555, 147);
            this.textBoxPK2.Name = "textBoxPK2";
            this.textBoxPK2.Size = new System.Drawing.Size(221, 20);
            this.textBoxPK2.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Секретный ключ";
            // 
            // textBoxSK2
            // 
            this.textBoxSK2.Location = new System.Drawing.Point(9, 400);
            this.textBoxSK2.Name = "textBoxSK2";
            this.textBoxSK2.Size = new System.Drawing.Size(224, 20);
            this.textBoxSK2.TabIndex = 17;
            // 
            // buttonHash
            // 
            this.buttonHash.Location = new System.Drawing.Point(401, 242);
            this.buttonHash.Name = "buttonHash";
            this.buttonHash.Size = new System.Drawing.Size(114, 23);
            this.buttonHash.TabIndex = 19;
            this.buttonHash.Text = "Вычислить хэш";
            this.buttonHash.UseVisualStyleBackColor = true;
            this.buttonHash.Click += new System.EventHandler(this.buttonHash_Click);
            // 
            // buttonSign
            // 
            this.buttonSign.Location = new System.Drawing.Point(325, 354);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(154, 23);
            this.buttonSign.TabIndex = 20;
            this.buttonSign.Text = "Вычислить подпись";
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // textBoxCheck
            // 
            this.textBoxCheck.Location = new System.Drawing.Point(15, 147);
            this.textBoxCheck.Multiline = true;
            this.textBoxCheck.Name = "textBoxCheck";
            this.textBoxCheck.Size = new System.Drawing.Size(221, 86);
            this.textBoxCheck.TabIndex = 21;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(593, 325);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(114, 23);
            this.buttonCheck.TabIndex = 22;
            this.buttonCheck.Text = "Проверить подпись";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.textBoxCheck);
            this.Controls.Add(this.buttonSign);
            this.Controls.Add(this.buttonHash);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxSK2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPK2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSig2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSig);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxText2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.buttonGenerateKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPK);
            this.Controls.Add(this.textBoxSK);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSK;
        private System.Windows.Forms.TextBox textBoxPK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGenerateKeys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxText2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHash;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSig2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPK2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSK2;
        private System.Windows.Forms.Button buttonHash;
        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.TextBox textBoxCheck;
        private System.Windows.Forms.Button buttonCheck;
    }
}

