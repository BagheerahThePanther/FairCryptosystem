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
            // проверка на указание каталога
            if(pathToFolderTextBox.Text == "")
            {
                MessageBox.Show(this, "Не указан каталог, в который будет записан сгенерированный ключ. Укажите каталог и попробуйте снова", 
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // проверка на указание имени
            if (textBoxName.Text == "")
            {
                MessageBox.Show(this, "Не указано имя пользователя. Заполните все поля формы и попробуйте снова",
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // проверка на указание фамилии
            if (textBoxSurname.Text == "")
            {
                MessageBox.Show(this, "Не указана фамилия пользователя. Заполните все поля формы и попробуйте снова",
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // проверка на указание отчества
            if (textBoxPatronymic.Text == "")
            {
                MessageBox.Show(this, "Не указано отчество пользователя. Заполните все поля формы и попробуйте снова",
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // проверка на указание СНИЛС
            if (textBoxSNILS.Text == "")
            {
                MessageBox.Show(this, "Не указан СНИЛС. Заполните все поля формы и попробуйте снова",
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // проверка валидности СНИЛС
            try
            {
                SnilsValidator.SNILSValidate(textBoxSNILS.Text);
            }
            catch (Exception exception)
            {
                conDataBase.Close();
                MessageBox.Show(exception.Message);
                return;
            }

            if (!SnilsValidator.SNILSValidate(textBoxSNILS.Text))
            {
                MessageBox.Show(this, "СНИЛС не является действительным. Проверьте правильность набора символов.",
                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на отсутствие пользователя с данным СНИЛС
            try
            {
                conDataBase.Open();

                using (var cmd = new NpgsqlCommand("SELECT * FROM public.user WHERE snils = @Snils;", conDataBase))
                {
                    NpgsqlParameter Snils = cmd.CreateParameter();
                    Snils.ParameterName = "@Snils";
                    Snils.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    Snils.Value = textBoxSNILS.Text;
                    cmd.Parameters.Add(Snils);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show(this, "Пользователь с таким СНИЛС уже существует в базе данных.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                conDataBase.Close();
            }
            catch (Exception exception)
            {
                conDataBase.Close();
                MessageBox.Show(exception.Message);
            }

            ///////
            secret = SS.generateNumber(keyLengthInBytes);
            shadowArr = SS.computeShadows(secret, 3);
            byte[][] sig = new byte[3][];
            GOSTSignature sigGOST = new GOSTSignature();
            int[] sigIds = new int[3];

            for (int i = 0; i < 3; i++) {
                sig[i] = sigGOST.createDigitalSignature(shadowArr[i].Number.ToByteArray().Concat(shadowArr[i].Value.ToByteArray()).ToArray());

                try
                {
                    conNotarys[i].Open();
                    // запрос на добавление теней сгенерированного ключа
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

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // MessageBox.Show("ОК");
                                reader.Read();
                                sigIds[i] = reader.GetInt32(0);
                            }
                            else
                            {
                                throw new Exception("По какой-либо причине тень не была добавлена в базу данных. Процесс регистрации отменен.");
                            }
                        }
                    }
                    conNotarys[i].Close();
                }
                catch (Exception exception)
                {
                    conNotarys[i].Close();
                    MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                conDataBase.Open();
                // запрос на добавление нового пользователя
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
                        File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName + textBoxSNILS.Text, secret.ToByteArray()); 

                        MessageBox.Show(this, "Пользователь успешно зарегистрирован. Вы можете найти сгенерированный ключ по следующему пути: " + pathToFolderTextBox.Text + keyFileName + textBoxSNILS.Text, 
                                                "Регистрация завершена", MessageBoxButtons.OK);
                        // this.Close();
                        return;
                    }
                    else
                    {
                        // удалить тени из соответствующих бд, если пользователь не создался
                        for (int i = 0; i < 3; i++)
                        {
                            sig[i] = sigGOST.createDigitalSignature(shadowArr[i].Number.ToByteArray().Concat(shadowArr[i].Value.ToByteArray()).ToArray());

                            try
                            {
                                conNotarys[i].Open();
                                // запрос на добавление теней сгенерированного ключа
                                using (var cmd1 = new NpgsqlCommand("DELETE FROM public.shadow WHERE id = @Id;", conNotarys[i]))
                                {
                                    NpgsqlParameter Id = cmd1.CreateParameter();
                                    Id.ParameterName = "@Id";
                                    Id.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                                    Id.Value = sig[i];
                                    cmd1.Parameters.Add(Id);

                                    if (!(cmd1.ExecuteNonQuery() > 0))
                                    {
                                        throw new Exception("Не удается удалить записанные тени (id = " + sig[i] + ")");
                                    }
                                }
                                conNotarys[i].Close();
                            }
                            catch (Exception exception)
                            {
                                conNotarys[i].Close();
                                MessageBox.Show(this, exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        if (conDataBase.State == ConnectionState.Open) conDataBase.Close();
                        throw new Exception("По какой-либо причине пользователь не был добавлен в базу данных. Процесс регистрации отменен.");
                    }
                }
            }
            catch (Exception exception)
            {
                if (conDataBase.State == ConnectionState.Open) conDataBase.Close();
                MessageBox.Show(exception.ToString());
            }

        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSurname.Text == "")
            {
                labelSurname.Visible = true;
            }
            else
            {
                labelSurname.Visible = false;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                labelName.Visible = true;
            }
            else
            {
                labelName.Visible = false;
            }
        }

        private void textBoxPatronymic_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPatronymic.Text == "")
            {
                labelPatronymic.Visible = true;
            }
            else
            {
                labelPatronymic.Visible = false;
            }
        }

        private void textBoxSNILS_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSNILS.Text == "")
            {
                labelSNILS.Visible = true;
            }
            else
            {
                labelSNILS.Visible = false;
            }
        }

        private void labelSurname_Click(object sender, EventArgs e)
        {
            textBoxSurname.Focus();
        }

        private void labelName_Click(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }

        private void labelPatronymic_Click(object sender, EventArgs e)
        {
            textBoxPatronymic.Focus();
        }

        private void labelSNILS_Click(object sender, EventArgs e)
        {
            textBoxSNILS.Focus();
        }
    }
}
