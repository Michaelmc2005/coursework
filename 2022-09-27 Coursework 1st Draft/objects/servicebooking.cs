using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_09_27_Coursework_1st_Draft.objects
{
    class servicebooking
    {
        int servicebookingID, serviceID, bookingID;
        public servicebooking()
        {

        }
        public servicebooking(int servicebookingID,int serviceID, int bookingID)
        {
            ServicebookingID = servicebookingID;
            ServiceID = serviceID;
            BookingID = bookingID;
        }


        public int ServicebookingID
        {
            get { return servicebookingID; }
            set { servicebookingID = value;  }
        }

        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }
        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
    }
}
