using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_09_27_Coursework_1st_Draft.objects
{
    class service
    {
        int serviceID;
        string serviceName;
            int servicePrice;
        int duration;


        public service()
        {

        }
        public service(int serviceID, string serviceName, int servicePrice,
        int duration)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServicePrice = servicePrice;
            Duration = duration;

        }

        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }

        }
        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }
        public int ServicePrice
        {
            get { return servicePrice; }
            set { servicePrice = value; }
        }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

    }
}