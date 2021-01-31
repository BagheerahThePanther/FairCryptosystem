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

namespace FairCryptosystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private uint keyLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("KeyLengthInBytes"));
        private readonly SecretSharing SS = new SecretSharing();
        private BigInteger secret;
        private Shadow[] shadowArr;

        public NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            secret = SS.generateNumber(keyLengthInBytes);
            SecretTextBox.Text = secret.ToString("X", bigIntegerFormatter);
        }

        private void buttonGenerateShadows_Click(object sender, EventArgs e)
        {
            Shadow[] shadows = SS.computeShadows(secret, 3);
            shadowArr = new Shadow[3];
            for(int i = 0; i < 3; i++)
            {
                shadowArr[i] = new Shadow(shadows[i].Number, shadows[i].Value);
            }
            ShadowsTextBox.Text = "";
            foreach(Shadow shadow in shadows)
            {
                ShadowsTextBox.Text += shadow.Number.ToString() + " " + shadow.Value.ToString("X", bigIntegerFormatter) + Environment.NewLine;
            }
        }

        private void buttonRestoreKey_Click(object sender, EventArgs e)
        {
            BigInteger result = SS.restoreSecret(shadowArr);
            RestoredSecretTextBox.Text = result.ToString("X", bigIntegerFormatter);
        }
    }
}
