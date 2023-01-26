using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2022_09_27_Coursework_1st_Draft.objects;
using _2022_09_27_Coursework_1st_Draft.dbAccess;
using _2022_09_27_Coursework_1st_Draft.gui;

namespace _2022_09_27_Coursework_1st_Draft.gui
{
    public partial class MainMenu : Template
    {
      
       private Database db;
        public MainMenu(Database db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void Template_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        { 
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new MainMenu(db);
            Form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
           
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
