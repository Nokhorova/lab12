using HotelProgram.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        private int _employee_id;
        private int _department_id;

        public ClientsViewModel(Hotel_bdEntities context, int employee_id)
        {
            _context = context;
            _employee_id = employee_id;
            _department_id = GetCurrentDepartmentId();
            LoadClients();
        }

        public ObservableCollection<clients> Clients { get; set; }
        private void LoadClients()
        {
            var clients = _context.clients
                .Include(c => c.client_rating)
                .Include(c => c.documents)
                .ToList();

            Clients = new ObservableCollection<clients>(clients);
        }

        public class RelayCommand : ICommand
        {
            private Action<object> _execute;
            private Func<object, bool> _canExecute;

            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private ICommand createNewClientCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        public ICommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(EditClient));
        private void EditClient(object parameter)
        {
            if (parameter is clients selectedClient)
            {
                _employee_id = GetCurrentEmployeeId();
                if (_employee_id == 0)
                {
                    MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                    return;
                }
                var editViewModel = new EditClientViewModel(_context, selectedClient, _employee_id);
                var editWindow = new EditClientWindow(editViewModel);
                editWindow.ShowDialog();
            }
        }
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteClient));
        private void DeleteClient(object parameter)
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для удаления.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            if (parameter is clients selectedClient)
            {
                /// Проверка, существует ли объект в контексте
                var existingClient = _context.clients.Find(selectedClient.client_id);
                if (existingClient == null)
                {
                    // Если объект не отслеживается, присоединяем его к контексту
                    _context.clients.Attach(selectedClient);
                    existingClient = selectedClient;
                }
                // Показать диалоговое окно с вопросом
                var result = MessageBox.Show($"Вы уверены, что хотите удалить клиента с # {selectedClient.client_id}?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                // Если пользователь нажал "Yes", удалить запись
                if (result == MessageBoxResult.Yes)
                {
                    _context.clients.Remove(existingClient);
                    _context.SaveChanges();
                    LogTransaction(7, $"Клиент c # {selectedClient.client_id}");
                    Clients.Remove(existingClient);
                    MessageBox.Show("Запись успешно удалена!");
                }
            }
        }
        private void LogTransaction(int typeOperationId, string windowName)
        {
            var transaction = new transaction
            {
                employee_id = _employee_id,
                type_operation_id = typeOperationId,
                date = DateTime.Now,
                window_name = windowName
            };
            _context.transaction.Add(transaction);
            _context.SaveChanges();
        }
        public ICommand CreateNewCLientCommand
        {
            get
            {
                if (createNewClientCommand == null)
                {
                    createNewClientCommand = new RelayCommand(parameter => CreateNewClient());
                }
                return createNewClientCommand;
            }
        }
        private void CreateNewClient()
        {
            // Открытие окна для создания нового бронирования
            NewClientWindow newClientWindow = new NewClientWindow();
            newClientWindow.ShowDialog();
        }
        private int GetCurrentEmployeeId()
        {
            var authenticatedUser = LoginViewModel.GetAuthenticatedUser();
            if (authenticatedUser != null)
            {
                var employee = _context.employees.FirstOrDefault(e => e.Id == authenticatedUser.Id);
                if (employee != null)
                {
                    return employee.employee_id;
                }
            }
            return 0; // Или другое значение по умолчанию для идентификатора сотрудника
        }
        private int GetCurrentDepartmentId()
        {
            var authenticatedUser = LoginViewModel.GetAuthenticatedUser();
            if (authenticatedUser != null)
            {
                var employee = _context.employees.Include("department").FirstOrDefault(e => e.Id == authenticatedUser.Id);
                if (employee != null)
                {
                    return employee.employee_department;
                }
            }
            return 0; // Или другое значение по умолчанию для идентификатора департамента
        }
    }
}
