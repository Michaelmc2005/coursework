using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_09_27_Coursework_1st_Draft.objects
{
    class staff
    {
        int staffID;
        string firstName, secondName, addressLine1, accessLevel, contactNumber;
        string DOB;
        bool deleted;
        string lunchTime;
        public staff()
        {

        }
        public staff(int staffID, string firstName, string secondName,
        string accessLevel, string contactNumber,string addressLine1, string DOB, bool deleted, string lunchTime)
        {
            StaffID = staffID;
            FirstName = firstName;
            SecondName = secondName;
            AccessLevel = accessLevel;
            ContactNumber = contactNumber;
            AddressLine1 = addressLine1;
            Dob = DOB;
            Deleted = deleted;
            LunchTime = lunchTime;
        }

        public int StaffID
        {
            get { return staffID; }
            set { staffID = value; }

        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
     
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }
        public string Dob
        {
            get { return DOB; }
            set { DOB = value; }
        }

        public string AccessLevel
        {
            get { return accessLevel; }
            set { accessLevel = value; }
        }
        public string LunchTime
        {
            get { return lunchTime; }
            set { lunchTime = value; }
        }
       

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}