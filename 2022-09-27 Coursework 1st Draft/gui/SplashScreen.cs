using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2022_09_27_Coursework_1st_Draft.dbAccess;
using _2022_09_27_Coursework_1st_Draft.gui;
using _2022_09_27_Coursework_1st_Draft.objects;
namespace _2022_09_27_Coursework_1st_Draft.gui
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
         
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Database db;
            db = new Database();
            db.connect();
            progressBar1.Increment(10);
            if (progressBar1.Value == 100)
            {

                timer1.Stop();
                this.Hide();
                Form Form1 = new MainMenu(db);
                Form1.Show();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
