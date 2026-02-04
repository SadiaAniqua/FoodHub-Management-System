using FoodHub_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class EmployeeMainPage : Form
    {
        public EmployeeMainPage()
        {
            InitializeComponent();
        }

        private void EmployeeMainPage_Load(object sender, EventArgs e)
        {

        }
        public void loadForm(Form f)
        {
           
            if (MainPanel.Controls.Count > 0)
                MainPanel.Controls.Clear();

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            MainPanel.Controls.Add(f);   
            f.Show();
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            loadForm(new Deshboard_Emp());
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            
            loadForm(new OrderDetails1());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            Login login = new Login();
            login.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm (new Inventory_Employee());
        }
    }
}
