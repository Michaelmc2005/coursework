using _2022_09_27_Coursework_1st_Draft.objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2022_09_27_Coursework_1st_Draft.dbAccess
{
    class bookingDBAccess
    {
        private Database db;

        public bookingDBAccess(Database db)
        {
            this.db = db;
        }

        public List<booking> getAllBookings()
        {
            List<booking> results = new List<booking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM booking";
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                results.Add(getBookingsFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;

        }
       

        public int AutoBookingID()
        {
            int result = 1;
            int MaxID = 0;
            List<booking> id = new List<booking>();
            id = getAllBookings();
            foreach (booking booking in id)
            {
                if (result == booking.BookingID)
                {
                    MaxID = booking.BookingID;
                    result += 1;
                }
                else
                {
                    MaxID = booking.BookingID;
                }

            }
            if (result == MaxID)
            {
                result += 1;
            }
            return result;

        }
        public List<booking> getAllBookingsByDate(string date)
        {
            List<booking> results = new List<booking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM booking WHERE startDate = '" + date + "'";
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                results.Add(getBookingsFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }
        public booking getBookingsFromReader(SqlDataReader reader)
        {
            booking newBooking = new booking();
            newBooking.BookingID = reader.GetInt32(0);
            newBooking.CustomerID = reader.GetInt32(1);
            newBooking.StaffID = reader.GetInt32(2);
            newBooking.BookingStartTime = reader.GetString(3);
            newBooking.BookingFinishTime = reader.GetString(4);
            newBooking.StartDate = reader.GetString(5);
            newBooking.Completed = reader.GetBoolean(6);
            newBooking.Price = reader.GetDecimal(7);
            return newBooking;
            
        }
        public void insertBooking(int BookingID, int CustomerID, int StaffID, string BookingStartTime, string BookingFinishTime, string StartDate, bool Completed, decimal Price)
        {
           
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "INSERT INTO booking (bookingID, customerFK,  staffFK, startTime, startDateTime, completed, price ) "
                + "VALUES (" + BookingID + ", " + CustomerID + ", " + StaffID  + "', '" + BookingStartTime + "', '" + BookingFinishTime + "', '"  + StartDate + "', " + Completed + ", " + Price + ")";
            db.Cmd.ExecuteNonQuery();
        }

    }
}

