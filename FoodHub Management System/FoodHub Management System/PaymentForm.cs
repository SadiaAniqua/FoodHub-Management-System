using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodHub_Management_System
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the order and delete all items?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.CS;

                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM Orders";

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Order deleted successfully!");

                    Form1 home = new Form1();
                    home.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Orders";
                cmd.ExecuteNonQuery();

                con.Close();

                string method = "";
                if (rbBkash.Checked) method = "Bkash";
                else if (rbNagad.Checked) method = "Nagad";
                else method = "Cash on Delivery";

                MessageBox.Show("Thanks! " + method + " Payment successful. Your food is being delivered quickly.", "Order Complete");

                Form1 home = new Form1();
                home.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyOrderForm orders = new MyOrderForm();

            orders.Show();

            this.Close();
        }
    }
}
