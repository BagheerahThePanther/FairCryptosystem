using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;
using System.Numerics;
using System.IO;
using System.Security.Cryptography;

namespace KeyRestoration
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private RSA rsa = RSA.Create();

        private string keyFileName = ConfigurationManager.AppSettings.Get("KeyFileName");
        private string shadowFileName = ConfigurationManager.AppSettings.Get("ShadowFileName");

        private readonly SecretSharing SS = new SecretSharing();
        private BigInteger secret;
        private Shadow[] shadowArr;

        private void buttonShadow1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            textBoxShadow1.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\";
        }

        private void buttonShadow2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            textBoxShadow2.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\";
        }

        private void buttonKey_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            textBoxKey.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            /// Проверка на указание путей к файлам
            if(textBoxShadow1.Text == "")
            {
                MessageBox.Show(this, "Не указан путь к первой тени", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxShadow2.Text == "")
            {
                MessageBox.Show(this, "Не указан путь ко второй тени", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxKey.Text == "")
            {
                MessageBox.Show(this, "Не указан путь к ключу", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /////
            ///

            rsa.FromXmlString(File.ReadAllText("D:\\public"));
            Console.WriteLine(rsa.ToXmlString(false));
            ///
            shadowArr = new Shadow[2];
            shadowArr[0] = readShadowFromFolder(textBoxShadow1.Text);
            shadowArr[1] = readShadowFromFolder(textBoxShadow2.Text);

            SHA256 sha256Hash = SHA256.Create();

            RSAPKCS1SignatureDeformatter rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
            rsaDeformatter.SetHashAlgorithm("SHA256");
            if (rsaDeformatter.VerifySignature(sha256Hash.ComputeHash(shadowArr[0].ToByteArray()), File.ReadAllBytes("D:\\sig1")))
            {
                Console.WriteLine("The signature 1 is valid.");
            }
            else
            {
                Console.WriteLine("The signature 1 is not valid.");
            }

            rsaDeformatter.SetHashAlgorithm("SHA256");
            if (rsaDeformatter.VerifySignature(sha256Hash.ComputeHash(shadowArr[1].ToByteArray()), File.ReadAllBytes("D:\\sig2")))
            {
                Console.WriteLine("The signature 2 is valid.");
            }
            else
            {
                Console.WriteLine("The signature 2 is not valid.");
            }


            secret = SS.restoreSecret(shadowArr);
            File.WriteAllBytes(textBoxKey.Text + keyFileName, secret.ToByteArray());
        }
        private Shadow readShadowFromFolder(string pathToFolder)
        {
            Shadow shadow = new Shadow
            {
                Number = new BigInteger(File.ReadAllBytes(pathToFolder + shadowFileName + "_Number")),
                Value = new BigInteger(File.ReadAllBytes(pathToFolder + shadowFileName + "_Value"))
            };
            return shadow;
        }
    }
}
