using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HotelProgram.Views;
using System.Windows.Input;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class RoomsViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        private int _employee_id;
        private int _department_id;

        public RoomsViewModel(Hotel_bdEntities context, int employee_id)
        {
            _context = context;
            _employee_id = employee_id;
            _department_id = GetCurrentDepartmentId();
            LoadRooms();
        }
        public ObservableCollection<rooms> Rooms { get; set; }
        private void LoadRooms()
        {
            var rooms = _context.rooms
                .Include(r => r.room_type1)
                .Include(r => r.property_room.Select(pr => pr.property))
                .ToList();

            Rooms = new ObservableCollection<rooms>(rooms);
        }
        private ICommand createNewRoomCommand;

        // Delete Service Name
        private ICommand _deleteRoomCommand;
        public ICommand DeleteRoomCommand => _deleteRoomCommand ?? (_deleteRoomCommand = new RelayCommand(DeleteRoom));

        // Edit Service Name
        private ICommand _editRoomCommand;
        public ICommand EditRoomCommand => _editRoomCommand ?? (_editRoomCommand = new RelayCommand(EditRoom));
        private void EditRoom(object parameter)
        {
            try
            {
                if (_department_id == 1)
                {
                    MessageBox.Show("Не хватает прав доступа для редактирования номера.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                if (parameter is rooms selectedRoom)
                {
                    _employee_id = GetCurrentEmployeeId();
                    if (_employee_id == 0)
                    {
                        MessageBox.Show("Не удалось получить идентификатор сотрудника.");
                        return;
                    }

                    var editViewModel = new EditRoomViewModel(_context, selectedRoom, _employee_id);
                    var editWindow = new EditRoomWindow(editViewModel);
                    editWindow.ShowDialog();

                    LoadRooms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteRoom(object parameter)
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для удаления номер.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (parameter is rooms selectedRoom)
            {
                // Найти услугу в базе данных по service_name_id
                var roomToDelete = _context.rooms.FirstOrDefault(r => r.room_id == selectedRoom.room_id);

                if (roomToDelete != null)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить номер с ID # {selectedRoom.room_id}?",
                                                 "Подтверждение удаления",
                                                 MessageBoxButton.YesNo,
                                                 MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _context.rooms.Remove(roomToDelete);
                        _context.SaveChanges();
                        Rooms.Remove(roomToDelete);
                        LoadRooms();
                        MessageBox.Show("Запись успешно удалена!");
                    }
                }
                else
                {
                    // Обработка случая, когда услуга с указанным ID не найдена
                    MessageBox.Show("Номер не найдена.");
                }
            }
        }
        public ICommand CreateNewRoomCommand
        {
            get
            {
                if (createNewRoomCommand == null)
                {
                    createNewRoomCommand = new RelayCommand(parameter => CreateNewRoom());
                }
                return createNewRoomCommand;
            }
        }
        private void CreateNewRoom()
        {
            if (_department_id == 1)
            {
                MessageBox.Show("Не хватает прав доступа для создания номера.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            // Открытие окна для создания нового бронирования
            NewRoomWindow newRoomWindow = new NewRoomWindow();
            newRoomWindow.ShowDialog();
            LoadRooms();
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
