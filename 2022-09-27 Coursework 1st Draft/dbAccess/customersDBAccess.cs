using _2022_09_27_Coursework_1st_Draft.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2022_09_27_Coursework_1st_Draft.dbAccess
{
    class customersDBAccess
    {
         Database db;

        public customersDBAccess(Database db)
        {
            this.db = db;
            db.connect();
        }

        public List<customers> GetCustomers()
        {
            List<customers> results = new List<customers>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM customers";
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                results.Add(getCustomerFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }

    

      

        public customers getCustomerFromReader(SqlDataReader reader)
        {
            customers newCustomer = new customers();
            newCustomer.CustomerID = reader.GetInt32(0);
            newCustomer.FirstName = reader.GetString(1);
            newCustomer.SecondName = db.Rdr.GetString(2);
            newCustomer.DDOB = db.Rdr.GetDateTime(3);
            newCustomer.AddressLine1 = db.Rdr.GetString(4);
            if (newCustomer.AddressLine2 != null)
            {
                newCustomer.AddressLine2 = db.Rdr.GetString(5);
            }
            newCustomer.Postcode = db.Rdr.GetString(6);
            newCustomer.Town = db.Rdr.GetString(7);
            newCustomer.Email = db.Rdr.GetString(8);
            newCustomer.ContactNumber = db.Rdr.GetString(9);
            newCustomer.Deleted = db.Rdr.GetBoolean(10);
            return newCustomer; 
        }
        public int AutoCustomerID()
        {
            int result = 1;
            int MaxID = 0;
            List<customers> id = new List<customers>();
            id = GetCustomers();
            foreach(customers customer in id)
            {
                if(result ==  customer.CustomerID)
                {
                    MaxID = customer.CustomerID;
                    result += 1;
                }
                else
                {
                    MaxID = customer.CustomerID;
                }

            }    
            if(result == MaxID)
            {
                result += 1;
            }
            return result;

        }
        public void insertCustomer(int customerID, string firstName,string secondName, string DOB, string addressLine1, string addressLine2, string postCode, string town, string emailAddress, string contactNumber, bool deleted)
        {

            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "INSERT INTO customers (customerID, firstName, secondName, DOB, addressLine1, addressLine2, postCode, town, emailAddress, contactNumber, deleted) "
                + "VALUES (" + customerID + ", '" + firstName + "', '" + secondName + "', '" + DOB + "', '" + addressLine1 + "', '" + addressLine2 + "', '" + postCode + "', '" + town + "', '" + emailAddress + "', '" + contactNumber + "', '" + deleted + "')";
            db.Cmd.ExecuteNonQuery();
        }
    }
}

