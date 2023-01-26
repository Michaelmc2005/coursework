
namespace _2022_09_27_Coursework_1st_Draft.gui
{
    partial class BookingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCustomerDisplayBoard = new System.Windows.Forms.Label();
            this.cmbFilterBox1 = new System.Windows.Forms.ComboBox();
            this.listBoxCustomers = new System.Windows.Forms.ListBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.txtFilterBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtbID = new System.Windows.Forms.TextBox();
            this.btnClearFilterBox = new System.Windows.Forms.Button();
            this.btnCreateBooking = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbNails = new System.Windows.Forms.CheckBox();
            this.cmbHair = new System.Windows.Forms.CheckBox();
            this.cmbTanning = new System.Windows.Forms.CheckBox();
            this.cmbMakeup = new System.Windows.Forms.CheckBox();
            this.cmbWaxing = new System.Windows.Forms.CheckBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.DVStaff = new System.Windows.Forms.DataGridView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DVStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerDisplayBoard
            // 
            this.lblCustomerDisplayBoard.AutoSize = true;
            this.lblCustomerDisplayBoard.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerDisplayBoard.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblCustomerDisplayBoard.Location = new System.Drawing.Point(26, 205);
            this.lblCustomerDisplayBoard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerDisplayBoard.Name = "lblCustomerDisplayBoard";
            this.lblCustomerDisplayBoard.Size = new System.Drawing.Size(219, 32);
            this.lblCustomerDisplayBoard.TabIndex = 33;
            this.lblCustomerDisplayBoard.Text = "Select a Customer";
            // 
            // cmbFilterBox1
            // 
            this.cmbFilterBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFilterBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBox1.FormattingEnabled = true;
            this.cmbFilterBox1.Items.AddRange(new object[] {
            "Name",
            "ID"});
            this.cmbFilterBox1.Location = new System.Drawing.Point(139, 248);
            this.cmbFilterBox1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterBox1.Name = "cmbFilterBox1";
            this.cmbFilterBox1.Size = new System.Drawing.Size(95, 25);
            this.cmbFilterBox1.TabIndex = 32;
            this.cmbFilterBox1.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBox1_SelectedIndexChanged);
            // 
            // listBoxCustomers
            // 
            this.listBoxCustomers.ForeColor = System.Drawing.Color.ForestGreen;
            this.listBoxCustomers.FormattingEnabled = true;
            this.listBoxCustomers.ItemHeight = 17;
            this.listBoxCustomers.Location = new System.Drawing.Point(49, 286);
            this.listBoxCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxCustomers.Name = "listBoxCustomers";
            this.listBoxCustomers.Size = new System.Drawing.Size(459, 276);
            this.listBoxCustomers.TabIndex = 2;
            this.listBoxCustomers.SelectedIndexChanged += new System.EventHandler(this.listBoxCustomers_SelectedIndexChanged);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(46, 251);
            this.lblFilterBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(85, 17);
            this.lblFilterBy.TabIndex = 29;
            this.lblFilterBy.Text = "Filter results";
            // 
            // txtFilterBox
            // 
            this.txtFilterBox.Location = new System.Drawing.Point(242, 248);
            this.txtFilterBox.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilterBox.Name = "txtFilterBox";
            this.txtFilterBox.Size = new System.Drawing.Size(187, 25);
            this.txtFilterBox.TabIndex = 1;
            this.txtFilterBox.TextChanged += new System.EventHandler(this.txtFilterBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(538, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Service Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(536, 205);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 32);
            this.label4.TabIndex = 36;
            this.label4.Text = "Confirm your Booking";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(538, 484);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 21);
            this.label5.TabIndex = 38;
            this.label5.Text = "Staff Member";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Nails - £30",
            "Haircuts - £50",
            "Tanning - £20",
            "Makeup - £40",
            "Waxing - £20"});
            this.comboBox2.Location = new System.Drawing.Point(1444, 481);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(189, 25);
            this.comboBox2.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(540, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 21);
            this.label6.TabIndex = 40;
            this.label6.Text = "Customer ID";
            // 
            // comboBox3
            // 
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Sarah McMahon",
            "Michael McMahon",
            "Dan Black",
            "Joel McDade"});
            this.comboBox3.Location = new System.Drawing.Point(685, 484);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(189, 25);
            this.comboBox3.TabIndex = 9;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            this.comboBox3.TextChanged += new System.EventHandler(this.comboBox3_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.ForestGreen;
            this.label7.Location = new System.Drawing.Point(912, 280);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 21);
            this.label7.TabIndex = 42;
            this.label7.Text = "Select Start Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(538, 534);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 21);
            this.label8.TabIndex = 43;
            this.label8.Text = "Start Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(761, 538);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 21);
            this.label9.TabIndex = 49;
            this.label9.Text = ":";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPrice.Location = new System.Drawing.Point(910, 508);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(177, 32);
            this.lblPrice.TabIndex = 50;
            this.lblPrice.Text = "Total Price: £0";
            // 
            // txtbID
            // 
            this.txtbID.Enabled = false;
            this.txtbID.Location = new System.Drawing.Point(683, 284);
            this.txtbID.Margin = new System.Windows.Forms.Padding(4);
            this.txtbID.Name = "txtbID";
            this.txtbID.Size = new System.Drawing.Size(189, 25);
            this.txtbID.TabIndex = 3;
            this.txtbID.TextChanged += new System.EventHandler(this.txtbID_TextChanged);
            this.txtbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbID_KeyPress);
            // 
            // btnClearFilterBox
            // 
            this.btnClearFilterBox.BackColor = System.Drawing.Color.ForestGreen;
            this.btnClearFilterBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilterBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilterBox.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnClearFilterBox.ForeColor = System.Drawing.Color.White;
            this.btnClearFilterBox.Location = new System.Drawing.Point(49, 570);
            this.btnClearFilterBox.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearFilterBox.Name = "btnClearFilterBox";
            this.btnClearFilterBox.Size = new System.Drawing.Size(459, 43);
            this.btnClearFilterBox.TabIndex = 19;
            this.btnClearFilterBox.Text = "Clear Selection";
            this.btnClearFilterBox.UseVisualStyleBackColor = false;
            this.btnClearFilterBox.Click += new System.EventHandler(this.btnClearFilterBox_Click_1);
            // 
            // btnCreateBooking
            // 
            this.btnCreateBooking.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCreateBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateBooking.Enabled = false;
            this.btnCreateBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBooking.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnCreateBooking.ForeColor = System.Drawing.Color.White;
            this.btnCreateBooking.Location = new System.Drawing.Point(1207, 423);
            this.btnCreateBooking.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateBooking.Name = "btnCreateBooking";
            this.btnCreateBooking.Size = new System.Drawing.Size(157, 59);
            this.btnCreateBooking.TabIndex = 16;
            this.btnCreateBooking.Text = "Create Booking";
            this.btnCreateBooking.UseVisualStyleBackColor = false;
            this.btnCreateBooking.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.comboBox1.Location = new System.Drawing.Point(685, 534);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Enabled = false;
            this.comboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.comboBox4.Location = new System.Drawing.Point(783, 535);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(65, 24);
            this.comboBox4.TabIndex = 11;
            this.comboBox4.TextChanged += new System.EventHandler(this.comboBox4_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(437, 248);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 25);
            this.button2.TabIndex = 71;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbNails
            // 
            this.cmbNails.AutoSize = true;
            this.cmbNails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbNails.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNails.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmbNails.Location = new System.Drawing.Point(684, 327);
            this.cmbNails.Margin = new System.Windows.Forms.Padding(4);
            this.cmbNails.Name = "cmbNails";
            this.cmbNails.Size = new System.Drawing.Size(92, 21);
            this.cmbNails.TabIndex = 5;
            this.cmbNails.Text = "Nails - £30";
            this.cmbNails.UseVisualStyleBackColor = true;
            this.cmbNails.CheckedChanged += new System.EventHandler(this.cmbNails_CheckedChanged);
            this.cmbNails.TextChanged += new System.EventHandler(this.cmbNails_TextChanged);
            // 
            // cmbHair
            // 
            this.cmbHair.AutoSize = true;
            this.cmbHair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbHair.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHair.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmbHair.Location = new System.Drawing.Point(683, 356);
            this.cmbHair.Margin = new System.Windows.Forms.Padding(4);
            this.cmbHair.Name = "cmbHair";
            this.cmbHair.Size = new System.Drawing.Size(87, 21);
            this.cmbHair.TabIndex = 4;
            this.cmbHair.Text = "Hair - £50";
            this.cmbHair.UseVisualStyleBackColor = true;
            this.cmbHair.CheckedChanged += new System.EventHandler(this.cmbHair_CheckedChanged);
            // 
            // cmbTanning
            // 
            this.cmbTanning.AutoSize = true;
            this.cmbTanning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTanning.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTanning.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmbTanning.Location = new System.Drawing.Point(684, 381);
            this.cmbTanning.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTanning.Name = "cmbTanning";
            this.cmbTanning.Size = new System.Drawing.Size(111, 21);
            this.cmbTanning.TabIndex = 6;
            this.cmbTanning.Text = "Tanning - £20";
            this.cmbTanning.UseVisualStyleBackColor = true;
            this.cmbTanning.CheckedChanged += new System.EventHandler(this.cmbTanning_CheckedChanged);
            // 
            // cmbMakeup
            // 
            this.cmbMakeup.AutoSize = true;
            this.cmbMakeup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbMakeup.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMakeup.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmbMakeup.Location = new System.Drawing.Point(684, 434);
            this.cmbMakeup.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMakeup.Name = "cmbMakeup";
            this.cmbMakeup.Size = new System.Drawing.Size(110, 21);
            this.cmbMakeup.TabIndex = 7;
            this.cmbMakeup.Text = "Makeup - £40";
            this.cmbMakeup.UseVisualStyleBackColor = true;
            this.cmbMakeup.CheckedChanged += new System.EventHandler(this.cmbMakeup_CheckedChanged);
            // 
            // cmbWaxing
            // 
            this.cmbWaxing.AutoSize = true;
            this.cmbWaxing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWaxing.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWaxing.ForeColor = System.Drawing.Color.ForestGreen;
            this.cmbWaxing.Location = new System.Drawing.Point(685, 408);
            this.cmbWaxing.Margin = new System.Windows.Forms.Padding(4);
            this.cmbWaxing.Name = "cmbWaxing";
            this.cmbWaxing.Size = new System.Drawing.Size(108, 21);
            this.cmbWaxing.TabIndex = 8;
            this.cmbWaxing.Text = "Waxing - £20";
            this.cmbWaxing.UseVisualStyleBackColor = true;
            this.cmbWaxing.CheckedChanged += new System.EventHandler(this.cmbWaxing_CheckedChanged);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDuration.Location = new System.Drawing.Point(910, 548);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(244, 32);
            this.lblDuration.TabIndex = 77;
            this.lblDuration.Text = "Duration: 0 minutes";
            // 
            // DVStaff
            // 
            this.DVStaff.AllowUserToAddRows = false;
            this.DVStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DVStaff.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DVStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DVStaff.Location = new System.Drawing.Point(21, 56);
            this.DVStaff.Name = "DVStaff";
            this.DVStaff.Size = new System.Drawing.Size(1353, 140);
            this.DVStaff.TabIndex = 20;
            this.DVStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DVStaff_CellClick_1);
            this.DVStaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DVStaff_CellContentClick);
            this.DVStaff.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DVStaff_DataBindingComplete);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(916, 310);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 15;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.ForestGreen;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1207, 490);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 59);
            this.button3.TabIndex = 18;
            this.button3.Text = "Edit Booking";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.ForestGreen;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(186, 41);
            this.button7.TabIndex = 21;
            this.button7.Text = "Main Menu";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(540, 247);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 21);
            this.label10.TabIndex = 78;
            this.label10.Text = "Please ensure all boxes are fulfilled";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(540, 362);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 98);
            this.label2.TabIndex = 96;
            this.label2.Text = "Max Length: 60 mins";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.checkBox1.Location = new System.Drawing.Point(746, 593);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.ForestGreen;
            this.label11.Location = new System.Drawing.Point(538, 588);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 21);
            this.label11.TabIndex = 98;
            this.label11.Text = "Appointment Completed";
            this.label11.Visible = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.ForestGreen;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(1207, 557);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(157, 59);
            this.button8.TabIndex = 17;
            this.button8.Text = "Delete Booking";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1193, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 56);
            this.button1.TabIndex = 99;
            this.button1.Text = "Generate fresh colour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1092, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 56);
            this.panel3.TabIndex = 100;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // BookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.DVStaff);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.cmbWaxing);
            this.Controls.Add(this.cmbMakeup);
            this.Controls.Add(this.cmbTanning);
            this.Controls.Add(this.cmbHair);
            this.Controls.Add(this.cmbNails);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCreateBooking);
            this.Controls.Add(this.btnClearFilterBox);
            this.Controls.Add(this.txtbID);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCustomerDisplayBoard);
            this.Controls.Add(this.cmbFilterBox1);
            this.Controls.Add(this.listBoxCustomers);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.txtFilterBox);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BookingsForm";
            this.Load += new System.EventHandler(this.BookingsForm_Load);
            this.Controls.SetChildIndex(this.txtFilterBox, 0);
            this.Controls.SetChildIndex(this.lblFilterBy, 0);
            this.Controls.SetChildIndex(this.listBoxCustomers, 0);
            this.Controls.SetChildIndex(this.cmbFilterBox1, 0);
            this.Controls.SetChildIndex(this.lblCustomerDisplayBoard, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.comboBox2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.comboBox3, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblPrice, 0);
            this.Controls.SetChildIndex(this.txtbID, 0);
            this.Controls.SetChildIndex(this.btnClearFilterBox, 0);
            this.Controls.SetChildIndex(this.btnCreateBooking, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.comboBox4, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.cmbNails, 0);
            this.Controls.SetChildIndex(this.cmbHair, 0);
            this.Controls.SetChildIndex(this.cmbTanning, 0);
            this.Controls.SetChildIndex(this.cmbMakeup, 0);
            this.Controls.SetChildIndex(this.cmbWaxing, 0);
            this.Controls.SetChildIndex(this.lblDuration, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.DVStaff, 0);
            this.Controls.SetChildIndex(this.monthCalendar1, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DVStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCustomerDisplayBoard;
        private System.Windows.Forms.ComboBox cmbFilterBox1;
        private System.Windows.Forms.ListBox listBoxCustomers;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox txtFilterBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtbID;
        private System.Windows.Forms.Button btnClearFilterBox;
        private System.Windows.Forms.Button btnCreateBooking;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cmbNails;
        private System.Windows.Forms.CheckBox cmbHair;
        private System.Windows.Forms.CheckBox cmbTanning;
        private System.Windows.Forms.CheckBox cmbMakeup;
        private System.Windows.Forms.CheckBox cmbWaxing;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.DataGridView DVStaff;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
    }
}