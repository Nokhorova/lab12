using DocumentFormat.OpenXml.Wordprocessing;
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
    public class NewTarifViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;

        public NewTarifViewModel(Hotel_bdEntities context, int employee_id)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _employee_id = employee_id;
        }
        public ObservableCollection<tarifs> Tarifs { get; set; }
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

        public ICommand SaveCommand => new RelayCommand(SaveNewTarif);

        private void SaveNewTarif()
        {
            var newTarif = new tarifs
            {
                tarif_name = TarifName,
                tarif_description = TarifDescription,
                tarif_cost = TarifCost
            };

            _context.tarifs.Add(newTarif);
            _context.SaveChanges();
            LogTransaction(1, $"Тариф c # {newTarif.tarif_id}");
            RequestClose?.Invoke();
            MessageBox.Show("Тариф создан!");
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
