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
    public class EditBookingViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private booking _selectedBooking;
        private int _employee_id;
        private Hotel_bdEntities _context;

        public EditBookingViewModel(Hotel_bdEntities context, booking selectedBooking, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _selectedBooking = selectedBooking ?? throw new ArgumentNullException(nameof(selectedBooking));

            _employee_id = employeeId;

            TarifList = new ObservableCollection<tarifs>();
            RoomsList = new ObservableCollection<rooms>();
            RoomsTypeList = new ObservableCollection<room_type>();
            BookingCountPersonList = new ObservableCollection<int>(Enumerable.Range(1, 6));
            BookingCountChildrensList = new ObservableCollection<int>(Enumerable.Range(0, 6));
            Clients = new ObservableCollection<clients>();

            LoadInitialValues();

            LoadTarifs();
            LoadRoomsType();
            LoadClients();
        }
        private void LoadInitialValues()
        {
            if (_selectedBooking != null)
            {
                // Устанавливаем значения свойств ViewModel на основе данных из _selectedBooking
                SelectedTarif = _context.tarifs.FirstOrDefault(t => t.tarif_id == _selectedBooking.tarif_id);
                SelectedRoom = _context.rooms.FirstOrDefault(r => r.room_id == _selectedBooking.room_id);

                if (SelectedRoom != null)
                {
                    SelectedRoomType = _context.room_type.FirstOrDefault(rt => rt.room_type_id == SelectedRoom.room_type);
                }
                else
                {
                    SelectedRoomType = null;
                }

                BookingDateIssue = _selectedBooking.booking_date_issue.Date;
                BookingTimeIssue = _selectedBooking.booking_date_issue.TimeOfDay;

                BookingDateDeparture = _selectedBooking.booking_date_departure.Date;
                BookingTimeDeparture = _selectedBooking.booking_date_departure.TimeOfDay;

                BookingCountDays = _selectedBooking.booking_count_days;
                SelectedBookingCountPerson = _selectedBooking.booking_count_persons;
                SelectedBookingCountChildrens = _selectedBooking.booking_count_childrens;
                BookingComment = _selectedBooking.booking_comment;
                BookingTotalCost = _selectedBooking.booking_total_cost;

                // Загрузка данных клиента
                SelectedClient = _context.clients.FirstOrDefault(c => c.client_id == _selectedBooking.client_id);
                if (SelectedClient != null)
                {
                    ClientLastName = SelectedClient.client_lastname;
                    ClientName = SelectedClient.client_name;
                    ClientSurName = SelectedClient.client_surname;
                    ClientContactNumber = SelectedClient.client_contact_number;
                    ClientEmail = SelectedClient.client_email;
                    ClientAddress = SelectedClient.client_address;
                }
            }
        }

        public booking Booking
        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
                OnPropertyChanged(nameof(Booking));
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
            get => _bookingDateTimeIssue;
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
            get => _bookingDateTimeDeparture;
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
        public ICommand SaveCommand => new RelayCommand(SaveChangesBooking);
        private void SaveChangesBooking(object parameter)
        {
            // Проверьте обязательные поля перед сохранением
            if (string.IsNullOrWhiteSpace(ClientLastName) ||
                string.IsNullOrWhiteSpace(ClientName) ||
                string.IsNullOrWhiteSpace(ClientSurName) ||
                string.IsNullOrWhiteSpace(ClientContactNumber) ||
                string.IsNullOrWhiteSpace(ClientEmail) ||
                string.IsNullOrWhiteSpace(ClientAddress) ||
                SelectedRoom == null ||
                SelectedTarif == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }
            // Поиск клиента по данным
            clients existingClient = FindClientByData(ClientLastName, ClientName, ClientSurName, ClientContactNumber, ClientEmail, ClientAddress);

            if (existingClient != null)
            {
                // Клиент существует, использовать его client_id для создания бронирования
                ConfirmChangesBooking(existingClient.client_id);
            }
            else
            {
                // Клиент не существует, создать нового клиента и использовать его client_id для создания бронирования
                existingClient = CreateNewClient(ClientLastName, ClientName, ClientSurName, ClientContactNumber, ClientEmail, ClientAddress);
                if (existingClient != null)
                {
                    ConfirmChangesBooking(existingClient.client_id);
                }
                else
                {
                    // Ошибка создания нового клиента
                    MessageBox.Show("Ошибка создания нового клиента");
                    // Обработка ошибки, если это необходимо
                }
            }
        }
        private clients FindClientByData(string lastName, string firstName, string surName, string contactNumber, string email, string address)
        {
            // Поиск клиента по данным
            return _context.clients.FirstOrDefault(c =>
                c.client_lastname == lastName &&
                c.client_name == firstName &&
                c.client_surname == surName &&
                c.client_contact_number == contactNumber &&
                c.client_email == email &&
                c.client_address == address);
        }

        private clients CreateNewClient(string lastName, string firstName, string surName, string contactNumber, string email, string address)
        {
            try
            {
                // Создание нового клиента
                var newClient = new clients
                {
                    client_lastname = lastName,
                    client_name = firstName,
                    client_surname = surName,
                    client_contact_number = contactNumber,
                    client_email = email,
                    client_address = address
                };

                // Добавление нового клиента в контекст базы данных
                _context.clients.Add(newClient);

                // Сохранение изменений в базе данных
                _context.SaveChanges();
                LogTransaction(1, $"Новый клиент c # {newClient.client_id}");

                // Возвращаем созданного клиента
                return newClient;
            }
            catch (Exception ex)
            {
                // Обработка ошибок создания нового клиента, если это необходимо
                Console.WriteLine("Ошибка создания нового клиента: " + ex.Message);
                return null;
            }
        }
        public void ConfirmChangesBooking(int clientId)
        {
            if (_employee_id != 0)
            {
                // Убедитесь, что _selectedBooking отслеживается контекстом
                var existingBooking = _context.booking.Find(_selectedBooking.booking_id);
                if (existingBooking != null)
                {
                    _context.Entry(existingBooking).CurrentValues.SetValues(_selectedBooking);
                    _selectedBooking = existingBooking;
                }
                else
                {
                    _context.booking.Attach(_selectedBooking);
                }

                _selectedBooking.employee_id = _employee_id;
                _selectedBooking.client_id = clientId;
                _selectedBooking.room_id = SelectedRoom.room_id;
                _selectedBooking.tarif_id = SelectedTarif.tarif_id;
                _selectedBooking.booking_date_issue = BookingDateTimeIssue;
                _selectedBooking.booking_count_days = BookingCountDays;
                _selectedBooking.booking_date_departure = BookingDateTimeDeparture;
                _selectedBooking.booking_count_persons = SelectedBookingCountPerson;
                _selectedBooking.booking_count_childrens = SelectedBookingCountChildrens;
                _selectedBooking.booking_status_id = 1;
                _selectedBooking.booking_comment = BookingComment;
                _selectedBooking.booking_total_cost = BookingTotalCost;

                // Добавление новой записи в контекст базы данных
                _context.Entry(_selectedBooking).State = System.Data.Entity.EntityState.Modified;


                try
                {
                    // Сохранение изменений в базе данных
                    _context.SaveChanges();
                    RequestClose?.Invoke();
                    LogTransaction(5, $"Бронирование c # {_selectedBooking.booking_id}");
                    MessageBox.Show("Изменения сохранены!");
                    // Опционально: добавьте логику для обновления представления после сохранения
                }
                catch (Exception ex)
                {
                    // Обработка ошибок сохранения, если это необходимо
                    var innerExceptionMessage = ex.InnerException?.Message;
                    MessageBox.Show($"Ошибка сохранения бронирования: {ex.Message}\n{innerExceptionMessage}");
                    // Опционально: добавьте логику для уведомления пользователя о неудаче сохранения
                }
            }
            else
            {
                MessageBox.Show("Не удалось получить идентификатор сотрудника");
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
