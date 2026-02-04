using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodHub_Management_System
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void LoadForm(Form form)
        {
            MainPanel.Controls.Clear();     
            form.TopLevel = false;           
            form.Dock = DockStyle.Fill;     
            MainPanel.Controls.Add(form);
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderDetails());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new Dashboard());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadForm(new UserInfos());
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Are you sure you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            Login login = new Login();
            login.Show();

            this.Hide();   
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            LoadForm (new Inventory_Admin())   ;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
