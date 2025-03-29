using HotelProgram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для AddClientDataGrid.xaml
    /// </summary>
    public partial class AddClientDataGrid : Window
    {
        public clients SelectedClient { get; private set; }
        public AddClientDataGrid()
        {
            InitializeComponent();
            DataContext = new AddClientDataGridViewModel(new Hotel_bdEntities());
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid && dataGrid.SelectedItem is clients selectedClient)
            {
                SelectedClient = selectedClient;
                DialogResult = true;
                Close();
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
