using _2022_09_27_Coursework_1st_Draft.objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace _2022_09_27_Coursework_1st_Draft.dbAccess
{
    class servicebookingDBAccess
    {
         Database db;
        public servicebookingDBAccess(Database db)
        {
            this.db = db;
        }
        public List<servicebooking> getAllServicebookings()
        {
            List<servicebooking> results = new List<servicebooking>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM ServiceBooking";
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                results.Add(getServicebookingsFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }


        public int AutoServiceBookingID()
        {
            int result = 1;
            int MaxID = 0;
            List<servicebooking> id = new List<servicebooking>();
            id = getAllServicebookings();
            foreach (servicebooking servicebooking in id)
            {
                if (result == servicebooking.ServicebookingID)
                {
                    MaxID = servicebooking.ServicebookingID;
                    result += 1;
                }
                else
                {
                    MaxID = servicebooking.ServicebookingID;
                }

            }
            if (result == MaxID)
            {
                result += 1;
            }
            return result;

        }
        public servicebooking getServicebookingsFromReader(SqlDataReader reader)
        {
            servicebooking newServiceBooking = new servicebooking();
            newServiceBooking.ServicebookingID = reader.GetInt32(0);
            newServiceBooking.ServiceID = reader.GetInt32(2);
            newServiceBooking.BookingID = reader.GetInt32(1);
     
            return newServiceBooking;
        }
        public void insertServiceBooking(int servicebookingID, int serviceFK, int bookingFK)
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "INSERT INTO ServiceBooking (servicebookingID, serviceFK, bookingFK) "
                + "VALUES (" + servicebookingID + ", " + serviceFK + ", " + bookingFK + ")";
            db.Cmd.ExecuteNonQuery();
        }
    }
}
