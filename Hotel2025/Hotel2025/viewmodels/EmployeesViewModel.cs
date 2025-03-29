using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HotelProgram.Views;
using System.Windows.Input;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        private int _employee_id;
        private int _department_id;

        public EmployeesViewModel(Hotel_bdEntities context, int employee_id)
        {
            _context = context;
            _employee_id = employee_id;
            _department_id = GetCurrentDepartmentId();
            LoadEmployees();
        }
        public ObservableCollection<employees> Employees { get; set; }
        private void LoadEmployees()
        {
            var employees = _context.employees
                .Include(e => e.company)
                .Include(e => e.department)
                .ToList();

            Employees = new ObservableCollection<employees>(employees);
        }
        public class RelayCommand : ICommand
        {
            private Action<object> _execute;

            public RelayCommand(Action<object> execute)
            {
                _execute = execute;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
        }
        private ICommand createNewEmployeeCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        public ICommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(EditEmployee));
        private void EditEmployee(object parameter)
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для редактирования сотрудника.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (parameter is employees selectedEmployee)
            {
                _employee_id = GetCurrentEmployeeId();
                if (_employee_id == 0)
                {
                    MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                    return;
                }
                var editViewModel = new EditEmployeeViewModel(_context, selectedEmployee, _employee_id);
                var editWindow = new EditEmployeeWindow(editViewModel);
                editWindow.ShowDialog();
            }
        }
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteEmployee));
        private void DeleteEmployee(object parameter)
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для удаления сотрудника.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (parameter is employees selectedEmployee)
            {
                /// Проверка, существует ли объект в контексте
                var existingEmployee = _context.employees.Find(selectedEmployee.employee_id);
                if (existingEmployee == null)
                {
                    // Если объект не отслеживается, присоединяем его к контексту
                    _context.employees.Attach(selectedEmployee);
                    existingEmployee = selectedEmployee;
                }
                // Показать диалоговое окно с вопросом
                var result = MessageBox.Show($"Вы уверены, что хотите удалить бронирование с # {selectedEmployee.employee_id}?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                // Если пользователь нажал "Yes", удалить запись
                if (result == MessageBoxResult.Yes)
                {
                    _context.employees.Remove(existingEmployee);
                    _context.SaveChanges();
                    LogTransaction(7, $"Сотрудник c # {selectedEmployee.employee_id}");
                    Employees.Remove(existingEmployee);
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
        public ICommand CreateNewEmployeeCommand
        {
            get
            {
                if (createNewEmployeeCommand == null)
                {
                    createNewEmployeeCommand = new RelayCommand(parameter => CreateNewEmployee());
                }
                return createNewEmployeeCommand;
            }
        }
        private void CreateNewEmployee()
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для создания сотрудника.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            // Открытие окна для создания нового бронирования
            NewEmployeeWindow newEmployeeWindow = new NewEmployeeWindow();
            newEmployeeWindow.ShowDialog();
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
