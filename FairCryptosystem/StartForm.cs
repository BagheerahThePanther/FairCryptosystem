using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace FairCryptosystem
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private uint keyLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("KeyLengthInBytes"));
        private string keyFileName = ConfigurationManager.AppSettings.Get("KeyFileName");
        private string shadowFileName = ConfigurationManager.AppSettings.Get("ShadowFileName");
        private uint shadowNumberLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("ShadowNumberLengthInBytes"));


        private readonly SecretSharing SS = new SecretSharing();
        private BigInteger secret;
        private Shadow[] shadowArr;

        public NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
        

        private void buttonRestoreKey_Click(object sender, EventArgs e)
        {
            BigInteger result = SS.restoreSecret(shadowArr);
            pathToFolderTextBox.Text = result.ToString("X", bigIntegerFormatter);
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            pathToFolderTextBox.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\";
        }

        private void buttonNext_ClickKey(object sender, EventArgs e)
        {
            secret = SS.generateNumber(keyLengthInBytes);
            File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName, secret.ToByteArray());
            changeToShadow1();
        }

        
        private void buttonShadow1_Click(object sender, EventArgs e)
        {
            Shadow[] shadows = SS.computeShadows(secret, 3);
            shadowArr = new Shadow[3];
            for (int i = 0; i < 3; i++)
            {
                shadowArr[i] = new Shadow(shadows[i].Number, shadows[i].Value);
            }
            File.WriteAllBytes(pathToFolderTextBox.Text + shadowFileName + "_Number", shadowArr[0].Number.ToByteArray());
            File.WriteAllBytes(pathToFolderTextBox.Text + shadowFileName + "_Value", shadowArr[0].Value.ToByteArray());
            changeToShadow2();
        }

        private void buttonShadow2_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(pathToFolderTextBox.Text + shadowFileName + "_Number", shadowArr[1].Number.ToByteArray());
            File.WriteAllBytes(pathToFolderTextBox.Text + shadowFileName + "_Value", shadowArr[1].Value.ToByteArray());
            changeToShadow3();
        }

        private void buttonShadow3_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(pathToFolderTextBox.Text + shadowFileName + "_Number", shadowArr[2].Number.ToByteArray());
            File.WriteAllBytes(pathToFolderTextBox.Text + shadowFileName + "_Value", shadowArr[2].Value.ToByteArray());
        }

        private void changeToShadow1()
        {
            this.Text = "Запись первой тени";
            labelPathToFolder.Text = "Укажите путь к носителю первой тени";
            labelNext.Text = "Нажмите \"Далее\" чтобы записать \nпервую тень на выбранный носитель";
            buttonKey.Hide();
            this.AcceptButton = buttonShadow1;
            pathToFolderTextBox.Text = "";
            buttonShadow1.Show();
        }
        private void changeToShadow2()
        {
            this.Text = "Запись второй тени";
            labelPathToFolder.Text = "Укажите путь к носителю второй тени";
            labelNext.Text = "Нажмите \"Далее\" чтобы записать \nвторую тень на выбранный носитель";
            buttonShadow1.Hide();
            this.AcceptButton = buttonShadow2;
            pathToFolderTextBox.Text = "";
            buttonShadow2.Show();
        }
        private void changeToShadow3()
        {
            this.Text = "Запись третьей тени";
            labelPathToFolder.Text = "Укажите путь к носителю третьей тени";
            labelNext.Text = "Нажмите \"Далее\" чтобы записать \nтретью тень на выбранный носитель";
            buttonShadow2.Hide();
            this.AcceptButton = buttonShadow3;
            pathToFolderTextBox.Text = "";
            buttonShadow3.Show();
        }

    }
}
