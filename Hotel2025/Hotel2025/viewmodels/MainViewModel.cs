using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FontAwesome.Sharp;
using HotelProgram.Models;
using HotelProgram.Repositories;
using HotelProgram.Views;

namespace HotelProgram.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private readonly IUserRepository userRepository;

        private readonly Hotel_bdEntities _context;
        private readonly int _currentEmployeeId;
        private int _currentDepartmentId;

        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get 
            { 
                return _currentUserAccount; 
            }
            set 
            { 
                _currentUserAccount = value; 
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowBookingViewCommand { get; }
        public ICommand ShowCLientsViewCommand { get; }
        public ICommand ShowRoomsViewCommand { get; }
        public ICommand ShowTarifsViewCommand { get; }
        public ICommand ShowServicesViewCommand { get; }
        public ICommand ShowEmployeesViewCommand { get; }
        public ICommand ShowReportsViewCommand { get; }
        public ICommand ShowUsersViewCommand { get; }
        public ICommand ShowSettingsViewCommand { get; }
        public ICommand ShowTransactionListViewCommand { get; }
        public MainViewModel()
        {
            _context = new Hotel_bdEntities();
            _currentEmployeeId = GetCurrentEmployeeId();
            _currentDepartmentId = GetCurrentDepartmentId();

            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowBookingViewCommand = new ViewModelCommand(ExecuteShowBookingViewCommand);
            ShowCLientsViewCommand = new ViewModelCommand(ExecuteShowClientsViewCommand);
            ShowRoomsViewCommand = new ViewModelCommand(ExecuteShowRoomsViewCommand);
            ShowTarifsViewCommand = new ViewModelCommand(ExecuteShowTarifsViewCommand);
            ShowServicesViewCommand = new ViewModelCommand(ExecuteShowServicesViewCommand);
            ShowEmployeesViewCommand = new ViewModelCommand(ExecuteShowEmployeesViewCommand);
            ShowReportsViewCommand = new ViewModelCommand(ExecuteShowReportsViewCommand);
            ShowUsersViewCommand = new ViewModelCommand(ExecuteShowUsersViewCommand);
            ShowSettingsViewCommand = new ViewModelCommand(ExecuteShowSettingsViewCommand);
            ShowTransactionListViewCommand = new ViewModelCommand(ExecuteShowTransactionListViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowTransactionListViewCommand(object obj)
        {
            TransactionList transactionList = new TransactionList();
            transactionList.Show();
        }

        private void ExecuteShowSettingsViewCommand(object obj)
        {
            CurrentChildView = new SettingsViewModel();
            Caption = "Настройки";
            Icon = IconChar.Tools;
        }

        private void ExecuteShowUsersViewCommand(object obj)
        {
            CurrentChildView = new UsersViewModel();
            Caption = "Пользователи и права";
            Icon = IconChar.Users;
        }

        private void ExecuteShowReportsViewCommand(object obj)
        {
            CurrentChildView = new ReportsViewModel();
            Caption = "Отчёты и аналитика";
            Icon = IconChar.ChartSimple;
        }

        private void ExecuteShowEmployeesViewCommand(object obj)
        {
            CurrentChildView = new EmployeesViewModel(_context, _currentEmployeeId);
            Caption = "Сотрудники";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowServicesViewCommand(object obj)
        {
            CurrentChildView = new ServicesViewModel(_context, _currentEmployeeId);
            Caption = "Услуги";
            Icon = IconChar.Utensils;
        }

        private void ExecuteShowTarifsViewCommand(object obj)
        {
            CurrentChildView = new TarifsViewModel(_context, _currentEmployeeId);
            Caption = "Тарифы и цены";
            Icon = IconChar.Wallet;
        }

        private void ExecuteShowRoomsViewCommand(object obj)
        {
            CurrentChildView = new RoomsViewModel(_context, _currentEmployeeId);
            Caption = "Номера";
            Icon = IconChar.Bed;
        }

        private void ExecuteShowClientsViewCommand(object obj)
        {
            CurrentChildView = new ClientsViewModel(_context, _currentEmployeeId);
            Caption = "Клиентская база";
            Icon = IconChar.AddressCard;
        }

        private void ExecuteShowBookingViewCommand(object obj)
        {
            CurrentChildView = new BookingViewModel(_context, _currentEmployeeId);
            Caption = "Бронирования";
            Icon = IconChar.BellConcierge;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Главная";
            Icon = IconChar.Home;
        }
        // Метод для получения идентификатора текущего сотрудника
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
        // Метод для получения идентификатора текущего департамента
        private int GetCurrentDepartmentId()
        {
            var authenticatedUser = LoginViewModel.GetAuthenticatedUser();
            if (authenticatedUser != null)
            {
                using (var context = new Hotel_bdEntities())
                {
                    var employee = context.employees.Include("department").FirstOrDefault(e => e.Id == authenticatedUser.Id);
                    if (employee != null)
                    {
                        return employee.employee_department;
                    }
                }
            }
            return 0; // Или другое значение по умолчанию для идентификатора департамента
        }
        private void LoadCurrentUserData()
        {
            try
            {
                var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                if (user != null)
                {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";

                    // Получаем информацию о департаменте пользователя
                    var employee = _context.employees.Include("department").FirstOrDefault(e => e.Id == user.Id);
                    if (employee != null && employee.department != null)
                    {
                        CurrentUserAccount.DepartmentName = employee.department.department_name;
                    }
                    else
                    {
                        CurrentUserAccount.DepartmentName = "Не указан";
                    }
                }
                else
                {
                    CurrentUserAccount.DisplayName = "Вход не выполнен";
                }
            }
            catch (Exception ex)
            {
                // Логгирование ошибки
                CurrentUserAccount.DisplayName = "Ошибка загрузки данных пользователя";
                // В зависимости от требований, можно добавить логгирование: Logger.LogError(ex);
            }
        }
    }
}
