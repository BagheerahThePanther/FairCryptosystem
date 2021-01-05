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

namespace FairCryptosystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            SecretSharing SS = new SecretSharing();
            SecretTextBox.Text = SS.generateNumber(32).ToString("X", bigIntegerFormatter);
        }

        private void buttonGenerateShadows_Click(object sender, EventArgs e)
        {

        }

        private void buttonRestoreKey_Click(object sender, EventArgs e)
        {

        }
    }
}
