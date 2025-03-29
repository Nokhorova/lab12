using HotelProgram.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProgram.Repositories
{
    public class BookingRepository : RepositoryBase, IBookingRepository
    {
        private Hotel_bdEntities bookingContext = null;

        public BookingRepository()
        {
            bookingContext = new Hotel_bdEntities();
        }

        public void AddNewBooking(booking bookingModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO bookings (employee_id, client_id, room_id, tarif_id, booking_date_issue, booking_count_days, booking_date_departure, booking_count_persons, booking_count_childrens, booking_comment, booking_status_id, booking_total_cost, booking_prepayment) VALUES (@EmployeeId, @ClientId, @RoomId, @TarifId, @BookingDateIssue, @BookingCountDays, @BookingDateDeparture, @BookingCountPersons, @BookingCountChildrens, @BookingComment, @BookingStatusId, @BookingTotalCost, @BookingPrepayment)", connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", bookingModel.employee_id);
                    command.Parameters.AddWithValue("@ClientId", bookingModel.client_id);
                    command.Parameters.AddWithValue("@RoomId", bookingModel.room_id);
                    command.Parameters.AddWithValue("@TarifId", bookingModel.tarif_id);
                    command.Parameters.AddWithValue("@BookingDateIssue", bookingModel.booking_date_issue);
                    command.Parameters.AddWithValue("@BookingCountDays", bookingModel.booking_count_days);
                    command.Parameters.AddWithValue("@BookingDateDeparture", bookingModel.booking_date_departure);
                    command.Parameters.AddWithValue("@BookingCountPersons", bookingModel.booking_count_persons);
                    command.Parameters.AddWithValue("@BookingCountChildrens", bookingModel.booking_count_childrens);
                    command.Parameters.AddWithValue("@BookingComment", bookingModel.booking_comment);
                    command.Parameters.AddWithValue("@BookingStatusId", bookingModel.booking_status_id);
                    command.Parameters.AddWithValue("@BookingTotalCost", bookingModel.booking_total_cost);
                    command.Parameters.AddWithValue("@BookingPrepayment", bookingModel.booking_prepayment);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(booking bookingModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<booking> GetByAll()
        {
            throw new NotImplementedException();
        }

        public booking GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
