using HandyControl.Tools.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace HotelProgram.ViewModels
{
    public class NewServiceViewModel : ViewModelBase
    {
        private DateTime? _selectedDate;
        private TimeSpan? _selectedTime;
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;
        private const int MaxServices = 6;
        private ObservableCollection<service> _selectedServices;
        private decimal _additionalOrderTotalCost;

        public NewServiceViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _employee_id = employeeId;

            LoadClients();
            LoadServices();
            AddServiceCommand = new RelayCommand(AddService, CanAddService);
            RemoveServiceCommand = new RelayCommand<service>(RemoveService, CanRemoveService);

            SelectedServices = new ObservableCollection<service>();
            SelectedServices.CollectionChanged += SelectedServices_CollectionChanged;
            
            SaveCommand = new RelayCommand(SaveAdditionalOrder);
        }
        public decimal AdditionalOrderTotalCost
        {
            get => _additionalOrderTotalCost;
            set
            {
                _additionalOrderTotalCost = value;
                OnPropertyChanged(nameof(AdditionalOrderTotalCost));
            }
        }
        private void UpdateTotalCost()
        {
            AdditionalOrderTotalCost = SelectedServices.Sum(s => s.service_cost);
        }
        private void SelectedServices_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (service newService in e.NewItems)
                {
                    newService.PropertyChanged += Service_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (service oldService in e.OldItems)
                {
                    oldService.PropertyChanged -= Service_PropertyChanged;
                }
            }
            UpdateTotalCost();
        }

        private void Service_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(service.service_name))
            {
                UpdateTotalCost();
            }
        }
        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                OnPropertyChanged(nameof(AdditionalOrderDateTime)); // Обновление комбинированного свойства
            }
        }

        public TimeSpan? SelectedTime
        {
            get
            {
                return _selectedTime;
            }
            set
            {
                _selectedTime = value;
                OnPropertyChanged(nameof(SelectedTime));
                OnPropertyChanged(nameof(AdditionalOrderDateTime)); // Обновление комбинированного свойства
            }
        }

        public DateTime? AdditionalOrderDateTime
        {
            get
            {
                if (SelectedDate.HasValue && SelectedTime.HasValue)
                {
                    return SelectedDate.Value.Date + SelectedTime.Value;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    SelectedDate = value.Value.Date;
                    SelectedTime = value.Value.TimeOfDay;
                }
                else
                {
                    SelectedDate = null;
                    SelectedTime = null;
                }
                OnPropertyChanged(nameof(AdditionalOrderDateTime));
            }
        }

        private int _selectedClientId;
        public int SelectedClientId
        {
            get => _selectedClientId;
            set
            {
                _selectedClientId = value;
                OnPropertyChanged(nameof(SelectedClientId));
                OnPropertyChanged(nameof(SelectedClientFullName));
            }
        }
        public string SelectedClientFullName
        {
            get
            {
                var selectedClient = Clients.FirstOrDefault(c => c.client_id == SelectedClientId);
                return selectedClient != null ? $"{selectedClient.client_lastname} {selectedClient.client_name} {selectedClient.client_surname}" : string.Empty;
            }
        }

        private ObservableCollection<clients> _clients;
        public ObservableCollection<clients> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }
        public ObservableCollection<service_name> Services { get; set; }
        public ObservableCollection<service> SelectedServices
        {
            get => _selectedServices;
            set
            {
                _selectedServices = value;
                OnPropertyChanged(nameof(SelectedServices));
            }
        }
         
        private void LoadClients()
        {
            var today = DateTime.Today;
            var clientsWithBookings = _context.booking
                .Where(b => b.booking_date_issue <= today && b.booking_date_departure >= today)
                .Select(b => b.clients)
                .Distinct()
                .ToList();

            Clients = new ObservableCollection<clients>(clientsWithBookings);
        }
        private void LoadServices()
        {
            var services = _context.service_name.ToList();
            Services = new ObservableCollection<service_name>(services);
        }

        public RelayCommand AddServiceCommand { get; }

        public RelayCommand<service> RemoveServiceCommand { get; }
        public RelayCommand SaveCommand { get; }
        private void SaveAdditionalOrder()
        {
            if (_employee_id != 0 && AdditionalOrderDateTime.HasValue)
            {
                var newOrder = new additional_orders
                {
                    client_id = SelectedClientId,
                    employee_id = _employee_id,
                    additional_order_date = AdditionalOrderDateTime.Value,
                    additional_order_cost = AdditionalOrderTotalCost
                };

                _context.additional_orders.Add(newOrder);
                _context.SaveChanges();

                foreach (var selectedService in SelectedServices)
                {
                    var serviceNameId = selectedService.service_name.service_name_id;
                    var existingServiceName = _context.service_name.Find(serviceNameId);

                    if (existingServiceName == null)
                    {
                        MessageBox.Show($"Услуга с таким #: {serviceNameId} не существует.");
                    }

                    _context.service.Add(new service
                    {
                        service_name_id = serviceNameId,
                        additional_orders_id = newOrder.additional_order_id
                    });
                }

                _context.SaveChanges();
                LogTransaction(1, $"Доп. заказ c # {newOrder.additional_order_id}");
                RequestClose?.Invoke();
                MessageBox.Show("Дополнительный заказ создан!");
            }
            else
            {
                MessageBox.Show("Дата и время должны быть подтверждены!");
            }
        }

        private void AddService()
        {
            if (SelectedServices.Count < MaxServices)
            {
                var newService = new service();
                newService.PropertyChanged += Service_PropertyChanged;
                SelectedServices.Add(newService);
                AddServiceCommand.RaiseCanExecuteChanged();
                RemoveServiceCommand.RaiseCanExecuteChanged();
                UpdateTotalCost();
            }
        }

        private void RemoveService(service serviceToRemove)
        {
            serviceToRemove.PropertyChanged -= Service_PropertyChanged;
            SelectedServices.Remove(serviceToRemove);
            AddServiceCommand.RaiseCanExecuteChanged();
            RemoveServiceCommand.RaiseCanExecuteChanged();
            UpdateTotalCost();
        }
        private bool CanRemoveService(service service)
        {
            return SelectedServices.Count > 0;
        }
        private bool CanAddService()
        {
            return SelectedServices.Count < MaxServices;
        }
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;
            public event EventHandler CanExecuteChanged;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute();
            }

            public void Execute(object parameter)
            {
                _execute();
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public class RelayCommand<T> : ICommand
        {
            private readonly Action<T> _execute;
            private readonly Func<T, bool> _canExecute;
            public event EventHandler CanExecuteChanged;

            public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute((T)parameter);
            }

            public void Execute(object parameter)
            {
                _execute((T)parameter);
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
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
