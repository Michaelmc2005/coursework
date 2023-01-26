using _2022_09_27_Coursework_1st_Draft.dbAccess;
using _2022_09_27_Coursework_1st_Draft.objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace _2022_09_27_Coursework_1st_Draft.gui
{
    public partial class BookingsForm : Template
    {
        int appmode = 0;
        private DataTable table;
        Database db;
        List<customers> CustomersList = new List<customers>();
        List<booking> BookingList = new List<booking>();
        List<staff> StaffList = new List<staff>();
        List<servicebooking> servicebookingsList = new List<servicebooking>();
        List<service> serviceList = new List<service>();
        List<discounts> DiscountsList = new List<discounts>();
        bookingDBAccess bookDBA;
        int ServiceID, StaffID;
        int currentServiceID;
        int columnIndex;
        int returnIndex;
        int EditbookingID;
        int slotsRequired;
        int[] bookingArray = new int[33]; //room and customer arrays have 32 slots to facilitate recording if any one of them has a booking for that slot
        int duration;
        decimal price;
        bool servicecheck;
        bool validation1, validation2, validation3, validation4, validation5, validation8, validation9;
        string previousBookDate;
        int[] custArray = new int[33];
        int[] staffArray = new int[33];
        List<string> startTimes = new List<string>() { " ", "10:00", "10:15", "10:30", "10:45", "11:00", "11:15", "11:30", "11:45", "12:00", "12:15", "12:30", "12:45", "13:00", "13:15", "13:30", "13:45", "14:00", "14:15", "14:30", "14:45", "15:00", "15:15", "15:30", "15:45", "16:00", "16:15", "16:30", "16:45", "17:00", "17:15", "17:30", "17:45" };

        public BookingsForm(Database db)
        {

            InitializeComponent();
            this.db = db;
            customersDBAccess customersDB = new customersDBAccess(db);
            bookDBA = new bookingDBAccess(db);
            staffDBAccess staffDB = new staffDBAccess(db);
            serviceDBAccess serviceDB = new serviceDBAccess(db);
            servicebookingDBAccess servicebookingDB = new servicebookingDBAccess(db);
            discountDBAccess discountDB = new discountDBAccess(db);
            //DiscountsList = discountDB.getAllDiscounts();
            CustomersList = customersDB.GetCustomers();
            BookingList = bookDBA.getAllBookings();
            StaffList = staffDB.getAllStaff();
            servicebookingsList = servicebookingDB.getAllServicebookings();
            serviceList = serviceDB.getAllServices();
            PopulateDisplay();
            createStaffTable(staffDB.getAllStaff());
            populateBookings();
            cmbFilterBox1.Text = "Name";


        }
        private void createStaffTable(List<staff> staffList)
        {

            table = new DataTable();
            table.Columns.Add("Staff Member");
            table.Columns.Add("10:00");
            table.Columns.Add("10:15");
            table.Columns.Add("10:30");
            table.Columns.Add("10:45");
            table.Columns.Add("11:00");
            table.Columns.Add("11:15");
            table.Columns.Add("11:30");
            table.Columns.Add("11:45");
            table.Columns.Add("12:00");
            table.Columns.Add("12:15");
            table.Columns.Add("12:30");
            table.Columns.Add("12:45");
            table.Columns.Add("13:00");
            table.Columns.Add("13:15");
            table.Columns.Add("13:30");
            table.Columns.Add("13:45");
            table.Columns.Add("14:00");
            table.Columns.Add("14:15");
            table.Columns.Add("14:30");
            table.Columns.Add("14:45");
            table.Columns.Add("15:00");
            table.Columns.Add("15:15");
            table.Columns.Add("15:30");
            table.Columns.Add("15:45");
            table.Columns.Add("16:00");
            table.Columns.Add("16:15");
            table.Columns.Add("16:30");
            table.Columns.Add("16:45");
            table.Columns.Add("17:00");
            table.Columns.Add("17:15");
            table.Columns.Add("17:30");
            table.Columns.Add("17:45");

            foreach (staff staff in staffList)
            {
                // Create a new row for the staff member
                DataRow row = table.NewRow();

                // Set the first column to be the staff member's name
                row[0] = staff.FirstName + " " + staff.SecondName;

                // Split the lunch time string into hours and minutes
                string[] lunchTimeParts = staff.LunchTime.Split(':');
                int lunchHour = int.Parse(lunchTimeParts[0]);
                int lunchMinute = int.Parse(lunchTimeParts[1]);

                // Calculate the column index for the lunch time
                int lunchColumnIndex = (lunchHour - 10) * 4 + (lunchMinute - (lunchMinute % 15)) / 15 + 1;

                // Set the value of the lunch time column to "Lunch"
                row[lunchColumnIndex] = "Lunch";

                // Add the row to the table
                table.Rows.Add(row);
            }
            DVStaff.DataSource = table;
            for (int i = 0; i < 33; i++)
            {
                DVStaff.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i != 0)
                    DVStaff.Columns[i].Width = 50;
                else
                    DVStaff.Columns[i].Width = 132;
            }

        }
        private void populateBookings()
        {
            foreach (booking booking in BookingList)
            {
                //fill appropriate slots
                if (booking.StartDate == DateTime.Now.ToShortDateString()) //if it is today's date (only want to populate today's bookings)
                {

                    populateSlots(booking);


                }
            }
        }
        private void populateSlots(booking booking)
        {
            int startElement = (Convert.ToDateTime(booking.BookingStartTime).Hour - 9) * 4; //get the array element corresponding to the hour.  % returns the remainder

            int slotsRequired = 0;
            //calculate how many slots are required to fulfil booking
            foreach (servicebooking servicebooking in servicebookingsList)
            {
                foreach (service service in serviceList)
                {
                    if (servicebooking.BookingID == booking.BookingID && servicebooking.ServiceID == service.ServiceID)
                        slotsRequired = service.Duration / 15;

                }
            }

            switch (Convert.ToDateTime(booking.BookingStartTime).Minute) //get the minute booking starts at e.g. 00,15,30,45 and then add the appropriate number to the start element
            {
                case 15:
                    startElement += 1;
                    break;
                case 30:
                    startElement += 2;
                    break;
                case 45:
                    startElement += 3;
                    break;
                default:
                    break;

            }


            for (int i = 0; i <= slotsRequired; i++)
            {
                int columnIndex = (startElement + i) % 33;//the orignal way i did it would not allow me to get past 17:15 
                DVStaff[columnIndex, 0].Style.BackColor = Color.Firebrick;
                staffArray[columnIndex] = 1; //set those slots in the room to taken so can't be double booked
            }

        }
        private void BookingsForm_Load(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DVStaff.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    cell.ReadOnly = true;
                }
            }
        }




        public void validations()
        {
            bool atleastoneischecked = false;

            if (cmbNails.Checked || cmbTanning.Checked || cmbHair.Checked || cmbMakeup.Checked || cmbWaxing.Checked)
            {
                atleastoneischecked = true;
            }
            else
            {
                atleastoneischecked = false;
            }
            validation2 = atleastoneischecked;

            if (validation1 == true && validation2 == true && validation3 == true && validation4 == true && validation8 == true && validation9 == true)
            {
                btnCreateBooking.Enabled = true;
            }
            else
            {
                btnCreateBooking.Enabled = false;
            }
            if (comboBox3.Text == "Off")
            {
                validation4 = false;
            }
            else
            {
                validation4 = true;
            }
            if (duration <= 0 || duration > 60)
            {
             
                label2.ForeColor = Color.Red;
            }
            else
            {

                label2.ForeColor = Color.Green;
            }

            if (comboBox3.Text == "")
            {

                btnCreateBooking.Enabled = false;
            }




        }



        private void displayCustomersBySearchFunction(List<customers> customers)
        {

            foreach (customers Customer1 in customers)
            {

                if ((Customer1.FirstName.ToLower() + " " + Customer1.SecondName.ToLower()).Contains(txtFilterBox.Text.ToLower()) && Customer1.Deleted == false && cmbFilterBox1.Text == "Name")
                {
                    listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName);
                }
                if ((Customer1.CustomerID.ToString().Contains(txtFilterBox.Text.ToLower())) && Customer1.Deleted == false && cmbFilterBox1.Text == "ID")
                {
                    listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName);
                }

            }

        }
        private void txtFilterBox_TextChanged(object sender, EventArgs e)
        {
            customersDBAccess cbda = new customersDBAccess(db);
            listBoxCustomers.Items.Clear();
            displayCustomersBySearchFunction(cbda.GetCustomers());
        }

        private void btnClearFilterBox_Click(object sender, EventArgs e)
        {
            txtFilterBox.Text = "";
            listBoxCustomers.Items.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CustomerID = null;
            int counter = 0;
            if (listBoxCustomers.SelectedItem == null)
            {
                return;
            }
            foreach (char ID in listBoxCustomers.SelectedItem.ToString())
            {
                if (counter <= 1)
                {
                    if (Char.IsNumber(ID))
                    {
                        CustomerID += ID;
                    }
                    counter++;
                }
                else
                {
                    break;
                }
                foreach (customers customers1 in CustomersList)
                {

                    if (Convert.ToString(customers1.CustomerID) == CustomerID) //populates the customer text box with the selected customer.
                    {
                        txtbID.Text = customers1.CustomerID.ToString();
                    }
                }

            }
        }

        private void btnClearFilterBox_Click_1(object sender, EventArgs e)
        {
            txtFilterBox.Text = "";
            txtbID.Text = "";
            listBoxCustomers.Items.Clear();

        }
        public void PopulateDisplay()
        {
            listBoxCustomers.Items.Clear();
            foreach (customers Customer1 in CustomersList)
            {
                if (Customer1.Deleted == false)
                {
                    listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName);
                }


            }



        }
        private List<int> GetserviceIDs()
        {
            List<int> services = new List<int>();
            if (cmbHair.Checked) services.Add(1);
            if (cmbNails.Checked) services.Add(2);
            if (cmbTanning.Checked) services.Add(3);
            if (cmbMakeup.Checked) services.Add(4);
            if (cmbWaxing.Checked) services.Add(5);
            return services;
        }



        public int GetStaffID()
        {

            if (comboBox3.Text == "Sarah McMahon")
            {
                StaffID = 1;
            }
            if (comboBox3.Text == "Michael McMahon")
            {
                StaffID = 2;
            }
            if (comboBox3.Text == "Dan Black")
            {
                StaffID = 3;
            }
            if (comboBox3.Text == "Joel McDade")
            {
                StaffID = 4;
            }

            return StaffID;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            txtFilterBox.Text = "";
            listBoxCustomers.Items.Clear();

        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Trim().Length < 1)
            {
                validation3 = false;

            }
            else
            {
                validation3 = true;
            }
            validations();
        }



        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text.Trim().Length < 1)
            {
                validation9 = false;

            }
            else
            {
                validation9 = true;
            }

        }

        private void dataViewTraining_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DVStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int returnColumnIndex(DataGridView dgv)
        {
            columnIndex = dgv.CurrentCell.ColumnIndex;
            return columnIndex;
        }


        private void DVStaff_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (appmode == 0)
            {
                validations();
                dateBookingSlots();
                int row = e.RowIndex;
                bool bookingOverlap = false;
                slotsRequired = duration / 15; //each slot is 15mins ie 4 per hour, dividing duration by 15 will give us how many are required
                returnIndex = returnColumnIndex(DVStaff); //return the index of the cell clicked on i.e. 0-31 for that particular room
                if (e.ColumnIndex >= 1 && e.ColumnIndex < DVStaff.ColumnCount)
                {
                    string time = DVStaff.Columns[e.ColumnIndex].HeaderText;
                    string[] timeParts = time.Split(':');
                    string hours = timeParts[0];
                    string minutes = timeParts[1];
                    comboBox1.Text = hours;
                    comboBox4.Text = minutes;
                }
                else
                {
                    MessageBox.Show("This is not a valid time slot.");
                    return;
                }
                if (e.RowIndex >= 0 && e.ColumnIndex > 0 && e.ColumnIndex < 33)
                {
                    // Get the staff name from the clicked cell
                    string staffName = DVStaff[0, e.RowIndex].Value.ToString();
                    comboBox3.Text = staffName;
                }
                else
                {
                    // Display a message to the user if the clicked cell is not a valid time slot
                    MessageBox.Show("This is not a time slot. Please select a cell in the table with a valid time slot.");
                    return;
                }
                if (returnIndex + slotsRequired > 33) //if the time taken will go beyond 18.00
                {
                    MessageBox.Show("Can't fit booking in");
                }

                else //i.e. time taken will not go beyond 18.00
                {
                    if (duration == 15)
                    {
                        if (DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Firebrick)
                        {
                            DVStaff.ClearSelection();
                            dateBookingSlots();
                            btnCreateBooking.Enabled = false;

                            MessageBox.Show("This booking does not fit into the selected time slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtbID.Text = "";
                            cmbTanning.Checked = false;
                            cmbWaxing.Checked = false;
                            cmbMakeup.Checked = false;
                            cmbHair.Checked = false;
                            cmbNails.Checked = false;
                            comboBox1.Text = "";
                            comboBox3.Text = "";
                            comboBox4.Text = "";

                            return;
                        }
                        else //i.e. this does not overlap an existing booking for the room              
                             // && checkStaff()) //if checkCustomer and checkStaff return true i.e. this doesn't overlap any existing customer or staff bookings

                            //set the appropriate number of slots red for the booking time and set the relevant array elements to 1 in both room and customer arrays

                            for (int j = 0; j < 4; j++)
                            {
                                for (int i = 0; i < slotsRequired; i++)
                                {
                                    DVStaff.Rows[row].Cells[returnIndex + i].Style.BackColor = Color.LightGreen;
                                    staffArray[returnIndex + i] = 1;
                                    custArray[returnIndex + i] = 1;
                                    //staffArray[returnIndex + i] = 1;
                                }
                            }

                    }
                    else if (duration == 30)
                    {
                        if (DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Firebrick || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Firebrick)
                        {
                            DVStaff.ClearSelection();
                            dateBookingSlots();
                            btnCreateBooking.Enabled = false;

                            MessageBox.Show("This booking does not fit into the selected time slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtbID.Text = "";
                            cmbTanning.Checked = false;
                            cmbWaxing.Checked = false;
                            cmbMakeup.Checked = false;
                            cmbHair.Checked = false;
                            cmbNails.Checked = false;
                            comboBox1.Text = "";
                            comboBox3.Text = "";
                            comboBox4.Text = "";
                            return;
                        }
                        else //i.e. this does not overlap an existing booking for the room              
                             // && checkStaff()) //if checkCustomer and checkStaff return true i.e. this doesn't overlap any existing customer or staff bookings

                            //set the appropriate number of slots red for the booking time and set the relevant array elements to 1 in both room and customer arrays

                            for (int j = 0; j < 4; j++)
                            {
                                for (int i = 0; i < slotsRequired; i++)
                                {
                                    DVStaff.Rows[row].Cells[returnIndex + i].Style.BackColor = Color.LightGreen;
                                    staffArray[returnIndex + i] = 1;
                                    custArray[returnIndex + i] = 1;
                                    //staffArray[returnIndex + i] = 1;
                                }
                            }

                    }
                    else if (duration == 45)
                    {
                        if (DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Firebrick || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Firebrick || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Style.BackColor == Color.Firebrick)
                        {
                            DVStaff.ClearSelection();
                            dateBookingSlots();
                            btnCreateBooking.Enabled = false;

                            MessageBox.Show("This booking does not fit into the selected time slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtbID.Text = "";
                            cmbTanning.Checked = false;
                            cmbWaxing.Checked = false;
                            cmbMakeup.Checked = false;
                            cmbHair.Checked = false;
                            cmbNails.Checked = false;
                            comboBox1.Text = "";
                            comboBox3.Text = "";
                            comboBox4.Text = "";
                            return;
                        }
                        else //i.e. this does not overlap an existing booking for the room              
                             // && checkStaff()) //if checkCustomer and checkStaff return true i.e. this doesn't overlap any existing customer or staff bookings

                            //set the appropriate number of slots red for the booking time and set the relevant array elements to 1 in both room and customer arrays

                            for (int j = 0; j < 4; j++)
                            {
                                for (int i = 0; i < slotsRequired; i++)
                                {
                                    DVStaff.Rows[row].Cells[returnIndex + i].Style.BackColor = Color.LightGreen;
                                    staffArray[returnIndex + i] = 1;
                                    custArray[returnIndex + i] = 1;
                                    //staffArray[returnIndex + i] = 1;
                                }
                            }

                    }
                    else if (duration == 60)
                    {
                        if (DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Firebrick || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Firebrick || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Style.BackColor == Color.Firebrick || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex + 3].Style.BackColor == Color.Firebrick)
                        {
                            DVStaff.ClearSelection();
                            dateBookingSlots();
                            btnCreateBooking.Enabled = false;

                            MessageBox.Show("This booking does not fit into the selected time slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtbID.Text = "";
                            cmbTanning.Checked = false;
                            cmbWaxing.Checked = false;
                            cmbMakeup.Checked = false;
                            cmbHair.Checked = false;
                            cmbNails.Checked = false;
                            comboBox1.Text = "";
                            comboBox3.Text = "";
                            comboBox4.Text = "";
                            return;
                        }
                        else //i.e. this does not overlap an existing booking for the room              
                             // && checkStaff()) //if checkCustomer and checkStaff return true i.e. this doesn't overlap any existing customer or staff bookings

                        {    //set the appropriate number of slots red for the booking time and set the relevant array elements to 1 in both room and customer arrays

                            for (int j = 0; j < 4; j++)
                            {
                                for (int i = 0; i < slotsRequired; i++)
                                {
                                    DVStaff.Rows[row].Cells[returnIndex + i].Style.BackColor = Color.LightGreen;
                                    staffArray[returnIndex + i] = 1;
                                    custArray[returnIndex + i] = 1;
                                    //staffArray[returnIndex + i] = 1;
                                }
                            }
                        }

                    }

                    bookingValidation();

                }



            }

            if (appmode == 1 || appmode == 2)
            {

                string time = DVStaff.Columns[e.ColumnIndex].HeaderText;
                if (e.RowIndex >= 0 && e.ColumnIndex > 0 && e.ColumnIndex < 33)
                {

                    cmbHair.Checked = false;
                    cmbNails.Checked = false;
                    cmbTanning.Checked = false;
                    cmbWaxing.Checked = false;
                    cmbMakeup.Checked = false;
                    int rowIndex = e.RowIndex + 1;

                    foreach (booking booking in BookingList)
                    {
                        


                            if (booking.StartDate == monthCalendar1.SelectionStart.ToShortDateString())
                            {
                                // Compare the booking's start or end time to the specified time
                                DateTime timeDateTime = DateTime.Parse(time);
                                DateTime bookingStartTime = DateTime.Parse(booking.BookingStartTime);
                                DateTime bookingFinishTime = DateTime.Parse(booking.BookingFinishTime);
                                bookingFinishTime = bookingFinishTime.AddMinutes(-15);

                                if (booking.StaffID == rowIndex && (timeDateTime >= bookingStartTime && timeDateTime <= bookingFinishTime) || (timeDateTime <= bookingStartTime && timeDateTime >= bookingFinishTime))
                                {


                                    // The booking's start or end time matches the specified time, so return the booking

                                    foreach (servicebooking servicebooking in servicebookingsList)
                                    {

                                        if (booking.BookingID == servicebooking.BookingID)
                                        {

                                            if (servicebooking.ServiceID == 1)
                                            {
                                                cmbHair.Checked = true;

                                            }

                                            if (servicebooking.ServiceID == 2)
                                            {
                                                cmbNails.Checked = true;

                                            }

                                            if (servicebooking.ServiceID == 3)
                                            {
                                                cmbTanning.Checked = true;

                                            }

                                            if (servicebooking.ServiceID == 4)
                                            {
                                                cmbMakeup.Checked = true;
                                            }

                                            if (servicebooking.ServiceID == 5)
                                            {
                                                cmbWaxing.Checked = true;
                                            }

                                            txtbID.Text = booking.CustomerID.ToString();



                                            time = booking.BookingStartTime;
                                            string[] timeParts = time.Split(':');
                                            string hours = timeParts[0];
                                            string minutes = timeParts[1];
                                            comboBox1.Text = hours;
                                            comboBox4.Text = minutes;

                                            comboBox1.Text = hours;
                                            comboBox4.Text = minutes;
                                            EditbookingID = booking.BookingID;
                                           if (booking.Completed == true)
                                           {
                                            checkBox1.Checked = true;
                                           }
                                        else 
                                        {
                                            checkBox1.Checked = false;
                                        }

                                        foreach (staff staff in StaffList)
                                                if (booking.StaffID == staff.StaffID)
                                                {
                                                    comboBox3.Text = staff.FirstName + " " + staff.SecondName;
                                                }
                                        if (appmode != 2)
                                        {
                                            comboBox3.Enabled = true;
                                            comboBox1.Enabled = true;
                                            comboBox4.Enabled = true;
                                            cmbHair.Enabled = true;
                                            cmbNails.Enabled = true;
                                            cmbMakeup.Enabled = true;
                                            cmbWaxing.Enabled = true;
                                            cmbTanning.Enabled = true;

                                        }
                                            editValidation();
                                        }
                                    }



                                }
                                if (DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green || DVStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.LightGreen)
                                {

                                    txtbID.Text = "";
                                    comboBox1.Text = "";
                                    comboBox3.Text = "";
                                    comboBox4.Text = "";
                                    comboBox1.Enabled = false;
                                    comboBox3.Enabled = false;
                                    comboBox4.Enabled = false;
                                    cmbHair.Checked = false;
                                    cmbNails.Checked = false;
                                    cmbMakeup.Checked = false;
                                    cmbTanning.Checked = false;
                                    cmbWaxing.Checked = false;
                                }
                            
                        }

                    }


                }
                else
                {
                    // Display a message to the user if the clicked cell is not a valid time slot
                    MessageBox.Show("This is not a time slot. Please select a cell in the table with a valid time slot.");
                    return;
                }





            }
        }

        public void dateBookingSlots() //change all bookings to red
        {

            defaultStaffTimes();
            string currentDate = monthCalendar1.SelectionStart.ToString().Substring(0, 10);
            foreach (booking booking in bookDBA.getAllBookingsByDate(currentDate))
            {
                if (booking.Completed == false)
                {
                    TimeSpan Length = Convert.ToDateTime(booking.BookingFinishTime).Subtract(Convert.ToDateTime(booking.BookingStartTime));
                    int bookingLength = Convert.ToInt32(Length.TotalMinutes);
                    if (Convert.ToDateTime(booking.BookingFinishTime) > Convert.ToDateTime("18:00"))
                    {
                        MessageBox.Show("The booking cannot go beyond the closing time of 6:00 PM.");
                        return;
                    }
                    for (int i = 1; i < startTimes.Count; i++)
                    {
                        if (bookingLength <= 15 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.Firebrick;
                        }
                        else if (bookingLength <= 30 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.Firebrick;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 1].Style.BackColor = Color.Firebrick;
                        }
                        else if (bookingLength <= 45 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.Firebrick;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 1].Style.BackColor = Color.Firebrick;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 2].Style.BackColor = Color.Firebrick;
                        }
                        else if (bookingLength <= 60 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.Firebrick;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 1].Style.BackColor = Color.Firebrick;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 2].Style.BackColor = Color.Firebrick;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 3].Style.BackColor = Color.Firebrick;
                        }
                    }
                }
                if (booking.Completed == true)
                {
                    TimeSpan Length = Convert.ToDateTime(booking.BookingFinishTime).Subtract(Convert.ToDateTime(booking.BookingStartTime));
                    int bookingLength = Convert.ToInt32(Length.TotalMinutes);
                    if (Convert.ToDateTime(booking.BookingFinishTime) > Convert.ToDateTime("18:00"))
                    {
                        MessageBox.Show("The booking cannot go beyond the closing time of 6:00 PM.");
                        return;
                    }
                    for (int i = 1; i < startTimes.Count; i++)
                    {
                        if (bookingLength <= 15 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.HotPink;
                        }
                        else if (bookingLength <= 30 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.HotPink;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 1].Style.BackColor = Color.HotPink;
                        }
                        else if (bookingLength <= 45 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.HotPink;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 1].Style.BackColor = Color.HotPink;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 2].Style.BackColor = Color.HotPink;
                        }
                        else if (bookingLength <= 60 && booking.BookingStartTime == startTimes[i])
                        {
                            DVStaff.Rows[booking.StaffID - 1].Cells[i].Style.BackColor = Color.HotPink;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 1].Style.BackColor = Color.HotPink;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 2].Style.BackColor = Color.HotPink;
                            DVStaff.Rows[booking.StaffID - 1].Cells[i + 3].Style.BackColor = Color.HotPink;
                        }
                    }
                }

            }

        }
        public void defaultStaffTimes()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (j == 0)
                    {
                        this.DVStaff.Rows[i].Cells[j].Style.BackColor = Color.Gainsboro;
                        this.DVStaff.Rows[i].Cells[j].Style.SelectionBackColor = Color.Gainsboro;
                        this.DVStaff.Rows[i].Cells[j].Style.SelectionForeColor = Color.Black;
                    }



                    else if (this.DVStaff.Rows[i].Cells[j].Value.ToString() == "Lunch")
                    {
                        this.DVStaff.Rows[i].Cells[j].Style.BackColor = Color.Firebrick;
                    }
                    else
                    {
                        this.DVStaff.Rows[i].Cells[j].Style.BackColor = Color.ForestGreen;
                        this.DVStaff.Rows[i].Cells[j].Style.SelectionBackColor = Color.LightGreen;
                    }
                    var date = monthCalendar1.SelectionStart;
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        if (i == 3 || i == 0)
                        {
                            this.DVStaff.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                            this.DVStaff.Rows[i].Cells[0].Style.BackColor = Color.Gainsboro;
                            comboBox3.Items.Clear();
                            comboBox3.Items.Add("Off");
                            comboBox3.Items.Add("Michael McMahon");
                            comboBox3.Items.Add("Dan Black");
                            comboBox3.Items.Add("Off");
                        }

                    }
                    else
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.Add("Sarah McMahon");
                        comboBox3.Items.Add("Michael McMahon");
                        comboBox3.Items.Add("Dan Black");
                        comboBox3.Items.Add("Joel McDade");
                    }
                }
            }
            DVStaff.RowTemplate.Height = 23;
        }

        private void DVStaff_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dateBookingSlots();
        }

        private void cmbNails_TextChanged(object sender, EventArgs e)
        {

        }



        private void DVStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.SelectionStart.ToString().Substring(0, 10) != previousBookDate)
            {
                dateBookingSlots();
                DVStaff.CurrentCell = DVStaff.Rows[0].Cells[0];
            }
            previousBookDate = monthCalendar1.SelectionStart.ToString().Substring(0, 10);

        }
        public bool editValidation()
        {


            int hour2 = int.Parse(comboBox1.Text);
            int minute2 = int.Parse(comboBox4.Text);
            int endHour2 = (hour2 * 60 + minute2 + duration) / 60;
            int endMinute2 = (hour2 * 60 + minute2 + duration) % 60;

            if (endHour2 > 18)
            {
                MessageBox.Show("Booking duration exceeds 6pm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }
            else if (endHour2 == 18 && endMinute2 > 0)
            {
                MessageBox.Show("Booking duration exceeds 6pm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }

            if (btnCreateBooking.Enabled == false)
            {
                return false;
            }
            else
            {
                return true;
            }

            return true;
        }
        public bool bookingValidation()
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please select a staff member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }

            if (DVStaff.CurrentCell.Style.BackColor == Color.Blue)
            {
                MessageBox.Show("The selected time is unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }
            if (DVStaff.CurrentCell.Style.BackColor == Color.Firebrick)
            {
                MessageBox.Show("The selected time is unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }
            else if (DVStaff.CurrentCell.Style.BackColor == Color.Gainsboro && comboBox4.Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("Please select a time slot", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }


            int hour = int.Parse(comboBox1.Text);
            int minute = int.Parse(comboBox4.Text);
            int endHour = (hour * 60 + minute + duration) / 60;
            int endMinute = (hour * 60 + minute + duration) % 60;

            if (endHour > 18)
            {
                MessageBox.Show("Booking duration exceeds 6pm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }
            else if (endHour == 18 && endMinute > 0)
            {
                MessageBox.Show("Booking duration exceeds 6pm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCreateBooking.Enabled = false;
            }

            if (btnCreateBooking.Enabled == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Length < 1)
            {
                validation8 = false;

            }
            else
            {
                validation8 = true;
            }
        }

        private void cmbNails_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbNails.Checked)
            {
                duration += 15;
                price += 30;


            }
            else if (!cmbNails.Checked)
            {
                duration -= 15;
                price -= 30;
            }
            lblDuration.Text = "Duration: " + duration.ToString() + " Minutes";
            lblPrice.Text = "Total Price: £" + price.ToString();


            DVStaff.ClearSelection();
            //dateBookingSlots();
            validations();


        }

        private void cmbHair_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbHair.Checked)
            {
                duration += 45;
                price += 50;

            }

            else if (!cmbHair.Checked)
            {
                duration -= 45;
                price -= 50;
            }
            DVStaff.ClearSelection();

            validations();
            lblDuration.Text = "Duration: " + duration.ToString() + " Minutes";
            lblPrice.Text = "Total Price: £" + price.ToString();
        }

        private void cmbTanning_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbTanning.Checked)
            {
                duration += 30;
                price += 20;
            }

            else
            {
                duration -= 30;
                price -= 20;
            }
            DVStaff.ClearSelection();

            validations();
            lblDuration.Text = "Duration: " + duration.ToString() + " Minutes";
            lblPrice.Text = "Total Price: £" + price.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (appmode == 0 || appmode == 2)
            {
                appmode = 1;
                AppmodeChange();
                dateBookingSlots();
                DVStaff.ClearSelection();
                button3.Text = "Add Booking";
                btnCreateBooking.Text = "Save Changes";
                label11.Visible = true;
                checkBox1.Visible = true;
                btnCreateBooking.Enabled = true;
                listBoxCustomers.Enabled = false;
                return;
            }
            else if (appmode == 1)
            {





                Form Form1 = new BookingsForm(db);
                Form1.Show();
                this.Close();

            }

        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new AddEditDeleteCustomers(db);
            Form1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (appmode != 2)
            {
                appmode = 2;
                listBoxCustomers.Enabled = false;
                label4.Text = "Remove a Booking";
                btnCreateBooking.Text = "Delete Booking";
                MessageBox.Show("Please Select a booking to delete");
                txtbID.Text = "";
                cmbHair.Checked = false;
                cmbNails.Checked = false;
                cmbWaxing.Checked = false;
                cmbTanning.Checked = false;
                cmbMakeup.Checked = false;
                comboBox1.Text = "";
                comboBox4.Text = "";
                comboBox3.Text = "";
                cmbHair.Enabled = false;
                cmbNails.Enabled = false;
                cmbWaxing.Enabled = false;
                cmbTanning.Enabled = false;
                cmbMakeup.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
                comboBox3.Enabled = false;
                DVStaff.ClearSelection();
                dateBookingSlots();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new MainMenu(db);
            Form1.Show();
        }

        private void cmbFilterBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new BookingsForm(db);
            Form1.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ;
        }

        private void txtDiscountCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            string colour = GenerateHexColor();
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(colour);
            panel3.BackColor = color;
        }
        private string GenerateHexColor()
        {
            Random random = new Random();
            string hexColor = "#";
            Regex forbiddenColors = new Regex("^#(8[0-9A-F]|9[0-9A]|A[0-9A])");

            while (true)
            {
                hexColor = "#";
                for (int i = 0; i < 6; i++)
                {
                    int randomNumber = random.Next(16);
                    hexColor += randomNumber.ToString("X");
                }

                if (!forbiddenColors.IsMatch(hexColor))
                    break;
            }
            return hexColor;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AppmodeChange() // sets labels, datagridview ect to be clear so that the page seems completely reloaded even if they have used the add mode.
        {
            if (button3.Text == "Add Booking")
            {
                label4.Text = "Confirm Your Booking";
                this.Hide();
                Form Form1 = new BookingsForm(db);
                Form1.Show();
            }
            if (button3.Text == "Edit Booking")
            {
                label4.Text = "Edit a Booking";
                MessageBox.Show("Please Select a booking to edit");
                txtbID.Text = "";
                cmbHair.Checked = false;
                cmbNails.Checked = false;
                cmbWaxing.Checked = false;
                cmbTanning.Checked = false;
                cmbMakeup.Checked = false;
                comboBox1.Text = "";
                comboBox4.Text = "";
                comboBox3.Text = "";
                DVStaff.ClearSelection();
                dateBookingSlots();



            }
        }
        private void cmbMakeup_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbMakeup.Checked)
            {
                duration += 45;
                price += 40;
            }
            else
            {
                duration -= 45;
                price -= 40;
            }
            DVStaff.ClearSelection();

            validations();
            lblDuration.Text = "Duration: " + duration.ToString() + " Minutes";
            lblPrice.Text = "Total Price: £" + price.ToString();
        }

        private void txtbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtbID_TextChanged(object sender, EventArgs e)
        {

            if (txtbID.Text.Trim().Length < 1)
            {
                validation1 = false;

            }
            else
            {
                validation1 = true;
            }
            validations();
        }

        private void cmbWaxing_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbWaxing.Checked)
            {
                duration += 15;
                price += 20;
            }
            else
            {
                duration -= 15;
                price -= 20;
            }
            DVStaff.ClearSelection();

            validations();
            lblDuration.Text = "Duration: " + duration.ToString() + " Minutes";
            lblPrice.Text = "Total Price: £" + price.ToString();
        }
        public string getfinishTime()
        {
            lblDuration.Text = "Duration: " + duration.ToString() + " Minutes";
            TimeSpan duration1 = new TimeSpan(00, duration, 00);
            TimeSpan finishtime = new TimeSpan(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox4.Text), 00);
            string finalfinishtime = finishtime.Add(duration1).ToString();
            return finalfinishtime;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (appmode == 0)
            {
                if (bookingValidation())
                {
                    if (label2.ForeColor == Color.Green)
                    {



                        DialogResult result = MessageBox.Show("Do you want to save this booking?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            int staffID = GetStaffID();
                            bookingDBAccess bookingDB = new bookingDBAccess(db);
                            servicebookingDBAccess servicebookingDBAccess = new servicebookingDBAccess(db);

                            string DateOfBooking = monthCalendar1.SelectionStart.ToString().Substring(0, 10);
                            DVStaff.ClearSelection();
                            DVStaff.CurrentCell = DVStaff.Rows[0].Cells[0];
                            dateBookingSlots();

                            List<int> services = GetserviceIDs();
                            int bookingID = bookingDB.AutoBookingID();
                            db.Cmd = db.Conn.CreateCommand();
                            TimeSpan duration1 = new TimeSpan(00, duration, 00);
                            TimeSpan finishtime = new TimeSpan(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox4.Text), 00);
                            string finalfinishtime = finishtime.Add(duration1).ToString();
                            string starttime = comboBox1.Text + ':' + comboBox4.Text;
                       
                            db.Cmd.CommandText = "INSERT INTO booking (bookingID, customerFK, staffFK, startTime,finishTime,StartDate, completed, price) VALUES (" + bookingID + ", " + Convert.ToInt32(txtbID.Text) + ", " + staffID + ",'" + starttime + "','" + getfinishTime() + "','" + DateOfBooking + "','" + false + "'," + price + ")";
                            db.Cmd.ExecuteNonQuery();
                            foreach (int service in services)
                            {
                                int servicebookingID = servicebookingDBAccess.AutoServiceBookingID();

                                db.Cmd = db.Conn.CreateCommand();
                                db.Cmd.CommandText = "INSERT INTO ServiceBooking (ServiceBookingID, BookingID, ServiceID) VALUES (" + servicebookingID + ", " + bookingID + ", " + service + ")";
                                db.Cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Booking Created.");
                            Form Form1 = new BookingsForm(db);
                            Form1.Show();
                            this.Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure your booking is less than 60 minutes long and a service has been selected.");
                        cmbHair.Checked = false;
                        cmbNails.Checked = false;
                        cmbMakeup.Checked = false;
                        cmbTanning.Checked = false;
                        cmbWaxing.Checked = false;
                        txtbID.Text = "";
                        comboBox3.Text = "";
                        comboBox1.Text = "";
                        comboBox4.Text = "";
                        return;
                    }

                }
                else
                {
                    return;
                }




            }
            if (appmode == 1)
            {
                if (editValidation())
                {
                    if (label2.ForeColor == Color.Green)
                    {
                        // Extract the start time for the new booking
                        string startTimeString = comboBox1.Text + ":" + comboBox4.Text;
                        DateTime startTime = DateTime.Parse(startTimeString);
                        // Calculate the end time of the new booking
                        DateTime endTime = startTime.AddMinutes(duration);

                        // Get the staff member's ID for the new booking
                        int staffId = GetStaffID();

                        // Loop through the bookings
                        foreach (booking booking in BookingList)
                        {
                            // Check if the staff member's ID is the same for both the new booking and the existing booking
                            if (booking.StaffID == staffId && booking.StartDate == monthCalendar1.SelectionStart.ToShortDateString())
                            {
                                // Extract the start and end times for the existing booking
                                DateTime bookingStartTime = DateTime.Parse(booking.BookingStartTime);
                                DateTime bookingEndTime = DateTime.Parse(booking.BookingFinishTime);

                                // Check if the existing booking is the one being edited
                                if (booking.BookingID != EditbookingID)
                                {
                                    // Check if the new booking's start time is between the start and end times of the existing booking
                                    if (startTime >= bookingStartTime && startTime < bookingEndTime)
                                    {
                                        // Bookings overlap
                                        MessageBox.Show("This booking overlaps with an existing booking", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    // Check if the new booking's end time is between the start and end times of the existing booking
                                    if (endTime > bookingStartTime && endTime <= bookingEndTime)
                                    {
                                        // Bookings overlap
                                        MessageBox.Show("This booking overlaps with an existing booking", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    // Check if the new booking completely encloses the existing booking
                                    if (startTime <= bookingStartTime && endTime >= bookingEndTime)
                                    {
                                        // Bookings overlap
                                        MessageBox.Show("This booking overlaps with an existing booking", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                // Get the staff member's ID for the new booking
                                int staffID = GetStaffID();

                                // Loop through the staff members
                                foreach (staff staff in StaffList)
                                {
                                    // Check if the staff member's ID is the same for the new booking and the current staff member
                                    if (staff.StaffID == staffID)
                                    {
                                        // Extract the lunch start time for the current staff member
                                        DateTime lunchStartTime = DateTime.Parse(staff.LunchTime);

                                        // Calculate the lunch end time for the current staff member (15 minutes after the start time)
                                        DateTime lunchEndTime = lunchStartTime.AddMinutes(15);

                                        // Check if the new booking's start time is between the start and end times of the staff member's lunchtime
                                        if (startTime >= lunchStartTime && startTime < lunchEndTime)
                                        {
                                            // Booking overlaps with lunchtime
                                            MessageBox.Show("This booking overlaps with the staff member's lunchtime", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        // Check if the new booking's end time is between the start and end times of the staff member's lunchtime
                                        if (endTime > lunchStartTime && endTime <= lunchEndTime)
                                        {
                                            // Booking overlaps with lunchtime
                                            MessageBox.Show("This booking overlaps with the staff member's lunchtime", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        // Check if the new booking completely encloses the staff member's lunchtime
                                        if (startTime <= lunchStartTime && endTime >= lunchEndTime)
                                        {
                                            // Booking overlaps with lunchtime
                                            MessageBox.Show("This booking overlaps with the staff member's lunchtime", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                            } // has to be here as edit validation is called else where.

                            servicebookingDBAccess servicebookingDBAccess = new servicebookingDBAccess(db);
                            string starttime = comboBox1.Text + ':' + comboBox4.Text;
                            TimeSpan duration1 = new TimeSpan(00, duration,00);
         
                            TimeSpan tempstarttime = new TimeSpan(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox4.Text),00);
                            string finalfinishtime = tempstarttime.Add(duration1).ToString();
                            string DateOfBooking = monthCalendar1.SelectionStart.ToString().Substring(0, 10);
                            bool completed = false;
                            List<int> services = GetserviceIDs();
                            if (checkBox1.Checked == true)
                            {
                                completed = true;
                            }
                            else
                            {
                                completed = false;
                            }
                            try
                            {
                                db.Conn.CreateCommand();
                                db.Cmd.CommandText = "UPDATE booking SET bookingID = @UpdatedBookingID, customerFK = @NewcustomerFK, staffFK = @NewstaffFK, startTime = @NewstartTime, finishTime = @NewfinishTime, startDate = @NewstartDate, price = @newprice, completed = @Newcompleted WHERE bookingID =" + EditbookingID;

                                db.Cmd.Parameters.AddWithValue("@UpdatedBookingID", EditbookingID);
                                db.Cmd.Parameters.AddWithValue("@NewcustomerFK", txtbID.Text);
                                db.Cmd.Parameters.AddWithValue("@NewstaffFK", GetStaffID());
                                db.Cmd.Parameters.AddWithValue("@NewstartTime", starttime);
                                db.Cmd.Parameters.AddWithValue("@NewfinishTime", finalfinishtime);
                                db.Cmd.Parameters.AddWithValue("@NewstartDate", DateOfBooking);
                                db.Cmd.Parameters.AddWithValue("@newprice", price);
                                db.Cmd.Parameters.AddWithValue("@Newcompleted", completed);
                                db.Cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                
                            }
                            


                            

                            List<int> selectedServiceIDs = GetserviceIDs();

                            // Retrieve the current servicebookings for the booking
                            Dictionary<int, int> currentServicebookings = new Dictionary<int, int>();
                            string sql = "SELECT ServiceBookingID, serviceID FROM servicebooking WHERE bookingID = @bookingID";
                            SqlCommand command = new SqlCommand(sql, db.Conn);
                            command.Parameters.AddWithValue("@bookingID", EditbookingID);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                currentServicebookings.Add(reader.GetInt32(0), reader.GetInt32(1));
                            }
                            reader.Close();


                            // Remove the servicebookings that are no longer needed
                            foreach (int serviceBookingID in currentServicebookings.Keys)
                            {
                                if (!selectedServiceIDs.Contains(currentServicebookings[serviceBookingID]))
                                {
                                    string deleteSql = "DELETE FROM servicebooking WHERE ServiceBookingID = @ServiceBookingID";
                                    SqlCommand deleteCommand = new SqlCommand(deleteSql, db.Conn);
                                    deleteCommand.Parameters.AddWithValue("@ServiceBookingID", serviceBookingID);
                                    deleteCommand.ExecuteNonQuery();
                                }
                            }

                            // Add new servicebookings for the selected services
                            foreach (int serviceID in selectedServiceIDs)
                            {
                                if (!currentServicebookings.Values.Contains(serviceID))
                                {
                                    // Generate a new ServiceBookingID using the AutoServiceBookingID method in the servicebookingdbaccess class
                                    int newServiceBookingID = servicebookingDBAccess.AutoServiceBookingID();

                                    string insertSql = "INSERT INTO servicebooking (ServiceBookingID, bookingID, serviceID) VALUES (@ServiceBookingID, @bookingID, @serviceID)";
                                    SqlCommand insertCommand = new SqlCommand(insertSql, db.Conn);
                                    insertCommand.Parameters.AddWithValue("@ServiceBookingID", newServiceBookingID);
                                    insertCommand.Parameters.AddWithValue("@bookingID", EditbookingID);
                                    insertCommand.Parameters.AddWithValue("@serviceID", serviceID);
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                            // Update the service IDs for the servicebookings that have been changed
                            foreach (int serviceBookingID in currentServicebookings.Keys)
                            {
                                if (selectedServiceIDs.Contains(currentServicebookings[serviceBookingID]) && !selectedServiceIDs.Contains(currentServicebookings[serviceBookingID]))
                                {
                                    string updateSql = "UPDATE servicebooking SET serviceID = @serviceID WHERE ServiceBookingID = @ServiceBookingID";
                                    SqlCommand updateCommand = new SqlCommand(updateSql, db.Conn);
                                    updateCommand.Parameters.AddWithValue("@serviceID", currentServicebookings[serviceBookingID]);
                                    updateCommand.Parameters.AddWithValue("@ServiceBookingID", serviceBookingID);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                          

                        }
                        MessageBox.Show("Saved Changes.");
                        Form Form1 = new BookingsForm(db);
                        Form1.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please make sure your booking is less than 60 minutes long and a service has been selected.");
                        cmbHair.Checked = false;
                        cmbNails.Checked = false;
                        cmbMakeup.Checked = false;
                        cmbTanning.Checked = false;
                        cmbWaxing.Checked = false;
                        txtbID.Text = "";
                        comboBox3.Enabled = true;
                        
             
           
                        return;
                    }
                    
                    }
                }
            if (appmode == 2)
            {
                int customerID = int.Parse(txtbID.Text);
                int staffID = GetStaffID();
                string startTime = comboBox1.Text + ":" + comboBox4.Text;
                string endTime = getfinishTime();




                // Loop through the bookings
                foreach (booking booking in BookingList)
                {
                    // Check if the customerID, staffID, startTime, and endTime match the values in the textboxes
                    if (booking.CustomerID == customerID && booking.StaffID == staffID && booking.BookingStartTime == startTime && booking.BookingFinishTime == endTime)
                    {
                        // Booking found, get the bookingID
                        int bookingID = booking.BookingID;


                        string deletesql = "DELETE FROM ServiceBooking WHERE BookingID = @BookingID";
                        SqlCommand deleteCommand = new SqlCommand(deletesql, db.Conn);
                        deleteCommand.Parameters.AddWithValue("@BookingID", bookingID);
                        deleteCommand.ExecuteNonQuery();
                        string deletebookingssql = "DELETE FROM Booking WHERE BookingID = @BookingID";
                        SqlCommand deletebookingsCommand = new SqlCommand(deletebookingssql, db.Conn);
                        deletebookingsCommand.Parameters.AddWithValue("@BookingID", bookingID);
                        deletebookingsCommand.ExecuteNonQuery();
                       

                    }

                }
                MessageBox.Show("Booking Removed!");
                Form Form1 = new BookingsForm(db);
                Form1.Show();
                this.Close();



            }
        }



        }
    }

