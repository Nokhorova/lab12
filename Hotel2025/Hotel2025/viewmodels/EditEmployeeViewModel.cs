using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private employees _selectedEmployeeFromDataGrid;
        private int _employee_id;
        private Hotel_bdEntities _context;

        public EditEmployeeViewModel(Hotel_bdEntities context, employees selectedEmployeeFromDataGrid, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _selectedEmployeeFromDataGrid = selectedEmployeeFromDataGrid ?? throw new ArgumentNullException(nameof(selectedEmployeeFromDataGrid));
            _employee_id = employeeId;

            LoadInitialValues();
            LoadEmployees();
            LoadDepartments();
        }
        private void LoadInitialValues()
        {
            if (_selectedEmployeeFromDataGrid != null)
            {
                SelectedEmployee = _context.employees
                .Include(e => e.department)
                .Include(e => e.company)
                .FirstOrDefault(e => e.employee_id == _selectedEmployeeFromDataGrid.employee_id);
                if (SelectedEmployee != null)
                {
                    EmployeeLastName = SelectedEmployee.employee_lastname;
                    EmployeeName = SelectedEmployee.employee_name;
                    EmployeeSurName = SelectedEmployee.employee_surname;
                    EmployeeContactNumber = SelectedEmployee.employee_contact_number;
                    EmployeeEmail = SelectedEmployee.employee_email;
                    SelectedDepartment = SelectedEmployee.department;
                    SelectedCompany = _context.company.FirstOrDefault(c => c.company_id == 1);
                }
            }
        }
        public ObservableCollection<department> Departments { get; set; }
        private void LoadDepartments()
        {
            var departments = _context.department.ToList();
            Departments = new ObservableCollection<department>(departments);
        }
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
        public ObservableCollection<employees> Employees { get; set; }

        private employees _selectedEmployee;
        public employees SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    OnPropertyChanged(nameof(SelectedEmployee));
                    if (_selectedEmployee != null)
                    {
                        EmployeeLastName = _selectedEmployee.employee_lastname;
                        EmployeeName = _selectedEmployee.employee_name;
                        EmployeeSurName = _selectedEmployee.employee_surname;
                        EmployeeContactNumber = _selectedEmployee.employee_contact_number;
                        EmployeeEmail = _selectedEmployee.employee_email;
                        SelectedDepartment = _selectedEmployee.department;
                        SelectedCompany = _context.company.FirstOrDefault(c => c.company_id == 1);
                    }
                }
            }
        }
        private void LoadEmployees()
        {
            var employees = _context.employees
                .Include(e => e.company)
                .Include(e => e.department)
                .ToList();

            Employees = new ObservableCollection<employees>(employees);
        }
        private string _employeeLastName;
        public string EmployeeLastName
        {
            get
            {
                return _employeeLastName;
            }
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
            get
            {
                return _employeeName;
            }
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
            get
            {
                return _employeeSurName;
            }
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
            get
            {
                return _employeeContactNumber;
            }
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
            get
            {
                return _employeeEmail;
            }
            set
            {
                if (_employeeEmail != value)
                {
                    _employeeEmail = value;
                    OnPropertyChanged(nameof(EmployeeEmail));
                }
            }
        }
        private company _selectedCompany;
        public company SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                if (_selectedCompany != value)
                {
                    _selectedCompany = value;
                    OnPropertyChanged(nameof(SelectedCompany));
                }
            }
        }
        public ICommand SaveCommand => new RelayCommand(SaveEmployee);

        private void SaveEmployee()
        {
            if (_selectedEmployeeFromDataGrid != null)
            {
                var employeeToUpdate = _context.employees
                    .Include(e => e.department)
                    .Include(e => e.company)
                    .FirstOrDefault(e => e.employee_id == _selectedEmployeeFromDataGrid.employee_id);

                if (employeeToUpdate != null)
                {
                    employeeToUpdate.employee_lastname = EmployeeLastName;
                    employeeToUpdate.employee_name = EmployeeName;
                    employeeToUpdate.employee_surname = EmployeeSurName;
                    employeeToUpdate.employee_contact_number = EmployeeContactNumber;
                    employeeToUpdate.employee_email = EmployeeEmail;
                    employeeToUpdate.employee_department = DepartmentId;
                    employeeToUpdate.company_id = 1;

                    _context.SaveChanges();
                    LoadEmployees();
                    LogTransaction(4, $"Сотрудник c # {_selectedEmployeeFromDataGrid.employee_id}");
                    RequestClose?.Invoke();
                    MessageBox.Show("Изменения сохранены!");
                }
            }

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
