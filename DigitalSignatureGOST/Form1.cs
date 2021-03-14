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

namespace DigitalSignatureGOST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonHash_Click(object sender, EventArgs e)
        {
            byte[] message = HexUtil.ToBytes(textBoxText.Text);
            textBoxCheck.Text = new BigInteger(message.Reverse().ToArray()).ToString("x");
            byte[] computedHash = GOSTHash.createHash(message, true);
            textBoxHash.Text = new BigInteger(computedHash.Reverse().ToArray()).ToString("x");
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            byte[] message = HexUtil.ToBytes(textBoxText.Text);
            textBoxCheck.Text = new BigInteger(message.Concat(new byte[] { 0 }).ToArray()).ToString("x");
            GOSTSignature sig = new GOSTSignature();
            byte[] sign = sig.createDigitalSignature(message);
            Console.WriteLine("-----------sign--------------------------");
            foreach (byte i in sign)
            {
                Console.Write(i.ToString("x"));
            }
            Console.WriteLine();


            textBoxSig.Text = new BigInteger(sign.Concat(new byte[] { 0 }).ToArray()).ToString("x");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GOSTSignature sig = new GOSTSignature();

            if (sig.checkDigitalSignature(new byte[] { }, new byte[] { }, new byte[][] { }))
            {
                MessageBox.Show("Ура");
            }
            else
            {
                MessageBox.Show("Не ура");
            }
        }
    }
}
