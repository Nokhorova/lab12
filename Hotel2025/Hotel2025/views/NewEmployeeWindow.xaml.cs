using HotelProgram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelProgram.Views
{
    /// <summary>
    /// Логика взаимодействия для NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        public NewEmployeeWindow()
        {
            InitializeComponent();
            int currentEmployeeId = GetCurrentEmployeeId();
            var dbContext = new Hotel_bdEntities();
            var viewModel = new NewEmployeeViewModel(dbContext, currentEmployeeId);
            DataContext = viewModel;
            viewModel.RequestClose += () => this.Close();
        }
        private int GetCurrentEmployeeId()
        {
            var authenticatedUser = LoginViewModel.GetAuthenticatedUser();
            if (authenticatedUser != null)
            {
                using (var context = new Hotel_bdEntities())
                {
                    var employee = context.employees.FirstOrDefault(e => e.Id == authenticatedUser.Id);
                    if (employee != null)
                    {
                        return employee.employee_id;
                    }
                }
            }
            return 0; // Или другое значение по умолчанию для идентификатора сотрудника
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void tb_phonenumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;
            var text = textBox.Text;

            // Remove non-numeric characters except '+'
            var numericText = Regex.Replace(text, @"[^\d]", "");

            // Format the text
            var formattedText = FormatPhoneNumber(numericText);

            // Set the formatted text back to the TextBox
            textBox.Text = formattedText;

            // Move caret to the end of the text
            textBox.CaretIndex = formattedText.Length;
        }

        private string FormatPhoneNumber(string numericText)
        {
            if (numericText.Length > 11)
                numericText = numericText.Substring(0, 11);

            if (numericText.Length > 0 && numericText[0] != '7')
                numericText = "7" + numericText;

            var phoneNumber = $"+7 (";
            if (numericText.Length > 1)
                phoneNumber += numericText.Substring(1, Math.Min(3, numericText.Length - 1));

            if (numericText.Length > 4)
                phoneNumber += ") " + numericText.Substring(4, Math.Min(3, numericText.Length - 4));

            if (numericText.Length > 7)
                phoneNumber += "-" + numericText.Substring(7, Math.Min(2, numericText.Length - 7));

            if (numericText.Length > 9)
                phoneNumber += "-" + numericText.Substring(9, Math.Min(2, numericText.Length - 9));

            return phoneNumber;
        }
    }
}
