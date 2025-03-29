using HandyControl.Tools;
using HotelProgram.Views;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelProgram.ViewModels
{
    public class NewBookingViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;

        public NewBookingViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _employee_id = employeeId;

            TarifList = new ObservableCollection<tarifs>();
            RoomsList = new ObservableCollection<rooms>();
            RoomsTypeList = new ObservableCollection<room_type>();
            BookingCountPersonList = new ObservableCollection<int>(Enumerable.Range(1, 6));
            BookingCountChildrensList = new ObservableCollection<int>(Enumerable.Range(0, 6));
            Clients = new ObservableCollection<clients>();

            LoadTarifs();
            LoadRoomsType();
            LoadClients();

            SaveCommandBooking = new RelayCommand(SaveBooking);
        }

        public ObservableCollection<tarifs> TarifList { get; set; }
        private tarifs _selectedTarif;
        public tarifs SelectedTarif
        {
            get
            {
                return _selectedTarif;
            }
            set
            {
                if (_selectedTarif != value)
                {
                    _selectedTarif = value;
                    OnPropertyChanged(nameof(SelectedTarif));
                    UpdateBookingTotalCost();
                }
            }
        }
        private void LoadTarifs()
        {
            TarifList = new ObservableCollection<tarifs>(_context.tarifs.ToList());
        }

        public ObservableCollection<rooms> RoomsList { get; set; }
        private rooms _selectedRoom;
        public rooms SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                if (_selectedRoom != value)
                {
                    _selectedRoom = value;
                    OnPropertyChanged(nameof(SelectedRoom));
                    UpdateBookingTotalCost();
                }
            }
        }
        private void LoadRooms()
        {
            if (SelectedRoomType != null)
            {
                RoomsList = new ObservableCollection<rooms>(_context.rooms.Where(r => r.room_type == SelectedRoomType.room_type_id).ToList());
            }
            else
            {
                RoomsList.Clear();
            }
            OnPropertyChanged(nameof(RoomsList));
        }

        public ObservableCollection<room_type> RoomsTypeList { get; set; }
        private room_type _selectedRoomType;
        public room_type SelectedRoomType
        {
            get
            {
                return _selectedRoomType;
            }
            set
            {
                if (_selectedRoomType != value)
                {
                    _selectedRoomType = value;
                    OnPropertyChanged(nameof(SelectedRoomType));
                    LoadRooms();
                    UpdateBookingTotalCost();
                }
            }
        }
        private void LoadRoomsType()
        {
            RoomsTypeList = new ObservableCollection<room_type>(_context.room_type.ToList());
        }

        public ObservableCollection<int> BookingCountPersonList { get; set; }
        private int _selectedBookingCountPerson;
        public int SelectedBookingCountPerson
        {
            get
            {
                return _selectedBookingCountPerson;
            }
            set
            {
                if (_selectedBookingCountPerson != value)
                {
                    _selectedBookingCountPerson = value;
                    OnPropertyChanged(nameof(SelectedBookingCountPerson));
                }
            }
        }
        public ObservableCollection<int> BookingCountChildrensList { get; set; }
        private int _selectedBookingCountChildrens;
        public int SelectedBookingCountChildrens
        {
            get
            {
                return _selectedBookingCountChildrens;
            }
            set
            {
                if (_selectedBookingCountChildrens != value)
                {
                    _selectedBookingCountChildrens = value;
                    OnPropertyChanged(nameof(SelectedBookingCountChildrens));
                }
            }
        }

        public ObservableCollection<clients> Clients { get; set; }

        private clients _selectedClient;
        public clients SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (_selectedClient != value)
                {
                    _selectedClient = value;
                    OnPropertyChanged(nameof(SelectedClient));
                    if (_selectedClient != null)
                    {
                        ClientLastName = _selectedClient.client_lastname;
                        ClientName = _selectedClient.client_name;
                        ClientSurName = _selectedClient.client_surname;
                        ClientContactNumber = _selectedClient.client_contact_number;
                        ClientEmail = _selectedClient.client_email;
                        ClientAddress = _selectedClient.client_address;
                    }
                }
            }
        }
        private void LoadClients()
        {
            Clients = new ObservableCollection<clients>(_context.clients.ToList());
        }
        private string _clientLastName;
        public string ClientLastName 
        { 
            get 
            {  
                return _clientLastName; 
            } 
            set 
            {
                if (_clientLastName != value)
                {
                    _clientLastName = value;
                    OnPropertyChanged(nameof(ClientLastName));
                }
            } 
        }

        private string _clientName;
        public string ClientName
        {
            get
            {
                return _clientName;
            }
            set
            {
                if (_clientName != value)
                {
                    _clientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }
        private string _clientSurName;
        public string ClientSurName
        {
            get
            {
                return _clientSurName;
            }
            set
            {
                if (_clientSurName != value)
                {
                    _clientSurName = value;
                    OnPropertyChanged(nameof(ClientSurName));
                }
            }
        }
        private string _clientContactNumber;
        public string ClientContactNumber
        {
            get
            {
                return _clientContactNumber;
            }
            set
            {
                if (_clientContactNumber != value)
                {
                    _clientContactNumber = value;
                    OnPropertyChanged(nameof(ClientContactNumber));
                }
            }
        }
        private string _clientEmail;
        public string ClientEmail
        {
            get
            {
                return _clientEmail;
            }
            set
            {
                if (_clientEmail != value)
                {
                    _clientEmail = value;
                    OnPropertyChanged(nameof(ClientEmail));
                }
            }
        }
        private string _clientAddress;
        public string ClientAddress
        {
            get
            {
                return _clientAddress;
            }
            set
            {
                if (_clientAddress != value)
                {
                    _clientAddress = value;
                    OnPropertyChanged(nameof(ClientAddress));
                }
            }
        }
        
        private DateTime _bookingDateTimeIssue = DateTime.Today.AddHours(14);
        public DateTime BookingDateTimeIssue 
        { 
            get  => _bookingDateTimeIssue; 
            set 
            {
                if (_bookingDateTimeIssue != value)
                {
                    _bookingDateTimeIssue = value;
                    OnPropertyChanged(nameof(BookingDateTimeIssue));
                    OnPropertyChanged(nameof(BookingDateIssue));
                    OnPropertyChanged(nameof(BookingTimeIssue));
                    UpdateBookingDateDeparture();
                }
            } 
        }

        public DateTime BookingDateIssue
        {
            get => BookingDateTimeIssue.Date;
            set
            {
                BookingDateTimeIssue = new DateTime(value.Year, value.Month, value.Day, BookingDateTimeIssue.Hour, BookingDateTimeIssue.Minute, BookingDateTimeIssue.Second);
            }
        }

        public TimeSpan BookingTimeIssue
        {
            get => BookingDateTimeIssue.TimeOfDay;
            set
            {
                BookingDateTimeIssue = new DateTime(BookingDateTimeIssue.Year, BookingDateTimeIssue.Month, BookingDateTimeIssue.Day, value.Hours, value.Minutes, value.Seconds);
            }
        }

        private DateTime _bookingDateTimeDeparture = DateTime.Today.AddHours(12);
        public DateTime BookingDateTimeDeparture 
        { 
            get  => _bookingDateTimeDeparture; 
            set 
            {
                if (_bookingDateTimeDeparture != value)
                {
                    _bookingDateTimeDeparture = value;
                    OnPropertyChanged(nameof(BookingDateTimeDeparture));
                    OnPropertyChanged(nameof(BookingDateDeparture));
                    OnPropertyChanged(nameof(BookingTimeDeparture));
                    UpdateBookingCountDays();
                }
            } 
        }

        public DateTime BookingDateDeparture
        {
            get => BookingDateTimeDeparture.Date;
            set
            {
                BookingDateTimeDeparture = new DateTime(value.Year, value.Month, value.Day, BookingDateTimeDeparture.Hour, BookingDateTimeDeparture.Minute, BookingDateTimeDeparture.Second);
                
            }
        }

        public TimeSpan BookingTimeDeparture
        {
            get => BookingDateTimeDeparture.TimeOfDay;
            set
            {
                BookingDateTimeDeparture = new DateTime(BookingDateTimeDeparture.Year, BookingDateTimeDeparture.Month, BookingDateTimeDeparture.Day, value.Hours, value.Minutes, value.Seconds);
            }
        }

        private int _bookingCountDays;
        public int BookingCountDays
        { 
            get 
            {  
                return _bookingCountDays; 
            } 
            set 
            {
                if (_bookingCountDays != value)
                {
                    _bookingCountDays = value;
                    OnPropertyChanged(nameof(BookingCountDays));
                    UpdateBookingDateDeparture();
                    UpdateBookingTotalCost();
                }
            } 
        }

        private void UpdateBookingDateDeparture()
        {
            BookingDateDeparture = BookingDateIssue.AddDays(BookingCountDays);
        }

        private void UpdateBookingCountDays()
        {
            BookingCountDays = (BookingDateDeparture - BookingDateIssue).Days;
        }

        private string _bookingComment;
        public string BookingComment 
        { 
            get 
            {  
                return _bookingComment; 
            } 
            set 
            {
                if (_bookingComment != value)
                {
                    _bookingComment = value;
                    OnPropertyChanged(nameof(BookingComment));
                }
            } 
        }

        private decimal _bookingTotalCost;
        public decimal BookingTotalCost
        {
            get { return _bookingTotalCost; }
            set
            {
                if (_bookingTotalCost != value)
                {
                    _bookingTotalCost = value;
                    OnPropertyChanged(nameof(BookingTotalCost));
                }
            }
        }

        private void UpdateBookingTotalCost()
        {
            if (SelectedRoomType != null && SelectedTarif != null && SelectedRoom != null)
            {
                decimal roomCost = SelectedRoomType.room_cost;
                decimal tarifCost = SelectedTarif.tarif_cost;
                BookingTotalCost = (BookingCountDays * roomCost) + tarifCost;
            }
        }

        public class RelayCommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;

            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
        }

        public ICommand SaveCommandBooking { get; }

        private void SaveBooking(object obj)
        {
            try
            {
                if (SelectedClient == null)
                {
                    MessageBox.Show("Пожалуйста выберите клиента.");
                    return;
                }

                if (_employee_id != 0)
                {
                    DateTime today = DateTime.Today;
                    int bookingStatusId;

                    if (today >= BookingDateTimeIssue && today <= BookingDateTimeDeparture)
                    {
                        bookingStatusId = 1; // В работе
                    }
                    else if (today < BookingDateTimeIssue)
                    {
                        bookingStatusId = 2; // Забронировано
                    }
                    else if (today > BookingDateTimeDeparture && today <= BookingDateTimeDeparture.AddDays(2))
                    {
                        bookingStatusId = 3; // На уборке
                    }
                    else
                    {
                        bookingStatusId = 4; // Выполнено
                    }

                    // Создание нового объекта Booking и заполнение его данными из ViewModel
                    booking newBooking = new booking
                    {
                        employee_id = _employee_id,
                        client_id = SelectedClient.client_id,
                        room_id = SelectedRoom.room_id,
                        tarif_id = SelectedTarif.tarif_id,
                        booking_date_issue = BookingDateTimeIssue,
                        booking_count_days = BookingCountDays,
                        booking_date_departure = BookingDateTimeDeparture,
                        booking_count_persons = SelectedBookingCountPerson,
                        booking_count_childrens = SelectedBookingCountChildrens,
                        booking_status_id = bookingStatusId,
                        booking_comment = BookingComment,
                        booking_total_cost = BookingTotalCost
                        // Дополните этот список свойств в соответствии с вашей моделью booking
                    };

                    _context.booking.Add(newBooking);
                    _context.SaveChanges();
                    LogTransaction(2, $"Бронирование c # {newBooking.booking_id}");
                    RequestClose?.Invoke();
                    MessageBox.Show("Бронирование создано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
