using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelProgram.ViewModels
{
    public class EditRoomViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private rooms _selectedRoomFromDataGrid;
        private int _employee_id;
        private Hotel_bdEntities _context;

        public EditRoomViewModel(Hotel_bdEntities context, rooms selectedRoomFromDataGrid, int employeeId)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _selectedRoomFromDataGrid = selectedRoomFromDataGrid ?? throw new ArgumentNullException(nameof(selectedRoomFromDataGrid));
            _employee_id = employeeId;

        }
    }
}
