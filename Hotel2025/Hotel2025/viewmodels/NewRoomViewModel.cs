using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace HotelProgram.ViewModels
{
    public class NewRoomViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;
        private const int MaxServices = 6;
        private ObservableCollection<property_room> _selectedServices;

        public NewRoomViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context;
            _employee_id = employeeId;
            LoadRoomType();
            LoadProperty();
            AddServiceCommand = new RelayCommand(AddService, CanAddService);
            RemoveServiceCommand = new RelayCommand<property_room>(RemoveService, CanRemoveService);
            SelectedServices = new ObservableCollection<property_room>();
            SelectedServices.CollectionChanged += SelectedServices_CollectionChanged;
        }
        private void LoadProperty()
        {
            var _properties_ = _context.property.ToList();
            Properties = new ObservableCollection<property>(_properties_);
        }
        public RelayCommand AddServiceCommand { get; }
        public RelayCommand<property_room> RemoveServiceCommand { get; }
        public ObservableCollection<property> Properties { get; set; }
        public ObservableCollection<property_room> SelectedServices
        {
            get => _selectedServices;
            set
            {
                _selectedServices = value;
                OnPropertyChanged(nameof(SelectedServices));
            }
        }
        private void Service_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(property_room.property))
            {
            }
        }
        private void SelectedServices_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (property_room newService in e.NewItems)
                {
                    newService.PropertyChanged += Service_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (property_room oldService in e.OldItems)
                {
                    oldService.PropertyChanged -= Service_PropertyChanged;
                }
            }
        }
        private void AddService()
        {
            if (SelectedServices.Count < MaxServices)
            {
                var newService = new property_room();
                newService.PropertyChanged += Service_PropertyChanged;
                SelectedServices.Add(newService);
                AddServiceCommand.RaiseCanExecuteChanged();
                RemoveServiceCommand.RaiseCanExecuteChanged();
            }
        }

        private void RemoveService(property_room serviceToRemove)
        {
            serviceToRemove.PropertyChanged -= Service_PropertyChanged;
            SelectedServices.Remove(serviceToRemove);
            AddServiceCommand.RaiseCanExecuteChanged();
            RemoveServiceCommand.RaiseCanExecuteChanged();
        }
        private bool CanRemoveService(property_room service)
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
        public ObservableCollection<room_type> RoomType { get; set; }
        private int _roomTypetId;
        public int RoomTypeId
        {
            get { return _roomTypetId; }
            set
            {
                _roomTypetId = value;
                OnPropertyChanged(nameof(RoomTypeId));
            }
        }
        private room_type _selectedRoomType;
        public room_type SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                _selectedRoomType = value;
                OnPropertyChanged(nameof(SelectedRoomType));
            }
        }
        private void LoadRoomType()
        {
            var room_type_ = _context.room_type.ToList();
            RoomType = new ObservableCollection<room_type>(room_type_);
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
