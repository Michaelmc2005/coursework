using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_09_27_Coursework_1st_Draft.objects
{
    class customers
    {
        int customerID;
        string firstName, secondName,
        addressLine1, addressLine2, contactNumber, email,postcode, town;
        DateTime DOB;
        bool deleted;

        public customers()
        {

        }
        public customers(int customerID, string firstName, string secondName,
        string addressLine1, string addressLine2, string contactNumber,string email, string postcode, string town, DateTime DOB, bool deleted)
        {
            CustomerID = customerID;
            FirstName = firstName;
            SecondName = secondName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ContactNumber = contactNumber;
            Town = town;
            Postcode = postcode;
            Email = email;
            DDOB = DOB;
            Deleted = deleted;
        }

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }

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
        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }
        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }

        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string Town
        {
            get { return town; }
            set { town = value; }
        }
        public DateTime DDOB
        {
            get { return DOB; }
            set { DOB = value; }
        }
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}