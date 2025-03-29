using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelProgram.ViewModels
{
    public class NewServiceNameViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;

        public NewServiceNameViewModel(Hotel_bdEntities context, int employee_id)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _employee_id = employee_id;
        }
        public ObservableCollection<service_name> Service_Names { get; set; }
        private string _serviceName;
        public string ServiceName
        {
            get => _serviceName;
            set
            {
                _serviceName = value;
                OnPropertyChanged(nameof(ServiceName));
            }
        }

        private string _serviceDescription;
        public string ServiceDescription
        {
            get => _serviceDescription;
            set
            {
                _serviceDescription = value;
                OnPropertyChanged(nameof(ServiceDescription));
            }
        }

        private decimal _serviceCost;
        public decimal ServiceCost
        {
            get => _serviceCost;
            set
            {
                _serviceCost = value;
                OnPropertyChanged(nameof(ServiceCost));
            }
        }

        public ICommand SaveCommand => new RelayCommand(SaveNewServiceName);

        private void SaveNewServiceName()
        {
            var newService = new service_name
            {
                service_name1 = ServiceName,
                service_description = ServiceDescription,
                service_cost = ServiceCost
            };

            _context.service_name.Add(newService);
            _context.SaveChanges();
            LogTransaction(3, $"Услуга c # {newService.service_name_id}");
            RequestClose?.Invoke();
            MessageBox.Show("Услуга создана!");
            // Закрытие окна или обновление интерфейса
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
