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
    class discountDBAccess
    {
        private Database db;
        public discountDBAccess(Database db)
        {
            this.db = db;
        }
        //public List<discounts> getAllDiscounts()
        //{
        //    //List<discounts> results = new List<discounts>();
        //    //db.Cmd = db.Conn.CreateCommand();
        //    //db.Cmd.CommandText = "SELECT * FROM discounts";
        //    //db.Rdr = db.Cmd.ExecuteReader();
        //    //while (db.Rdr.Read())
        //    //{
        //    //    results.Add(getDiscountsFromReader(db.Rdr));
        //    //}
        //    //db.Rdr.Close();
        //    //return results;

        //}
        public discounts getDiscountsFromReader(SqlDataReader reader)
        {
            discounts newDiscounts = new discounts();
            newDiscounts.DiscountCode = reader.GetInt32(0);
            newDiscounts.DiscountValue = reader.GetInt32(1);
          
            return newDiscounts;

        }
        public void insertBooking(int DiscountCode, int DiscountValue)
        {

            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "INSERT INTO discounts (discountCode, discountValue) "
                + "VALUES (" + DiscountCode + ", " + DiscountValue + ")";
            db.Cmd.ExecuteNonQuery();
        }
    }
}
