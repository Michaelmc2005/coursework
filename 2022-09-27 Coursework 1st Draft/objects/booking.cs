using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_09_27_Coursework_1st_Draft.objects
{
    class booking
    {
        int bookingID, customerID, staffID;
        string startDate;
        bool completed;
         string bookingStartTime;
         string bookingFinishTime;
        decimal price;
        public booking()
        {

        }
        public booking(int bookingID, int customerID, string bookingStartTime, string bookingFinishTime, int staffID, string startDate, bool completed, decimal price)
        {
           
            BookingID = bookingID;
            CustomerID = customerID;
            StaffID = staffID;
            BookingFinishTime = bookingFinishTime;
            BookingStartTime = bookingStartTime;
            StartDate = startDate;
            Completed = completed;
            Price = price;

        }       
       
        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }

        }
         public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }

        }
       
        public int StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        public string BookingStartTime
        {
            get { return bookingStartTime; }
            set { bookingStartTime = value; }
        }
        public string BookingFinishTime
        {
            get { return bookingFinishTime; }
            set { bookingFinishTime = value; }
        }
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }

        }
    }
}