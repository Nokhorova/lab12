using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProgram.ViewModels
{
    public class TransactionListViewModel : ViewModelBase
    {
        private Hotel_bdEntities _context;
        public ObservableCollection<transaction> Transactions { get; set; }
        public TransactionListViewModel(Hotel_bdEntities context)
        {
            _context = context;
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            Transactions = new ObservableCollection<transaction>(_context.transaction.Include("employees").Include("type_operation").ToList());
        }
    }
}
