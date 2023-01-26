using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using _2022_09_27_Coursework_1st_Draft.objects;

namespace _2022_09_27_Coursework_1st_Draft.gui
{
    public partial class Template : Form
    {


        public Template()
        {
           
            InitializeComponent();
            timer1.Start();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
           
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString();
        }

   

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_MouseLeave_1(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.White;
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = SystemColors.MenuHighlight;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.White;
        }

        private void btnExit_MouseHover_1(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This subsystem has not been implemented yet. This will take you to the Simpsons Department Store Website in the near future.");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
