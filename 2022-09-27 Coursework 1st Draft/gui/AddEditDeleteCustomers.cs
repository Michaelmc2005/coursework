using _2022_09_27_Coursework_1st_Draft.dbAccess;
using _2022_09_27_Coursework_1st_Draft.objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace _2022_09_27_Coursework_1st_Draft.gui
{
    public partial class AddEditDeleteCustomers : Template
    {
    
        Database db;
        List<customers> CustomersList = new List<customers>();
        int AppMode = 0; //0 = add, 1 = edit, 2 = delete
        string tempcustID;
        

        public AddEditDeleteCustomers(Database db)
        {
       
            InitializeComponent();
            this.db = db;
            customersDBAccess customersDBAccess = new customersDBAccess(db);

        

            CustomersList = customersDBAccess.GetCustomers();
            PopulateDisplay();
            cmbFilterBox1.Text = "Name";
            cmbFilterBox2.Text = "Active";

     
        }
      
        public void PopulateDisplay()
        {
            listBoxCustomers.Items.Clear();
            foreach (customers Customer1 in CustomersList)
            {
                if (Customer1.Deleted == false && cmbFilterBox1.Text != "Deleted")
                {
                    listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName + " -" + "Active");
                }
                
                
            }
            


        }
        private void AddEditDeleteCustomers_Load(object sender, EventArgs e)
        {
         

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
       
        private void button8_Click_1(object sender, EventArgs e)
        {
          
            if (AppMode == 0)
            {
                if (txtbFirstName.Enabled == false)
                {
                    btnMultiFunction.Enabled = false;
                }
                if (txtbFirstName.Text.Trim() == "" || txtbSurName.Text.Trim() == "")
                {
                    
                    MessageBox.Show("Please enter a full name.");
                    return;
                }
                if (txtbFirstName.Text.Trim().Length <= 1)
                {
                   
                }
                foreach (customers customers1 in CustomersList)
                {
                    if (txtbFirstName.Text == customers1.FirstName && txtbSurName.Text == customers1.SecondName && txtbContactNumber.Text == customers1.ContactNumber)
                    {
                        DialogResult result = MessageBox.Show("This customer is already similar to an existing customer. Are you sure you wish to continue?", "Warning",
                          MessageBoxButtons.YesNo);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                {
                                    continue;
                                }



                            case DialogResult.No:
                                {

                                    return;
                                }
                        }
                        }
                    }
                if (txtbAddressLine1.Text.Trim() != "" && cmbDay.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbYear.Text.Trim() != "" && txtbContactNumber.Text.Trim() != "")
                {
             
                   
                    

                    if (txtbContactNumber.Text.Length == 11)
                    {
                        customersDBAccess cbda = new customersDBAccess(db);
                        int customerID = cbda.AutoCustomerID();
                        string customerFirstName = txtbFirstName.Text.Trim();
                        string customerSurname = txtbSurName.Text.Trim();
                        string addressLine1 = txtbAddressLine1.Text.Trim();
                        string addressLine2 = txtbAddressLine2.Text.Trim();
                        string postcode = txtbPostcode.Text.Trim();
                        string town = txtbTown.Text.Trim();
                        string email = txtbEmail.Text.Trim();
                        string contactnumber = txtbContactNumber.Text.Trim();
                        string customerDOB = cmbYear.Text + "/" + cmbMonth.Text + "/" + cmbDay.Text;
                        bool customerDeleted = false;
                        cbda.insertCustomer(customerID, customerFirstName, customerSurname, customerDOB, addressLine1, addressLine2, postcode, town, email, contactnumber, customerDeleted);
                        PopulateDisplay();
                        MessageBox.Show("Customer Added");
                        Form Form1 = new AddEditDeleteCustomers(db);
                        Form1.Show();
                        this.Close();
                    }
                   else
                    {
                        MessageBox.Show("Contact Number must be 11 characters long.");
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure that all text boxes contain a value. Changes have not been saved.");

                }
            }
            if (AppMode == 1)
            {

                
                    if (txtbFirstName.Text.Trim() != "" && txtbSurName.Text.Trim() != "" && txtbAddressLine1.Text.Trim() != "" && cmbDay.Text.Trim() != "" && cmbMonth.Text.Trim() != "" && cmbYear.Text.Trim() != "" && txtbContactNumber.Text.Trim() != "")
                    {
                   
                      
                        foreach (customers customers1 in CustomersList)
                        {
                        

                           if (customers1.CustomerID.ToString() == tempcustID)
                        {   if (customers1.Deleted == true)
                            {
                                MessageBox.Show("You cannot edit deleted customers.");
                                break;
                            }
                            if (txtbContactNumber.Text.Length == 11)
                            {
                                DialogResult result = MessageBox.Show("Are you sure you want to save this customer?", "Warning",
                            MessageBoxButtons.YesNo);
                                switch (result)
                                {
                                    case DialogResult.Yes:
                                        {
                                            if (customers1.Deleted == false)
                                            {
                                                db.Conn.CreateCommand();
                                                db.Cmd.CommandText = "UPDATE customers SET firstName = @NewfirstName, secondName = @NewsecondName, DOB = @NewDOB, addressLine1 = @NewaddressLine1, addressLine2 = @NewaddressLine2, @NewpostCode = postcode, @newtown = town, @newemailAddress = emailAddress, contactNumber = @NewcontactNumber WHERE customerID =" + customers1.CustomerID;

                                                db.Cmd.Parameters.AddWithValue("@NewfirstName", txtbFirstName.Text);
                                                db.Cmd.Parameters.AddWithValue("NewsecondName", txtbSurName.Text);
                                                db.Cmd.Parameters.AddWithValue("NewDOB", cmbYear.Text + "/" + cmbMonth.Text + "/" + cmbDay.Text);
                                                db.Cmd.Parameters.AddWithValue("@NewaddressLine1", txtbAddressLine1.Text);
                                                db.Cmd.Parameters.AddWithValue("@NewaddressLine2", txtbAddressLine2.Text);
                                                db.Cmd.Parameters.AddWithValue("@NewpostCode", txtbPostcode.Text);
                                                db.Cmd.Parameters.AddWithValue("@Newtown", txtbTown.Text);
                                                db.Cmd.Parameters.AddWithValue("@NewemailAddress", txtbEmail.Text);
                                                db.Cmd.Parameters.AddWithValue("@NewcontactNumber", txtbContactNumber.Text);
                                                db.Cmd.ExecuteNonQuery();
                                                MessageBox.Show("Saved Changes.");
                                                Form Form1 = new AddEditDeleteCustomers(db);
                                                Form1.Show();
                                                this.Close();
                                            }


                                            break;
                                        }
                                    case DialogResult.No:
                                        {
                                            MessageBox.Show("This user has not been saved");
                                            break;
                                        }
                                }
                            }
                            else { MessageBox.Show("Contact Number must be exactly 11 digits."); }
                        
                          }
                      
                        }
                  
                    }
                    else
                    {
                        MessageBox.Show("Please ensure that all text boxes contain a value. Changes have not been saved.");
                    }
            }
            if (AppMode == 2)
            {
                if (txtbFirstName.Text.Trim() != "" && txtbSurName.Text.Trim() != "")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Warning",
                 MessageBoxButtons.YesNo);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                foreach (customers customers1 in CustomersList)
                                {
                                    if (customers1.CustomerID.ToString() == tempcustID && customers1.Deleted == false)
                                    {
                                        db.Conn.CreateCommand();
                                        db.Cmd.CommandText = "UPDATE customers SET deleted = @Newdeleted WHERE customerID =" + customers1.CustomerID;
                                        db.Cmd.Parameters.AddWithValue("@Newdeleted", 1);
                                        db.Cmd.ExecuteNonQuery();
                                        MessageBox.Show("Customer Deleted");
                                        Form Form1 = new AddEditDeleteCustomers(db);
                                        Form1.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Unable to Delete customer - Customer already deleted");
                                    }
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                MessageBox.Show("This user has not been deleted");
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a customer to be deleted.");
                }
            }
        }

            
        
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                customersDBAccess cbda = new customersDBAccess(db);
                listBoxCustomers.Items.Clear(); 
                displayCustomersBySearchFunction(cbda.GetCustomers());
            
           
        }
        private void displayCustomersBySearchFunction(List<customers> customers)
        {
            
            foreach(customers Customer1 in customers)
            {
                if (cmbFilterBox2.Text == "Active")
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
                if (cmbFilterBox2.Text == "Deleted")
                {
                    if ((Customer1.FirstName.ToLower() + " " + Customer1.SecondName.ToLower()).Contains(txtFilterBox.Text.ToLower()) && Customer1.Deleted == true && cmbFilterBox1.Text == "Name")
                    {
                        listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName);
                    }
                    if ((Customer1.CustomerID.ToString().Contains(txtFilterBox.Text.ToLower())) && Customer1.Deleted == true && cmbFilterBox1.Text == "ID")
                    {
                        listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName);
                    }
                }
            }
             
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtFilterBox.Text = "";
            listBoxCustomers.Items.Clear();
            PopulateDisplay();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppMode = 0;
            btnAddDisplay.BackColor = Color.DarkGreen;
            btnEditDisplay.BackColor = Color.ForestGreen;
            btnDeleteDisplay.BackColor = Color.ForestGreen;
   
            LblTitle.Text = "Add New Customer";
            txtbAddressLine1.Text = "";
            txtbAddressLine2.Text = "";
            txtbContactNumber.Text = "";
            txtbFirstName.Text = "";
            txtbSurName.Text = "";
            cmbDay.Text = " ";
            cmbMonth.Text = " ";
            cmbYear.Text = " ";
            txtbPostcode.Text = "";
            txtbTown.Text = " ";
            txtbEmail.Text = "";
            btnMultiFunction.Text = "Add Customer";
            txtbAddressLine1.Enabled = true;
            txtbAddressLine2.Enabled = true;
            txtbContactNumber.Enabled = true;
            txtbEmail.Enabled = true;
            txtbTown.Enabled = true;
            txtbPostcode.Enabled = true;
            txtbFirstName.Enabled = true;
            txtbSurName.Enabled = true;
            cmbDay.Enabled = true;
            cmbMonth.Enabled = true;
            cmbYear.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AppMode = 1;
            btnEditDisplay.BackColor = Color.DarkGreen;
            btnAddDisplay.BackColor = Color.ForestGreen;
            btnDeleteDisplay.BackColor = Color.ForestGreen;
     
            LblTitle.Text = "Edit Customer";
            btnMultiFunction.Text = "Edit Customer";
            txtbAddressLine1.Enabled = true;
            txtbAddressLine2.Enabled = true;
            txtbContactNumber.Enabled = true;
            txtbFirstName.Enabled = true;
            txtbSurName.Enabled = true;
            txtbEmail.Enabled = true;
            txtbTown.Enabled = true;
            txtbPostcode.Enabled = true;
            cmbDay.Enabled = true;
            cmbMonth.Enabled = true;
            cmbYear.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            btnMultiFunction.Enabled = true;
            AppMode = 2;
            btnEditDisplay.BackColor = Color.ForestGreen;
            btnAddDisplay.BackColor = Color.ForestGreen;
            btnDeleteDisplay.BackColor = Color.DarkGreen;

            LblTitle.Text = "Delete Customer";
            btnMultiFunction.Text = "Delete Customer";
            txtbAddressLine1.Enabled = false;
            txtbAddressLine2.Enabled = false;
            txtbContactNumber.Enabled = false;
            txtbEmail.Enabled = false;
            txtbTown.Enabled = false;
            txtbPostcode.Enabled = false;
            txtbFirstName.Enabled = false;
            txtbSurName.Enabled = false;
            cmbDay.Enabled = false;
            cmbMonth.Enabled = false;
            cmbYear.Enabled = false;

        }


        private void listBoxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool askedbefore = false;
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

                }
                
                foreach (customers customers1 in CustomersList)
                {

                    if (Convert.ToString(customers1.CustomerID) == CustomerID && customers1.Deleted == true && askedbefore == false)
                    {
                        MessageBox.Show("This customer has already been deleted. You cannot edit or delete this user again. However the data will be displayed.");
                       

                    }
        
                    if (Convert.ToString(customers1.CustomerID) == CustomerID) //populates the customer text box with the selected customer.
                    {
                        txtbFirstName.Text = customers1.FirstName;
                        txtbSurName.Text = customers1.SecondName;
                        txtbAddressLine1.Text = customers1.AddressLine1;
                        txtbAddressLine2.Text = customers1.AddressLine2;
                        txtbContactNumber.Text = customers1.ContactNumber;
                        txtbEmail.Text = customers1.Email;
                        txtbPostcode.Text = customers1.Postcode;
                        txtbTown.Text = customers1.Town;
                        
                        string DateToString = "/";
                        string CustomersDOB = customers1.DDOB.ToString().Replace(DateToString, string.Empty);
                        //MessageBox.Show(CustomersDOB.Substring(4, 5));
                        cmbDay.Text = CustomersDOB.Substring(0,2);
                        cmbMonth.Text = CustomersDOB.Substring(2,2);
                        cmbYear.Text= CustomersDOB.Substring(4,5);
                        tempcustID = customers1.CustomerID.ToString();
                        if (customers1.Deleted == true || AppMode == 2 || AppMode == 0)
                        {
                            txtbAddressLine1.Enabled = false;
                            txtbAddressLine2.Enabled = false;
                            txtbContactNumber.Enabled = false;
                            txtbFirstName.Enabled = false;
                            txtbSurName.Enabled = false;
                            cmbDay.Enabled = false;
                            cmbMonth.Enabled = false;
                            cmbYear.Enabled = false;
                        txtbEmail.Enabled = false;
                        txtbTown.Enabled = false;
                        txtbPostcode.Enabled = false;
                    }
                        else
                        {
                            txtbAddressLine1.Enabled = true;
                            txtbAddressLine2.Enabled = true;
                            txtbContactNumber.Enabled = true;
                            txtbFirstName.Enabled = true;
                            txtbSurName.Enabled = true;
                            cmbDay.Enabled = true;
                            cmbMonth.Enabled = true;
                            cmbYear.Enabled = true;
                        txtbEmail.Enabled = true;
                        txtbTown.Enabled = true;
                        txtbPostcode.Enabled = true;
                    }
                    
                    }
                   
                }

         

            
        }

   
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new MainMenu(db);
            Form1.Show();
        }

        private void lblContactNumber_Click(object sender, EventArgs e)
        {

        }

        private void txtbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbSurName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
         && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtbFirstName.Text.Trim().Length <= 1)
            {
                Validation1.ForeColor = Color.Red;

            }
            else
            {
                Validation1.ForeColor = Color.Green;
            }
            if (Validation1.ForeColor == Color.Green && Validation2.ForeColor == Color.Green && Validation3.ForeColor == Color.Green && Validation4.ForeColor == Color.Green)
            {
                btnMultiFunction.Enabled = true;
            }
            else
            {
                btnMultiFunction.Enabled = false;
            }
            
        }

        private void txtbTown_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
      && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtbSurName_TextChanged(object sender, EventArgs e)
        {
            if (txtbSurName.Text.Trim().Length <= 2)
            {
                Validation2.ForeColor = Color.Red;

            }
            else
            {
                Validation2.ForeColor = Color.Green;
            }

                if (Validation1.ForeColor == Color.Green && Validation2.ForeColor == Color.Green && Validation3.ForeColor == Color.Green && Validation4.ForeColor == Color.Green)
                {
                    btnMultiFunction.Enabled = true;
                }
                else
                {
                    btnMultiFunction.Enabled = false;
                }
            
       
        }

        private void txtbEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtbEmail.Text.Trim().Contains('@'))
            {
                Validation3.ForeColor = Color.Green;

            }
            else
            {
                Validation3.ForeColor = Color.Red;
            }
                if (Validation1.ForeColor == Color.Green && Validation2.ForeColor == Color.Green && Validation3.ForeColor == Color.Green && Validation4.ForeColor == Color.Green)
                {
                    btnMultiFunction.Enabled = true;
                }
                else
                {
                    btnMultiFunction.Enabled = false;
                }
            
           
        }

        private void Validation4_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtbContactNumber_TextChanged(object sender, EventArgs e)
        {

            if (txtbContactNumber.Text.Trim().Length != 11)
            {
                Validation4.ForeColor = Color.Red;

            }
            else
            {
                Validation4.ForeColor = Color.Green;
            }
                if (Validation1.ForeColor == Color.Green && Validation2.ForeColor == Color.Green && Validation3.ForeColor == Color.Green && Validation4.ForeColor == Color.Green)
                {
                    btnMultiFunction.Enabled = true;
                }
                else
                {
                    btnMultiFunction.Enabled = false;
                }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtFilterBox.Text = "";
            listBoxCustomers.Items.Clear();
            PopulateDisplay();
            if (AppMode == 0)
            {
                txtbAddressLine1.Enabled = true;
                txtbAddressLine2.Enabled = true;
                txtbContactNumber.Enabled = true;
                txtbFirstName.Enabled = true;
                txtbSurName.Enabled = true;
                txtbEmail.Enabled = true;
                txtbTown.Enabled = true;
                txtbPostcode.Enabled = true;
                cmbDay.Enabled = true;
                cmbMonth.Enabled = true;
                cmbYear.Enabled = true;
            }
        }

        private void cmbFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmbFilterBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBox2.Text == "Deleted")
            {
                listBoxCustomers.Items.Clear();
                listBoxCustomers.Text = "";
                foreach (customers Customer1 in CustomersList)
                {
                    if (Customer1.Deleted == true)
                    {
                        listBoxCustomers.Items.Add(Customer1.CustomerID + " " + Customer1.FirstName + " " + Customer1.SecondName + " -" + "Deleted");
                    }
                }
            }
            else
            {
                PopulateDisplay();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new MainMenu(db);
            Form1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new AddEditDeleteCustomers(db);
            Form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new BookingsForm(db);
            Form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbYear_Leave(object sender, EventArgs e)
        {
            int year;
            if (int.TryParse(cmbYear.Text, out year))
            {
                if (year < 1900 || year > 2004)
                {
                    MessageBox.Show("Invalid year. Please enter a year between 1900 and 2004.");
                    cmbYear.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid year.");
                cmbYear.Focus();
            }
        }

        private void cmbMonth_Leave(object sender, EventArgs e)
        {
            //int month;
            //if (int.TryParse(cmbYear.Text, out month))
            //{
            //    if (month <= 1 || month >= 12)
            //    {
            //        MessageBox.Show("Invalid month. Please enter a value between 1 and 12");
            //        cmbMonth.Focus();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please enter a valid month.");
            //    cmbMonth.Focus();
            //}
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

