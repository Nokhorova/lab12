using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace HotelProgram.ViewModels
{
    public class NewEmployeeViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;

        public NewEmployeeViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _employee_id = employeeId;
            
            LoadDepartments();
        }

        public ObservableCollection<department> Departments { get; set; }

        private int _departmentId;
        public int DepartmentId
        {
            get { return _departmentId; }
            set
            {
                if (_departmentId != value)
                {
                    _departmentId = value;
                    OnPropertyChanged(nameof(DepartmentId));
                }
            }
        }

        private department _selectedDepartment;
        public department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                if (_selectedDepartment != value)
                {
                    _selectedDepartment = value;
                    OnPropertyChanged(nameof(SelectedDepartment));
                    if (_selectedDepartment != null)
                    {
                        DepartmentId = _selectedDepartment.department_id;
                    }
                }
            }
        }

        private string _employeeLastName;
        public string EmployeeLastName
        {
            get { return _employeeLastName; }
            set
            {
                if (_employeeLastName != value)
                {
                    _employeeLastName = value;
                    OnPropertyChanged(nameof(EmployeeLastName));
                }
            }
        }

        private string _employeeName;
        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (_employeeName != value)
                {
                    _employeeName = value;
                    OnPropertyChanged(nameof(EmployeeName));
                }
            }
        }

        private string _employeeSurName;
        public string EmployeeSurName
        {
            get { return _employeeSurName; }
            set
            {
                if (_employeeSurName != value)
                {
                    _employeeSurName = value;
                    OnPropertyChanged(nameof(EmployeeSurName));
                }
            }
        }

        private string _employeeContactNumber;
        public string EmployeeContactNumber
        {
            get { return _employeeContactNumber; }
            set
            {
                if (_employeeContactNumber != value)
                {
                    _employeeContactNumber = value;
                    OnPropertyChanged(nameof(EmployeeContactNumber));
                }
            }
        }

        private string _employeeEmail;
        public string EmployeeEmail
        {
            get { return _employeeEmail; }
            set
            {
                if (_employeeEmail != value)
                {
                    _employeeEmail = value;
                    OnPropertyChanged(nameof(EmployeeEmail));
                }
            }
        }

        public ICommand SaveCommand => new RelayCommand(SaveNewEmployee);

        private void SaveNewEmployee()
        {
            var newEmployee = new employees
            {
                employee_lastname = EmployeeLastName,
                employee_name = EmployeeName,
                employee_surname = EmployeeSurName,
                employee_contact_number = EmployeeContactNumber,
                employee_email = EmployeeEmail,
                employee_department = DepartmentId,
                company_id = 1, // Устанавливаем company_id равным 1
                Id = 2
            };

            _context.employees.Add(newEmployee);
            _context.SaveChanges();
            LogTransaction(1, $"Сотрудник c # {newEmployee.employee_id}");
            RequestClose?.Invoke();
            MessageBox.Show("Сотрудник создан!");
            // Закрытие окна или обновление интерфейса
        }

        private void LoadDepartments()
        {
            var departments = _context.department.ToList();
            Departments = new ObservableCollection<department>(departments);
        }

        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

            public void Execute(object parameter) => _execute();

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
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
    }
}
