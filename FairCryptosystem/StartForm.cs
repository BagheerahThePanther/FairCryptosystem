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
using System.Security.Cryptography;
using Npgsql;

namespace FairCryptosystem
{
    public partial class StartForm : Form
    {
        NpgsqlConnection conDataBase = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("conStringKDC"));
        string notary1ConString = ConfigurationManager.AppSettings.Get("notary1ConString");
        string notary2ConString = ConfigurationManager.AppSettings.Get("notary2ConString");
        string notary3ConString = ConfigurationManager.AppSettings.Get("notary3ConString");


        NpgsqlConnection[] conNotarys = new NpgsqlConnection[3]
        {
            new NpgsqlConnection(ConfigurationManager.AppSettings.Get("notary1ConString")),
            new NpgsqlConnection(ConfigurationManager.AppSettings.Get("notary2ConString")),
            new NpgsqlConnection(ConfigurationManager.AppSettings.Get("notary3ConString"))
        };
        public StartForm()
        {
            InitializeComponent();

            try
            {
                conDataBase.Open();
                conDataBase.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

        }


        private uint keyLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("KeyLengthInBytes"));
        private string keyFileName = ConfigurationManager.AppSettings.Get("KeyFileName");
        private string shadowFileName = ConfigurationManager.AppSettings.Get("ShadowFileName");
        private uint shadowNumberLengthInBytes = Convert.ToUInt32(ConfigurationManager.AppSettings.Get("ShadowNumberLengthInBytes"));


        private readonly SecretSharing SS = new SecretSharing();
        private BigInteger secret;
        private Shadow[] shadowArr;

        public NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
        


        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            pathToFolderTextBox.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\";
        }

        

        private void buttonNext_Click(object sender, EventArgs e)
        {
            secret = SS.generateNumber(keyLengthInBytes);
            shadowArr = SS.computeShadows(secret, 3);
            byte[][] sig = new byte[3][];
            GOSTSignature sigGOST = new GOSTSignature();

            for (int i = 0; i < 3; i++) {
                sig[i] = sigGOST.createDigitalSignature(shadowArr[i].Number.ToByteArray().Concat(shadowArr[i].Value.ToByteArray()).ToArray());

                try
                {
                    conNotarys[i].Open();

                    using (var cmd = new NpgsqlCommand("INSERT INTO public.shadow (id, number, value, signature, snils) VALUES((COALESCE((SELECT id FROM public.shadow ORDER BY id DESC LIMIT 1), 0) + 1)::integer, " +
                        "@Number, @Value, @Signature, @Snils) returning id;", conNotarys[i]))
                    {
                        NpgsqlParameter snils = cmd.CreateParameter();
                        snils.ParameterName = "@Snils";
                        snils.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                        snils.Value = textBoxSNILS.Text;
                        cmd.Parameters.Add(snils);

                        NpgsqlParameter number = cmd.CreateParameter();
                        number.ParameterName = "@Number";
                        number.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                        number.Value = shadowArr[i].Number.ToByteArray();
                        cmd.Parameters.Add(number);

                        NpgsqlParameter value = cmd.CreateParameter();
                        value.ParameterName = "@Value";
                        value.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                        value.Value = shadowArr[i].Value.ToByteArray();
                        cmd.Parameters.Add(value);

                        NpgsqlParameter signature = cmd.CreateParameter();
                        signature.ParameterName = "@Signature";
                        signature.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                        signature.Value = sig[i];
                        cmd.Parameters.Add(signature);

                        int numberOfRows = cmd.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                           // MessageBox.Show("ОК");
                        }
                        else
                        {
                            MessageBox.Show(this, "Вы не должны этого видеть. Программа работает неправильно", "Ошибка при отправке запроса в базу данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    conNotarys[i].Close();
                }
                catch (Exception exception)
                {
                    conNotarys[i].Close();
                    MessageBox.Show(exception.Message);
                }
            }


            try
            {
                conDataBase.Open();

                using (var cmd = new NpgsqlCommand("INSERT INTO public.user (id, name, surname, patronymic, snils, shadow1_con_string, shadow2_con_string, shadow3_con_string) VALUES((COALESCE((SELECT id FROM public.user ORDER BY id DESC LIMIT 1), 0) + 1)::integer, " +
                    "@Name, @Surname, @Patronymic, @Snils, @Shadow1, @Shadow2, @Shadow3) returning id;", conDataBase))
                {
                    NpgsqlParameter snils = cmd.CreateParameter();
                    snils.ParameterName = "@Snils";
                    snils.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    snils.Value = textBoxSNILS.Text;
                    cmd.Parameters.Add(snils);

                    NpgsqlParameter name = cmd.CreateParameter();
                    name.ParameterName = "@Name";
                    name.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    name.Value = textBoxName.Text;
                    cmd.Parameters.Add(name);

                    NpgsqlParameter surname = cmd.CreateParameter();
                    surname.ParameterName = "@Surname";
                    surname.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    surname.Value = textBoxSurname.Text;
                    cmd.Parameters.Add(surname);

                    NpgsqlParameter patronymic = cmd.CreateParameter();
                    patronymic.ParameterName = "@Patronymic";
                    patronymic.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    patronymic.Value = textBoxPatronymic.Text;
                    cmd.Parameters.Add(patronymic);

                    NpgsqlParameter shadow1 = cmd.CreateParameter();
                    shadow1.ParameterName = "@Shadow1";
                    shadow1.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    shadow1.Value = notary1ConString;
                    cmd.Parameters.Add(shadow1);

                    NpgsqlParameter shadow2 = cmd.CreateParameter();
                    shadow2.ParameterName = "@Shadow2";
                    shadow2.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    shadow2.Value = notary2ConString;
                    cmd.Parameters.Add(shadow2);

                    NpgsqlParameter shadow3 = cmd.CreateParameter();
                    shadow3.ParameterName = "@Shadow3";
                    shadow3.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    shadow3.Value = notary3ConString;
                    cmd.Parameters.Add(shadow3);

                    int numberOfRows = cmd.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        conDataBase.Close();
                        File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName, secret.ToByteArray()); 

                        MessageBox.Show("Пользователь успешно зарегистрирован");
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(this, "Проверьте правильность ввода данных", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(conDataBase.State == ConnectionState.Open) conDataBase.Close();
            }
            catch (Exception exception)
            {
                if (conDataBase.State == ConnectionState.Open) conDataBase.Close();
                MessageBox.Show(exception.ToString());
            }

        }
    }
}
