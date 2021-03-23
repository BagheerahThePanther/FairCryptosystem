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
using Npgsql;





namespace KeyRestoration
{
    public partial class MainForm : Form
    {
        NpgsqlConnection conDataBase = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("conString"));

        public MainForm()
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

        private DataTable dataTable = new DataTable();
        private List<string> tableNames = new List<string>();


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            changeToRegister();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            try

            {
                conDataBase.Open();

                using (var cmd = new NpgsqlCommand("SELECT * FROM public.investigator WHERE login = @Login AND password = @Password;", conDataBase))
                {
                    NpgsqlParameter login = cmd.CreateParameter();
                    login.ParameterName = "@Login";
                    login.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    login.Value = textBoxLogin.Text;
                    cmd.Parameters.Add(login);

                    NpgsqlParameter pass = cmd.CreateParameter();
                    pass.ParameterName = "@Password";
                    pass.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    pass.Value = Encoding.Default.GetString(GOSTHash.createHash(Encoding.Default.GetBytes(textBoxPassword.Text), true));
                    cmd.Parameters.Add(pass);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("ОК");
                            changeToMain();
                        }
                        else
                        {
                            MessageBox.Show(this, "Проверьте правильность ввода логина и пароля", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
        private void changeToMain()
        {
            changeLoginVisibility(false);
            changeMainVisibility(true);
            changeRegisterVisibility(false);
            clearAllFields();
        }

        private void changeToLogin()
        {
            changeLoginVisibility(true);
            changeMainVisibility(false);
            changeRegisterVisibility(false);
            clearAllFields();
        }
        private void changeRegisterVisibility(bool isVisible)
        {
            label3.Visible = isVisible;
            label4.Visible = isVisible;
            label5.Visible = isVisible;
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
            textBoxName.Text = "Имя";
            textBoxSurname.Text = "Фамилия";
            textBoxPatronymic.Text = "Отчество";
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
                    pass.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Char;
                    pass.Value = Encoding.Default.GetString(GOSTHash.createHash(Encoding.Default.GetBytes(textBoxNewPass.Text), true));
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
                        MessageBox.Show("ОК");
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
            }



            changeToLogin();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            changeToLogin();
        }
    }
}
