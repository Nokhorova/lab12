using HotelProgram.Models;
using HotelProgram.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelProgram.ViewModels
{
    public class BookingViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        private int _employee_id;
        public BookingViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context;
            _employee_id = employeeId;
            LoadBookings();
        }
        public ObservableCollection<booking> Bookings { get; set; }
        private void LoadBookings()
        {
            var bookings = _context.booking
                .Include(b => b.rooms)
                .Include(b => b.rooms.room_type1)
                .ToList();

            Bookings = new ObservableCollection<booking>(bookings);
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
        private ICommand createNewBookingCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        public ICommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(EditBooking));
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteBooking));

        private void EditBooking(object parameter)
        {
            if (parameter is booking selectedBooking)
            {
                _employee_id = GetCurrentEmployeeId();
                if (_employee_id == 0)
                {
                    MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                    return;
                }
                var editViewModel = new EditBookingViewModel(_context, selectedBooking, _employee_id);
                var editWindow = new EditBookingWindow(editViewModel);
                editWindow.ShowDialog();
            }
        }
        private void DeleteBooking(object parameter)
        {
            if (parameter is booking selectedBooking)
            {
                /// Проверка, существует ли объект в контексте
                var existingBooking = _context.booking.Find(selectedBooking.booking_id);
                if (existingBooking == null)
                {
                    // Если объект не отслеживается, присоединяем его к контексту
                    _context.booking.Attach(selectedBooking);
                    existingBooking = selectedBooking;
                }
                // Показать диалоговое окно с вопросом
                var result = MessageBox.Show($"Вы уверены, что хотите удалить бронирование с # {selectedBooking.booking_id}?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                // Если пользователь нажал "Yes", удалить запись
                if (result == MessageBoxResult.Yes)
                {
                    _context.booking.Remove(existingBooking);
                    _context.SaveChanges();
                    LogTransaction(9, $"Бронирование c # {selectedBooking.booking_id}");
                    Bookings.Remove(existingBooking);
                    MessageBox.Show("Запись успешно удалена!");
                }
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
        public ICommand CreateNewBookingCommand
        {
            get
            {
                if (createNewBookingCommand == null)
                {
                    createNewBookingCommand = new RelayCommand(parameter => CreateNewBooking());
                }
                return createNewBookingCommand;
            }
        }

        private void CreateNewBooking()
        {
            // Открытие окна для создания нового бронирования
            NewBookingWindow newBookingWindow = new NewBookingWindow();
            newBookingWindow.ShowDialog();
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
