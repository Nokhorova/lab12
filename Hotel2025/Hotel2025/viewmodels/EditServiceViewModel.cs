using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using System.Diagnostics;

namespace HotelProgram.ViewModels
{
    public class EditServiceViewModel : ViewModelBase
    {
        private DateTime? _selectedDate;
        private TimeSpan? _selectedTime;
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;
        private const int MaxServices = 6;
        private ObservableCollection<service> _selectedServices;
        private decimal _additionalOrderTotalCost;

        public EditServiceViewModel(Hotel_bdEntities context, additional_orders selectedAdditionalOrder, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _employee_id = employeeId;
            SelectedAdditionalOrder = selectedAdditionalOrder ?? throw new ArgumentNullException(nameof(selectedAdditionalOrder));

            LoadClients();
            LoadServices();
            AddServiceCommand = new RelayCommand(AddService, CanAddService);
            RemoveServiceCommand = new RelayCommand<service>(RemoveService, CanRemoveService);

            SelectedServices = new ObservableCollection<service>();
            SelectedServices.CollectionChanged += SelectedServices_CollectionChanged;

            LoadExistingOrderData(selectedAdditionalOrder);
            SaveCommand = new RelayCommand(SaveAdditionalOrder);
        }
        public additional_orders SelectedAdditionalOrder { get; set; }
        private void LoadExistingOrderData(additional_orders selectedAdditionalOrder)
        {
            if (selectedAdditionalOrder != null)
            {
                SelectedClientId = selectedAdditionalOrder.client_id;
                SelectedDate = selectedAdditionalOrder.additional_order_date.Date;
                SelectedTime = selectedAdditionalOrder.additional_order_date.TimeOfDay;
                AdditionalOrderTotalCost = selectedAdditionalOrder.additional_order_cost;

                var existingServices = _context.service
                    .Include(s => s.service_name) // Включаем загрузку связанных объектов service_name
                    .Where(s => s.additional_orders_id == selectedAdditionalOrder.additional_order_id)
                    .ToList();

                foreach (var service in existingServices)
                {
                    SelectedServices.Add(service);
                    service.PropertyChanged += Service_PropertyChanged;
                }
            }
        }
        #region UpdateTotalCost1
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
                    // Debug output to check when services are added
                    Debug.WriteLine($"Service added: {newService.service_name?.service_name1} with cost: {newService.service_cost}");
                }
            }
            if (e.OldItems != null)
            {
                foreach (service oldService in e.OldItems)
                {
                    oldService.PropertyChanged -= Service_PropertyChanged;
                    // Debug output to check when services are removed
                    Debug.WriteLine($"Service removed: {oldService.service_name?.service_name1}");
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
        #endregion
        #region DateTimeAdditionalOrder1
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
        #endregion
        #region ClientsID
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
        #endregion
        #region Services
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

        private void LoadServices()
        {
            var services = _context.service_name.ToList();
            Services = new ObservableCollection<service_name>(services);
            OnPropertyChanged(nameof(Services));
        }
        #endregion

        #region ICommand1
        public RelayCommand AddServiceCommand { get; }
        public RelayCommand<service> RemoveServiceCommand { get; }
        public RelayCommand SaveCommand { get; } 
        #endregion
        private void SaveAdditionalOrder()
        {
            if (_employee_id != 0 && AdditionalOrderDateTime.HasValue)
            {
                var existingOrder = _context.additional_orders
                    .FirstOrDefault(order => order.additional_order_id == SelectedAdditionalOrder.additional_order_id);

                if (existingOrder != null)
                {
                    existingOrder.client_id = SelectedClientId;
                    existingOrder.employee_id = _employee_id;
                    existingOrder.additional_order_date = AdditionalOrderDateTime.Value;
                    existingOrder.additional_order_cost = AdditionalOrderTotalCost;

                    _context.SaveChanges();

                    // Получение существующих услуг для данного заказа
                    var existingServices = _context.service
                        .Where(s => s.additional_orders_id == existingOrder.additional_order_id)
                        .ToList();

                    // Словарь для сопоставления service_name_id с существующими услугами
                    var existingServicesDict = existingServices.ToDictionary(s => s.service_name_id);

                    // Обновление или добавление новых услуг
                    foreach (var selectedService in SelectedServices)
                    {
                        if (selectedService.service_name != null)
                        {
                            var serviceNameId = selectedService.service_name.service_name_id;

                            if (!existingServicesDict.ContainsKey(serviceNameId))
                            {
                                // Если услуга не существует, добавляем ее
                                _context.service.Add(new service
                                {
                                    service_name_id = serviceNameId,
                                    additional_orders_id = existingOrder.additional_order_id
                                });
                            }
                        }
                        else
                        {
                            MessageBox.Show("Услуга не выбрана.");
                            Debug.WriteLine("Service not selected.");
                        }
                    }

                    // Удаление услуг, которые были удалены пользователем
                    foreach (var existingService in existingServices)
                    {
                        if (!SelectedServices.Any(s => s.service_name?.service_name_id == existingService.service_name_id))
                        {
                            _context.service.Remove(existingService);
                        }
                    }

                    _context.SaveChanges();
                    LogTransaction(4, $"Доп. заказ c # {SelectedAdditionalOrder.additional_order_id}");
                    RequestClose?.Invoke();
                    MessageBox.Show("Изменения сохранены!");
                    Debug.WriteLine("Order and services saved successfully.");
                }
                else
                {
                    Debug.WriteLine("No existing order found.");
                }
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
