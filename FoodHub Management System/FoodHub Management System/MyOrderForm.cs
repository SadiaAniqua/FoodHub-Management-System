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
    public partial class MyOrderForm : Form
    {
        public MyOrderForm()
        {
            InitializeComponent();
        }

        private void MyOrderForm_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Orders";

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvHistory.DataSource = dt;

                double sum = 0;
                for (int i = 0; i < dgvHistory.Rows.Count; i++)
                {
                    if (dgvHistory.Rows[i].Cells["TotalPrice"].Value != null)
                    {
                        sum += Convert.ToDouble(dgvHistory.Rows[i].Cells["TotalPrice"].Value);
                    }
                }
                lblGrandTotal.Text = "Total Bill: " + sum.ToString() + " TK";


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                string orderId = dgvHistory.SelectedRows[0].Cells["OrderId"].Value.ToString();

                try
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ApplicationHelper.CS;
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;


                    cmd.CommandText = $"DELETE FROM Orders WHERE OrderId = {orderId}";

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Order ID " + orderId + " successfully cancelled!");


                    MyOrderForm_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an order to cancel.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentForm pf = new PaymentForm();
            pf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();

            home.Show();
            this.Hide();
        }
    }
}
