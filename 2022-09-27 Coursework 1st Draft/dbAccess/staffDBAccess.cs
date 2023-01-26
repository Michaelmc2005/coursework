using _2022_09_27_Coursework_1st_Draft.objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2022_09_27_Coursework_1st_Draft.dbAccess
{
    class staffDBAccess
    {
        private Database db;

        public staffDBAccess(Database db)
        {
            this.db = db;
        }

        public List<staff> getAllStaff()
        {
            List<staff> results = new List<staff>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM staff";
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                results.Add(getEmployeeFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

        

        public staff getAllStaffByID(int id)
        {
            staff newStaff = new staff();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM staff WHERE staffID =" + id;
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                newStaff.StaffID = db.Rdr.GetInt32(0);
                newStaff.FirstName = db.Rdr.GetString(1);
                newStaff.SecondName = db.Rdr.GetString(2);
                newStaff.ContactNumber = db.Rdr.GetString(3);
                newStaff.AddressLine1 = db.Rdr.GetString(4);
                newStaff.Dob = db.Rdr.GetString(5);
                newStaff.Deleted = db.Rdr.GetBoolean(6);
                newStaff.AccessLevel = db.Rdr.GetString(7);
                newStaff.LunchTime = db.Rdr.GetString(8);
            }
            db.Rdr.Close();
            return newStaff;
        }

        public staff getEmployeeFromReader(SqlDataReader reader)
        {
            staff newStaff = new staff();
            newStaff.StaffID = db.Rdr.GetInt32(0);
            newStaff.FirstName = db.Rdr.GetString(1);
            newStaff.SecondName = db.Rdr.GetString(2);
            newStaff.ContactNumber = db.Rdr.GetString(3);
            newStaff.AddressLine1 = db.Rdr.GetString(4);
            newStaff.Dob = db.Rdr.GetString(5);
            newStaff.Deleted = db.Rdr.GetBoolean(6);
            newStaff.AccessLevel = db.Rdr.GetString(7);
            newStaff.LunchTime = db.Rdr.GetString(8);
            return newStaff;
        }


    
    public void insertStaff(int staffID, string firstName, string secondName, string contactNumber, string addressLine1, string DOB, bool deleted, string lunchtime)
    {
        db.Cmd = db.Conn.CreateCommand();
        db.Cmd.CommandText = "INSERT INTO staff (staffID, firstName, secondName, contactNumber, addressLine1, DOB, deleted) "
            + "VALUES (" + staffID + ", '" + firstName + "','" + secondName + "', " + contactNumber + "', " + addressLine1 + "', " + DOB + "', " + deleted + "', '" + lunchtime + ")";
        db.Cmd.ExecuteNonQuery();
    }
}
}
