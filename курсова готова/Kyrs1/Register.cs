using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kyrs1.signForm;

namespace Kyrs1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public void RegisterUser()
        {
            if (PasswordBox.Text.Equals(ConfirmationPassword.Text))
            {
                if (ScannerLogin.Validation(LoginBox.Text) && ScannerPassword.Validation(PasswordBox.Text))
                {
                    string newLogin = LoginBox.Text;
                    string newPasswordHash = SHA128.Hash(PasswordBox.Text);
                    string role = "user";

                    if (Users.Any(user => user.Login.Equals(newLogin)))
                    {
                        MessageBox.Show("Такий логін уже існує. Будь ласка, виберіть інший логін.");
                    }
                    else
                    {
                        Users.Add(new User(newLogin, newPasswordHash, role));
                        SaveUserToFile(newLogin, newPasswordHash, role);
                        MessageBox.Show("Ви успішно зареєструвалися!");
                        OpenForms.OpenForm(this, new signForm());
                    }
                }
            }
            else
            {
                MessageBox.Show("Паролі не співпадають");
            }
        }
        private void SaveUserToFile(string login, string passwordHash, string role)
        {
            string directoryPath = @"C:\Kyrs11\users";
            string filePath = Path.Combine(directoryPath, "users.txt");

            try
            {
                
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

               
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{login}:{passwordHash}:{role}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка зчитування даних: {ex.Message}");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterUser();
           
        }

        private void BackReg_Click(object sender, EventArgs e)
        {
            OpenForms.OpenForm(this, new signForm());
        }
    }
}
