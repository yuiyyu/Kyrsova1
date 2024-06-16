using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Kyrs1;

namespace Kyrs1
{
    public partial class signForm : Form
    {
        private mainForm mainFormInstance;
        public class User
        {
            public string Login { get; set; }
            public string PasswordHash { get; set; }
            public string Role { get; set; }

            public User(string login, string passwordHash, string role)
            {
                Login = login;
                PasswordHash = passwordHash;
                Role = role;
            }
        }

        public static List<User> Users = new List<User>
        {
            new User("admin", SHA128.Hash("admin"), "administrator")
        };

        private User currentUser;
        public static string CurrentUserRole { get; private set; }

        public signForm()
        {
            InitializeComponent();
            mainFormInstance = new mainForm();
            LoadUsersFromFile();
        }

        private void LoadUsersFromFile()
        {
            string directoryPath = @"C:\Kyrs11\users";
            string filePath = Path.Combine(directoryPath, "users.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(':');
                            if (parts.Length == 3)
                            {
                                string login = parts[0];
                                string passwordHash = parts[1];
                                string role = parts[2];
                                Users.Add(new User(login, passwordHash, role));
                            }
                        }
                    }
                    //MessageBox.Show("Користувачі успішно зчитані з файлу.");
                }
                else
                {
                    MessageBox.Show("Файл користувачів не знайдено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка зчитування даних: {ex.Message}");
            }
        }
        public void LoggerSignIn()
        {
            string enteredLogin = LoginBox.Text;
            string enteredPasswordHash = SHA128.Hash(PasswordBox.Text);

            currentUser = Users.FirstOrDefault(user =>
                user.Login.Equals(enteredLogin) &&
                user.PasswordHash.Equals(enteredPasswordHash));

            if (currentUser != null)
            {
                MessageBox.Show("Успішно. Ласкаво просимо!");

                if (currentUser.Role.Equals("administrator"))
                {
                    mainFormInstance.Button1.Visible = true;
                    mainFormInstance.BoldButton.Visible = true;
                    mainFormInstance.ItalicButton.Visible = true;
                    mainFormInstance.UnderlineButton.Visible = true;
                    mainFormInstance.SaveChangesButton.Visible = true;
                    mainFormInstance.EditTextButton.Visible = true;
                    mainFormInstance.AddPhoto2Button.Visible = true;
                    mainFormInstance.AddPhoto3Button.Visible = true;
                    mainFormInstance.AddPhotoButton.Visible = true;
                    mainFormInstance.FontSizeComboBox.Visible = true;
                    mainFormInstance.label.Visible = true;
                    mainFormInstance.label2.Visible = true;
                }
                else
                {
                    mainFormInstance.Button1.Visible = false;
                    mainFormInstance.BoldButton.Visible = false;
                    mainFormInstance.ItalicButton.Visible = false;
                    mainFormInstance.UnderlineButton.Visible = false;
                    mainFormInstance.SaveChangesButton.Visible = false;
                    mainFormInstance.EditTextButton.Visible = false;
                    mainFormInstance.AddPhoto2Button.Visible = false;
                    mainFormInstance.AddPhoto3Button.Visible = false;
                    mainFormInstance.AddPhotoButton.Visible = false;
                    mainFormInstance.FontSizeComboBox.Visible = false;
                    mainFormInstance.label.Visible = false;
                    mainFormInstance.label2.Visible = false;
                }

                OpenForms.OpenForm(this, mainFormInstance);
            }
            else
            {
                MessageBox.Show("Неправильні дані. Введіть ще раз.");
            }
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            OpenForms.OpenForm(this, new signForm());
        }

        private void Sign_Click(object sender, EventArgs e)
        {
            LoggerSignIn();
        }

        private void Register_Click_1(object sender, EventArgs e)
        {
            OpenForms.OpenForm(this, new Register());
        }

        private void notReg_Click(object sender, EventArgs e)
        {
            mainFormInstance.Size = new System.Drawing.Size(1255, 709);
            OpenForms.OpenForm(this, new mainForm());
        }
    }
}
