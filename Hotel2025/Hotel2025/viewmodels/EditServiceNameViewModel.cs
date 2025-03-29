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
    public class EditServiceNameViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private service_name _selectedServiceNameFromDataGrid;
        private int _employee_id;
        private Hotel_bdEntities _context;
        public EditServiceNameViewModel(Hotel_bdEntities context, service_name selectedServiceNameFromDataGrid, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _selectedServiceNameFromDataGrid = selectedServiceNameFromDataGrid ?? throw new ArgumentNullException(nameof(selectedServiceNameFromDataGrid));
            _employee_id = employeeId;

            LoadServiceName();
        }
        public void LoadServiceName()
        {
            ServiceNameId = _selectedServiceNameFromDataGrid.service_name_id;
            ServiceName = _selectedServiceNameFromDataGrid.service_name1;
            ServiceDescription = _selectedServiceNameFromDataGrid.service_description;
            ServiceCost = _selectedServiceNameFromDataGrid.service_cost;
        }
        public ObservableCollection<service_name> ServiceNames { get; set; }
        private int _serviceNameId;
        public int ServiceNameId
        {
            get => _serviceNameId;
            set
            {
                _serviceNameId = value;
                OnPropertyChanged(nameof(ServiceNameId));
            }
        }
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
        public ICommand SaveCommand => new RelayCommand(SaveServiceName);

        private void SaveServiceName()
        {
            try
            {
                if (_selectedServiceNameFromDataGrid != null)
                {
                    var serviceNameToUpdate = _context.service_name.FirstOrDefault(sn => sn.service_name_id == ServiceNameId);
                    if (serviceNameToUpdate != null)
                    {
                        serviceNameToUpdate.service_name1 = ServiceName;
                        serviceNameToUpdate.service_description = ServiceDescription;
                        serviceNameToUpdate.service_cost = ServiceCost;

                        _context.SaveChanges();
                        LoadServiceName();
                        LogTransaction(6, $"Услуга c # {_selectedServiceNameFromDataGrid.service_name_id}");
                        RequestClose?.Invoke();
                        MessageBox.Show("Изменения сохранены!");
                    }
                    else
                    {
                        // Handle case when service name with given ID is not found.
                        MessageBox.Show("Услуга не найдена.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
