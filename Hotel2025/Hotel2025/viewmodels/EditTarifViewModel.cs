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
    public class EditTarifViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private tarifs _selectedTarifFromDataGrid;
        private int _employee_id;
        private Hotel_bdEntities _context;
        public EditTarifViewModel(Hotel_bdEntities context, tarifs selectedTarifFromDataGrid, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _selectedTarifFromDataGrid = selectedTarifFromDataGrid ?? throw new ArgumentNullException(nameof(selectedTarifFromDataGrid));
            _employee_id = employeeId;

            LoadTarifs();
        }
        public void LoadTarifs()
        {
            TarifId = _selectedTarifFromDataGrid.tarif_id;
            TarifName = _selectedTarifFromDataGrid.tarif_name;
            TarifDescription = _selectedTarifFromDataGrid.tarif_description;
            TarifCost = _selectedTarifFromDataGrid.tarif_cost;
        }
        public ObservableCollection<tarifs> Tarifs { get; set; }
        private int _tarifId;
        public int TarifId
        {
            get => _tarifId;
            set
            {
                _tarifId = value;
                OnPropertyChanged(nameof(TarifId));
            }
        }
        private string _tarifName;
        public string TarifName
        {
            get => _tarifName;
            set
            {
                _tarifName = value;
                OnPropertyChanged(nameof(TarifName));
            }
        }

        private string _tarifDescription;
        public string TarifDescription
        {
            get => _tarifDescription;
            set
            {
                _tarifDescription = value;
                OnPropertyChanged(nameof(TarifDescription));
            }
        }

        private decimal _tarifCost;
        public decimal TarifCost
        {
            get => _tarifCost;
            set
            {
                _tarifCost = value;
                OnPropertyChanged(nameof(TarifCost));
            }
        }
        public ICommand SaveCommand => new RelayCommand(SaveTarif);

        private void SaveTarif()
        {
            try
            {
                if (_selectedTarifFromDataGrid != null)
                {
                    var tarifToUpdate = _context.tarifs.FirstOrDefault(t => t.tarif_id == TarifId);
                    if (tarifToUpdate != null)
                    {
                        tarifToUpdate.tarif_name = TarifName;
                        tarifToUpdate.tarif_description = TarifDescription;
                        tarifToUpdate.tarif_cost = TarifCost;

                        _context.SaveChanges();
                        LoadTarifs();
                        LogTransaction(4, $"Тариф c # {_selectedTarifFromDataGrid.tarif_id}");
                        RequestClose?.Invoke();
                        MessageBox.Show("Изменения сохранены!");
                    }
                    else
                    {
                        // Handle case when service name with given ID is not found.
                        MessageBox.Show("Тариф не найден.");
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
