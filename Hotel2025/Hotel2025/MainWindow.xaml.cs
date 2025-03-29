using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;

namespace Hotel2025
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new Hotel2025DataSet())
            {
                var user =  context.User.FirstOrDefault(u => u.UserName == username);

                if (user != null && PasswordHasher.VerifyPassword(password, user.Password))
                {
                    // Успешный вход
                    MenuWindow mainWindow = new MenuWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    ErrorMessage.Text = "Неверное имя пользователя или пароль.";
                    ErrorMessage.Visibility = Visibility.Visible;
                }
            }
        }
    }
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedPassword.Equals(hashedEnteredPassword, StringComparison.OrdinalIgnoreCase);
        }
    }

}
