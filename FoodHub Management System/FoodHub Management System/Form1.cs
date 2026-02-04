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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MenuForm menuPage = new MenuForm();
            menuPage.Show();
            this.Hide();
            MessageBox.Show("The menu page is opening. Here, you will be able to see all the food items available.", "View Menu");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           OrderForm orderPage = new OrderForm();
            orderPage.Show();
            this.Hide();

            MessageBox.Show("The order page is opening. Here, you will be able to see the quantity and the price.", "Order Food");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyOrderForm historyPage = new MyOrderForm();
            historyPage.Show();
            this.Hide();

            MessageBox.Show("Your selected food items will be visible here.", "Current Order");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PaymentForm payPage = new PaymentForm();
            payPage.Show();
            this.Hide();

            MessageBox.Show("Payment Gateway");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
    }
}
