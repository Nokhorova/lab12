using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProgram.ViewModels
{
    public class AddClientDataGridViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;

        public AddClientDataGridViewModel(Hotel_bdEntities context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            LoadClients();
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
                }
            }
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<clients>(_context.clients.ToList());
        }
    }
}
