using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Input;
using HotelProgram.Views;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class ServicesViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        private int _employee_id;
        private int _department_id;
        public ServicesViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context;
            _employee_id = employeeId;
            _department_id = GetCurrentDepartmentId();
            LoadAdditionalOrders();
            LoadServiceNames();
        }

        public ObservableCollection<additional_orders> AdditionalOrders { get; set; }

        private void LoadAdditionalOrders()
        {
            var additionalOrders = _context.additional_orders
                .Include(a => a.service.Select(s => s.service_name)) // Включаем связанный сервис и его имя
                .Where(a => a.employee_id == _employee_id)
                .ToList();

            AdditionalOrders = new ObservableCollection<additional_orders>(additionalOrders);
        }
        public ObservableCollection<service_name> ServiceNames { get; set; }
        private void LoadServiceNames()
        {
            var serviceNames = _context.service_name.ToList();
            ServiceNames = new ObservableCollection<service_name>(serviceNames);
        }
        private ICommand createNewAdditionalOrderCommand;
        private ICommand createNewServiceNameCommand;

        // Delete Additional Order
        private ICommand _deleteAdditionalOrderCommand;
        public ICommand DeleteAdditionalOrderCommand => _deleteAdditionalOrderCommand ?? (_deleteAdditionalOrderCommand = new RelayCommand(DeleteAdditionalOrder));


        // Edit Additional Order
        private ICommand _editAdditionalOrderCommand;
        public ICommand EditAdditionalOrderCommand => _editAdditionalOrderCommand ?? (_editAdditionalOrderCommand = new RelayCommand(EditAdditionalOrder));


        // Delete Service Name
        private ICommand _deleteServiceNameCommand;
        public ICommand DeleteServiceNameCommand => _deleteServiceNameCommand ?? (_deleteServiceNameCommand = new RelayCommand(DeleteServiceName));


        // Edit Service Name
        private ICommand _editServiceNameCommand;
        public ICommand EditServiceNameCommand => _editServiceNameCommand ?? (_editServiceNameCommand = new RelayCommand(EditServiceName));


        private void EditAdditionalOrder(object parameter)
        {
            if (parameter is additional_orders selectedAdditionalOrder)
            {
                _employee_id = GetCurrentEmployeeId();
                if (_employee_id == 0)
                {
                    MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                    return;
                }
                var editViewModel = new EditServiceViewModel(_context, selectedAdditionalOrder, _employee_id);
                var editWindow = new EditServiceWindow(editViewModel);
                editWindow.ShowDialog();
                LoadAdditionalOrders();
            }
        }

        private void EditServiceName(object parameter)
        {
            try
            {
                if (_department_id == 1)
                {
                    MessageBox.Show("Не хватает прав доступа для редактирования услуги.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                if (parameter is service_name selectedServiceName)
                {
                    _employee_id = GetCurrentEmployeeId();
                    if (_employee_id == 0)
                    {
                        MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                        return;
                    }

                    var editViewModel = new EditServiceNameViewModel(_context, selectedServiceName, _employee_id);
                    var editWindow = new EditServiceNameWindow(editViewModel);
                    editWindow.ShowDialog();

                    LoadServiceNames();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ICommand CreateNewAdditionalOrderCommand
        {
            get
            {
                if (createNewAdditionalOrderCommand == null)
                {
                    createNewAdditionalOrderCommand = new RelayCommand(parameter => CreateNewAdditionalOrder());
                }
                return createNewAdditionalOrderCommand;
            }
        }
        public ICommand CreateNewServiceNameCommand
        {
            get
            {
                if (createNewServiceNameCommand == null)
                {
                    createNewServiceNameCommand = new RelayCommand(parameter => CreateNewService());
                }
                return createNewServiceNameCommand;
            }
        }
        private void CreateNewAdditionalOrder()
        {
            // Открытие окна для создания нового бронирования
            NewServiceWindow newServiceWindow = new NewServiceWindow();
            newServiceWindow.ShowDialog();
            LoadAdditionalOrders();
        }
        private void CreateNewService()
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для создания услуги.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            // Открытие окна для создания нового бронирования
            NewServiceNameWindow newServiceNameWindow = new NewServiceNameWindow();
            newServiceNameWindow.ShowDialog();
            LoadServiceNames();
        }
        private void DeleteAdditionalOrder(object parameter)
        {
            if (parameter is additional_orders selectedAdditionalOrder)
            {
                var existingOrder = _context.additional_orders
                    .Include(a => a.service)
                    .FirstOrDefault(order => order.additional_order_id == selectedAdditionalOrder.additional_order_id);

                if (existingOrder != null)
                {
                    // Удаление связанных услуг
                    foreach (var service in existingOrder.service.ToList())
                    {
                        _context.service.Remove(service);
                    }
                    // Показать диалоговое окно с вопросом
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить заказ с # {selectedAdditionalOrder.additional_order_id}?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButton.YesNo,
                                                 MessageBoxImage.Question);

                    // Если пользователь нажал "Yes", удалить запись
                    if (result == MessageBoxResult.Yes)
                    {
                        // Удаление самого заказа
                        _context.additional_orders.Remove(existingOrder);
                        _context.SaveChanges();
                        LogTransaction(7, $"Доп. заказ c # {selectedAdditionalOrder.additional_order_id}");
                        AdditionalOrders.Remove(selectedAdditionalOrder);
                        LoadAdditionalOrders();
                        MessageBox.Show("Запись успешно удалена!");
                    }
                }
            }
        }
        private void DeleteServiceName(object parameter)
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для удаления услуги.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (parameter is service_name selectedServiceName)
            {
                // Найти услугу в базе данных по service_name_id
                var serviceNameToDelete = _context.service_name.FirstOrDefault(sn => sn.service_name_id == selectedServiceName.service_name_id);

                if (serviceNameToDelete != null)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить услугу с ID # {selectedServiceName.service_name_id}?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButton.YesNo,
                                                 MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _context.service_name.Remove(serviceNameToDelete);
                        _context.SaveChanges();
                        LogTransaction(8, $"Услуга c # {selectedServiceName.service_name_id}");
                        ServiceNames.Remove(serviceNameToDelete);
                        LoadServiceNames();
                        MessageBox.Show("Запись успешно удалена!");
                    }
                }
                else
                {
                    // Обработка случая, когда услуга с указанным ID не найдена
                    MessageBox.Show("Услуга не найдена.");
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
