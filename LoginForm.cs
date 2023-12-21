using C969Tpennartz.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;

namespace C969Tpennartz
{
    public partial class LoginForm : Form
    {
        private List<Control> managedControls;
        public static class UserSession
        {
            public static string UserName { get; set; }
        }
        Database.Login_user Verify {  get; set; }
        private readonly CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        public static MainPage mainScreen;
        private Dictionary<string, Dictionary<string, string>> languageTexts = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "en", new Dictionary<string, string>()
                {
                    {"Username_label", "Username:" },
                    {"Password_label", "Password:" },
                    {"Login_label", "Login" },
                    {"Login_button", "Login" },
                    {"exit_button", "Exit" }
                }
            },
            {
                "fi", new Dictionary<string, string>()
                {
                    {"Username_label", "Käyttäjänimi:" },
                    {"Password_label", "Salasana:" },
                    {"Login_label", "Sisäänkirjautuminen" },
                    {"Login_button", "Sisäänkirjautuminen"},
                    {"exit_button", "Uloskäynti"}
                }
            }
        };


        public LoginForm()
        {
            
            InitializeComponent();
            InitializeManagedControls();
            ChangeLanguage();

        }
        private void InitializeManagedControls()
        {
        managedControls = new List<Control>();
            {
                managedControls.Add(Username_label);
            managedControls.Add(Password_label);
            managedControls.Add(Login_label);
            managedControls.Add(exit_button);
            managedControls.Add(Login_button);

            }

}
        public void ChangeLanguage()
        {
            string languageCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (languageTexts.ContainsKey(languageCode))
            {
                foreach (var control in managedControls)
                {
                    if (control is Label label)
                    {
                        label.Text = languageTexts[languageCode][label.Name];
                    }
                    else if (control is Button button)
                    {
                        if (languageTexts[languageCode].ContainsKey(button.Name))
                        {
                            button.Text = languageTexts[languageCode][button.Name];
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Language not supported.");
            }
        }


        private void Login_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = DbConnection.Connection;
            Verify = new Database.Login_user();
            int login;
            if (connection.State == ConnectionState.Open)
            {
                switch (currentCulture.TwoLetterISOLanguageName) //I chose Finnish for my language
                {
                    case ("fi"):
                        login = Verify.VerifyLogin(Username_text.Text, Password_text.Text);
                        if (login > 0)
                        {
                            MessageBox.Show("Kirjaudu sisään onnistuneesti");
                            UserSession.UserName = Username_text.Text;
                            this.Hide();
                            mainScreen = new MainPage(login);
                            mainScreen.Show();

                        }
                        else
                        {
                            MessageBox.Show("Käyttäjätunnus tai salasana virheellinen");
                        }
                        break;
                    default:
                        login = Verify.VerifyLogin(Username_text.Text, Password_text.Text);
                        if (login > 0)
                        {
                            UserSession.UserName = Username_text.Text;
                            MessageBox.Show("Login Successful.");
                            this.Hide();
                            mainScreen = new MainPage(login);
                            mainScreen.FormClosed += (s, args) => this.Close();
                            mainScreen.Show();

                        }
                        else
                        {
                            MessageBox.Show("Username or password is incorrect.");
                        }
                        break;
                }
                }
            else
                {
                    MessageBox.Show("MySql connection down");
                }

        }  

        private void exitbutton_Click(object sender, EventArgs e)
        {

            this.Hide();
        }


    }

}
