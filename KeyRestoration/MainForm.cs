using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Numerics;
using System.IO;
using Npgsql;

namespace KeyRestoration
{
    public partial class MainForm : Form
    {
        NpgsqlConnection conDataBase = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("conString"));
        private string keyFileName = ConfigurationManager.AppSettings.Get("KeyFileName");

        public MainForm()
        {
            InitializeComponent();
            comboBoxUserInfo.DisplayMember = "Text";
            comboBoxUserInfo.ValueMember = "Value";
            textBoxLogin.Text = "login";
            textBoxPassword.Text = "password";
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

        private DataTable dataTable = new DataTable();
        private List<string> tableNames = new List<string>();

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            changeToRegister();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            // проверка на указание логина
            if (textBoxLogin.Text == "")
            {
                MessageBox.Show(this, "Не указан логин. Заполните все поля формы и попробуйте снова",
                                        "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на указание пароля
            if (textBoxPassword.Text == "")
            {
                MessageBox.Show(this, "Не указан пароль. Заполните все поля формы и попробуйте снова",
                                        "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conDataBase.Open();

                using (var cmd = new NpgsqlCommand("SELECT name, surname, patronymic FROM public.investigator WHERE login = @Login AND password = @Password;", conDataBase))
                {
                    NpgsqlParameter login = cmd.CreateParameter();
                    login.ParameterName = "@Login";
                    login.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    login.Value = textBoxLogin.Text;
                    cmd.Parameters.Add(login);

                    NpgsqlParameter pass = cmd.CreateParameter();
                    pass.ParameterName = "@Password";
                    pass.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                    pass.Value = GOSTHash.createHash(Encoding.UTF8.GetBytes(textBoxPassword.Text), true);
                    cmd.Parameters.Add(pass);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            changeToMain(reader.GetString(1) + " " + reader.GetString(0) + " " + reader.GetString(2));
                        }
                        else
                        {
                            MessageBox.Show(this, "Проверьте правильность ввода логина и пароля и попробуйте снова", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void changeToRegister()
        {
            changeLoginVisibility(false);
            changeMainVisibility(false);
            changeRegisterVisibility(true);
            clearAllFields();
            Text = "Восстановление ключа: регистрация";
        }
        private void changeToMain(string userName)
        {
            changeLoginVisibility(false);
            changeMainVisibility(true);
            changeRegisterVisibility(false);
            clearAllFields();
            Text = "Восстановление ключа: текущий пользователь - " + userName;
        }

        private void changeToLogin()
        {
            changeLoginVisibility(true);
            changeMainVisibility(false);
            changeRegisterVisibility(false);
            clearAllFields();
            Text = "Восстановление ключа: авторизация";
        }
        private void changeRegisterVisibility(bool isVisible)
        {
            label3.Visible = isVisible;
            label4.Visible = isVisible;
            label5.Visible = isVisible;
            labelName.Visible = isVisible;
            labelSurname.Visible = isVisible;
            labelPatronymic.Visible = isVisible;

            textBoxName.Visible = isVisible;
            textBoxSurname.Visible = isVisible;
            textBoxPatronymic.Visible = isVisible;
            textBoxNewLogin.Visible = isVisible;
            textBoxNewPass.Visible = isVisible;
            buttonBack.Visible = isVisible;
            buttonRegisterNew.Visible = isVisible;
          }

        private void changeMainVisibility(bool isVisible)
        {
            labelShadow1.Visible = isVisible;
            labelShadow2.Visible = isVisible;
            labelPathToFolder.Visible = isVisible;
            comboBoxUserInfo.Visible = isVisible;
            textBoxCaseNumber.Visible = isVisible;
            pathToFolderTextBox.Visible = isVisible;
            buttonOpenFolder.Visible = isVisible;
            buttonStart.Visible = isVisible;
            buttonExit.Visible = isVisible;
        }

        private void changeLoginVisibility(bool isVisible)
        {
            label6.Visible = isVisible;
            label7.Visible = isVisible;
            label1.Visible = isVisible;
            label2.Visible = isVisible;
            textBoxLogin.Visible = isVisible;
            textBoxPassword.Visible = isVisible;
            buttonRegister.Visible = isVisible;
            buttonSignIn.Visible = isVisible;
        }

        private void clearAllFields()
        {
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxPatronymic.Text = "";
            textBoxNewLogin.Text = "";
            textBoxNewPass.Text = "";
            comboBoxUserInfo.Text = "";
            textBoxCaseNumber.Text = "";
            pathToFolderTextBox.Text = "";
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            changeToLogin();
        }

        private void buttonRegisterNew_Click(object sender, EventArgs e)
        {
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

            // проверка на указание логина
            if (textBoxNewLogin.Text == "")
            {
                MessageBox.Show(this, "Не указан логин пользователя. Заполните все поля формы и попробуйте снова",
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на указание пароля
            if (textBoxNewPass.Text == "")
            {
                MessageBox.Show(this, "Не указан пароль пользователя. Заполните все поля формы и попробуйте снова",
                                        "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conDataBase.Open();

                using (var cmd = new NpgsqlCommand("INSERT INTO public.investigator (id, name, surname, patronymic, login, password) VALUES((COALESCE((SELECT id FROM public.investigator ORDER BY id DESC LIMIT 1), 0) + 1)::integer, @Name, @Surname, @Patronymic, @Login, @Password) returning id;", conDataBase))
                {
                    NpgsqlParameter login = cmd.CreateParameter();
                    login.ParameterName = "@Login";
                    login.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    login.Value = textBoxNewLogin.Text;
                    cmd.Parameters.Add(login);

                    NpgsqlParameter pass = cmd.CreateParameter();
                    pass.ParameterName = "@Password";
                    pass.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
                    pass.Value = GOSTHash.createHash(Encoding.UTF8.GetBytes(textBoxNewPass.Text), true);
                    cmd.Parameters.Add(pass);

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

                    int numberOfRows = cmd.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        changeToLogin();
                    }
                    else
                    {
                        MessageBox.Show(this, "Проверьте правильность ввода данных", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                conDataBase.Close();
            }
            catch (Exception exception)
            {
                conDataBase.Close();
                MessageBox.Show(exception.Message);
                return;
            }
            changeToLogin();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            changeToLogin();
        }

        private void textBoxNewPass_TextChanged(object sender, EventArgs e) {}

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // проверка на указание пользователя
            if (comboBoxUserInfo.Text == "" || comboBoxUserInfo.SelectedItem == null)
            {
                MessageBox.Show(this, "Не указан пользователь. Заполните все поля формы и попробуйте снова",
                                        "Ошибка восстановления ключа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на указание номера дела
            if (textBoxCaseNumber.Text == "")
            {
                MessageBox.Show(this, "Не указан номер дела. Заполните все поля формы и попробуйте снова",
                                        "Ошибка восстановления ключа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // проверка на указание каталога
            if (pathToFolderTextBox.Text == "")
            {
                MessageBox.Show(this, "Не указан каталог восстанавливаемого ключа. Заполните все поля формы и попробуйте снова",
                                        "Ошибка восстановления ключа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = (comboBoxUserInfo.SelectedItem as dynamic).Value;
            string[] shadowConString = new string[3];
            string snils = "";
            int numberOfCorrectShadows = 0;
            bool[] isShadowCorrect = new bool[3] { false, false, false};
            try
            {
                conDataBase.Open();

                using (var cmd = new NpgsqlCommand("SELECT id, shadow1_con_string, shadow2_con_string, shadow3_con_string, snils FROM public.user WHERE id = @Id;", conDataBase))
                {
                    NpgsqlParameter Id = cmd.CreateParameter();
                    Id.ParameterName = "@Id";
                    Id.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer;
                    Id.Value = id;
                    cmd.Parameters.Add(Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            shadowConString[0] = reader.GetString(1);
                            shadowConString[1] = reader.GetString(2);
                            shadowConString[2] = reader.GetString(3);
                            snils = reader.GetString(4);
                        }
                        else
                        {
                            MessageBox.Show(this, "Чет не так работает, хз", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            Shadow[] shadows = new Shadow[3];
            byte[][] signatures = new byte[3][];
            
            for(int i = 0; i < 3; i++)
            {
                NpgsqlConnection conDataBaseShadow = new NpgsqlConnection(shadowConString[i]);

                try
                {
                    conDataBaseShadow.Open();

                    using (var cmd = new NpgsqlCommand("SELECT id, number, value, signature FROM public.shadow WHERE snils = @Snils;", conDataBaseShadow))
                    {
                        NpgsqlParameter Snils = cmd.CreateParameter();
                        Snils.ParameterName = "@Snils";
                        Snils.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                        Snils.Value = snils;
                        cmd.Parameters.Add(Snils);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();

                                shadows[i] = new Shadow(new BigInteger(((byte[])reader[1]).Concat(new byte[] { 0 }).ToArray()), new BigInteger(((byte[])reader[2]).Concat(new byte[] { 0 }).ToArray()));
                                signatures[i] = (byte[])reader[3];

                                // Чекаем подписи

                                GOSTSignature sig = new GOSTSignature();
                                if (sig.checkDigitalSignature(shadows[i].Number.ToByteArray().Concat(shadows[i].Value.ToByteArray()).ToArray(), signatures[i]))
                                {
                                    numberOfCorrectShadows++;
                                    isShadowCorrect[i] = true;
                                    /*DialogResult dialogResult = MessageBox.Show(this, "Тень номер " + (i + 1) + " не проходит проверку подписи. Все равно продолжить процесс восстановления?", "Подпись неверна", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                    if (dialogResult == DialogResult.No)
                                    {
                                        MessageBox.Show(this, "Восстановление ключа прервано по причине неверной подписи тени.", "Операция прервана", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }*/
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Чет не так работает, хз", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                    conDataBaseShadow.Close();
                }
                catch (Exception exception)
                {
                    conDataBaseShadow.Close();
                    MessageBox.Show(exception.Message);
                }

            }

            if(numberOfCorrectShadows == 2)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Тень номер " + (Array.FindIndex(isShadowCorrect, value => value == false) + 1) + " не проходит проверку подписи. Две другие тени действительны и могут восстановить секретный ключ. Продолжить процесс восстановления?", "Подпись неверна", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show(this, "Восстановление ключа прервано по причине неверной подписи тени.", "Операция прервана", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } else
                {
                    shadows = shadows.Except(new Shadow[] { shadows[Array.FindIndex(isShadowCorrect, value => value == false)] }).ToArray();
                }
            }
            if(numberOfCorrectShadows < 2)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Количество теней, не прошедших проверку подписи, превышает 1. Восстановленный по неправильным теням ключ может оказаться недействительным. Все равно продолжить процесс восстановления?", "Подписи неверны", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show(this, "Восстановление ключа прервано по причине неверной подписи тени.", "Операция прервана", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    // Если несколько теней не прошли проверку подписи, пытаемся восстановить секрет по всем возможным комбинациям из двух теней
                    // первая + вторая (массив shadows не меняется, так как функция restoreSecret() обрабатывает только первые два элемента массива
                    SecretSharing SS1 = new SecretSharing();
                    BigInteger secret1 = SS1.restoreSecret(shadows);
                    // первая + третья (исключаем вторую из массива)
                    BigInteger secret2 = SS1.restoreSecret(shadows.Except(new Shadow[] { shadows[1] }).ToArray());
                    // вторая + третья (исключаем первую)
                    BigInteger secret3 = SS1.restoreSecret(shadows.Except(new Shadow[] { shadows[0] }).ToArray());
                    File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName + comboBoxUserInfo.Text.Split(' ').Last() + "_1+2", secret1.ToByteArray());
                    File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName + comboBoxUserInfo.Text.Split(' ').Last() + "_1+3", secret2.ToByteArray());
                    File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName + comboBoxUserInfo.Text.Split(' ').Last() + "_2+3", secret3.ToByteArray());

                    MessageBox.Show(this, "В указанном ранее каталоге вы найдете три файла с восстановленным ключом. Один из них может содержать корректный секретный ключ.", "Завершена попытка восстановить секретный ключ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            SecretSharing SS = new SecretSharing();
            BigInteger secret = SS.restoreSecret(shadows);

            File.WriteAllBytes(pathToFolderTextBox.Text + keyFileName + comboBoxUserInfo.Text.Split(' ').Last(), secret.ToByteArray());
            MessageBox.Show(this, "Вы можете найти восстановленный секретный ключ в указанном ранее каталоге", "Секретный ключ успешно восстановлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxUserInfo_TextUpdate(object sender, EventArgs e)
        {
            string text = comboBoxUserInfo.Text;
            if(comboBoxUserInfo.Text != "")
            try
            {
                conDataBase.Open();
                
                using (var cmd = new NpgsqlCommand("SELECT id, surname, name, patronymic, snils FROM public.user WHERE UPPER(name) LIKE UPPER(@String) OR UPPER(surname) LIKE " +
                    "UPPER(@String) OR UPPER(patronymic) LIKE UPPER(@String) OR UPPER(snils) LIKE UPPER(@String);", conDataBase))
                {
                    NpgsqlParameter searchString = cmd.CreateParameter();
                    searchString.ParameterName = "@String";
                    searchString.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    searchString.Value = comboBoxUserInfo.Text + "%";
                    cmd.Parameters.Add(searchString);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            comboBoxUserInfo.Items.Clear();
                            comboBoxUserInfo.SelectionStart = comboBoxUserInfo.Text.Length;
                            comboBoxUserInfo.SelectionLength = 0;
                            while (reader.Read())
                            {
                                try
                                {
                                    string result = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4);
                                        comboBoxUserInfo.Items.Add(new { Text = result, Value = reader.GetValue(0)});
                                        comboBoxUserInfo.DroppedDown = true;
                                        comboBoxUserInfo.Text = text;
                                        comboBoxUserInfo.SelectionStart = comboBoxUserInfo.Text.Length;
                                        comboBoxUserInfo.SelectionLength = 0;
                                        Cursor.Current = Cursors.Default;
                                    }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message);
                                }

                            }
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
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            pathToFolderTextBox.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\";

        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
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

        private void MainForm_Load(object sender, EventArgs e) {}
    }
}
