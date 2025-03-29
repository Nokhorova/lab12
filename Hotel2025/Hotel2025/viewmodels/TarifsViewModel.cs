using HotelProgram.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelProgram.ViewModels
{
    public class TarifsViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        private int _employee_id;
        private int _department_id;

        public TarifsViewModel(Hotel_bdEntities context, int employee_id)
        {
            _context = context;
            _employee_id = employee_id;
            _department_id = GetCurrentDepartmentId();
            LoadTarifs();

        }
        public ObservableCollection<tarifs> Tarifs { get; set; }
        private void LoadTarifs()
        {
            var tarifs = _context.tarifs.ToList();
            Tarifs = new ObservableCollection<tarifs>(tarifs);
        }

        private ICommand createNewTarifCommand;

        // Delete Service Name
        private ICommand _deleteTarifCommand;
        public ICommand DeleteTarifeCommand => _deleteTarifCommand ?? (_deleteTarifCommand = new RelayCommand(DeleteTarif));

        // Edit Service Name
        private ICommand _editTarifCommand;
        public ICommand EditTarifCommand => _editTarifCommand ?? (_editTarifCommand = new RelayCommand(EditTarif));
        private void EditTarif(object parameter)
        {
            try
            {
                if (_department_id == 1)
                {
                    MessageBox.Show("Не хватает прав доступа для редактирования тарифа.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                if (parameter is tarifs selectedTarif)
                {
                    _employee_id = GetCurrentEmployeeId();
                    if (_employee_id == 0)
                    {
                        MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                        return;
                    }

                    var editViewModel = new EditTarifViewModel(_context, selectedTarif, _employee_id);
                    var editWindow = new EditTarifWindow(editViewModel);
                    editWindow.ShowDialog();

                    LoadTarifs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteTarif(object parameter)
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для удаления тарифа.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (parameter is tarifs selectedTarif)
            {
                // Найти услугу в базе данных по service_name_id
                var tarifToDelete = _context.tarifs.FirstOrDefault(sn => sn.tarif_id == selectedTarif.tarif_id);

                if (tarifToDelete != null)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить тариф с ID # {selectedTarif.tarif_id}?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButton.YesNo,
                                                 MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _context.tarifs.Remove(tarifToDelete);
                        _context.SaveChanges();
                        LogTransaction(7, $"Тариф c # {selectedTarif.tarif_id}");
                        Tarifs.Remove(tarifToDelete);
                        LoadTarifs();
                        MessageBox.Show("Запись успешно удалена!");
                    }
                }
                else
                {
                    // Обработка случая, когда услуга с указанным ID не найдена
                    MessageBox.Show("Тариф не найден.");
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
        public ICommand CreateNewTarifCommand
        {
            get
            {
                if (createNewTarifCommand == null)
                {
                    createNewTarifCommand = new RelayCommand(parameter => CreateNewTarif());
                }
                return createNewTarifCommand;
            }
        }
        private void CreateNewTarif()
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для создания тарифа.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            // Открытие окна для создания нового тарифа
            NewTarifWindow newTarifWindow = new NewTarifWindow();
            newTarifWindow.ShowDialog();
            LoadTarifs();
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
