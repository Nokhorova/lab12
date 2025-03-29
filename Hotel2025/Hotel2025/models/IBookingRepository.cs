using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProgram.Models
{
    public interface IBookingRepository
    {
        void AddNewBooking(booking bookingModel);
        void Edit(booking bookingModel);
        void Remove(int id);
        booking GetById(int id);
        IEnumerable<booking> GetByAll();
    }
}
