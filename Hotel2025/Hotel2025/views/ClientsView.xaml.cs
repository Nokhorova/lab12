using HotelProgram.ViewModels;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = Microsoft.Office.Interop.Word.Application;

namespace HotelProgram.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
            DataGrid.ItemsSource = Hotel_bdEntities.GetContext().clients.ToList();
            var context = new Hotel_bdEntities();
            var viewModel = new ClientsViewModel(context, GetCurrentEmployeeId());
            DataContext = viewModel;
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
            return 0;
        }
        private void WordPersonalDataButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Users\diman\OneDrive\Desktop\Диплом\Проект\HotelProgram1\Согласие на обработку персональных данных.docx"; // Укажите путь к вашему Word файлу здесь

            if (File.Exists(filePath))
            {
                try
                {
                    // Создаем приложение Word
                    Application wordApp = new Application();
                    wordApp.Visible = true;

                    // Открываем документ
                    Document wordDoc = wordApp.Documents.Open(filePath);

                    // Печатаем документ
                    wordDoc.PrintOut();

                    // Закрываем документ и приложение Word
                    wordDoc.Close();
                    wordApp.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при печати документа: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }
        }
    }
}
