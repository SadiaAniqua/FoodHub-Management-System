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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();


                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;


                con.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Name FROM ShowMenu";

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Name"].ToString());
                }
                con.Close();


                RefreshOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                string itemName = comboBox1.Text;
                cmd.CommandText = $"SELECT Price FROM ShowMenu WHERE Name = '{itemName}'";

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtPrice.Text = dr["Price"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQty.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                double price = Convert.ToDouble(txtPrice.Text);
                double qty = Convert.ToDouble(txtQty.Text);
                double total = price * qty;
                txtTotal.Text = total.ToString();
            }
            else
            {
                txtTotal.Text = "0";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Random rd = new Random();
                int randomId = rd.Next(1, 100000);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                string itemName = comboBox1.Text;
                string qty = txtQty.Text;
                string total = txtTotal.Text;
                cmd.CommandText = $"INSERT INTO Orders (OrderId, ItemName, Quantity, TotalPrice) VALUES ({randomId}, '{itemName}', {qty}, '{total}')";

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Order completed successfully! Your ID: " + randomId, "Success");

                Form1 home = new Form1();
                home.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void RefreshOrderGrid()
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
                dgvOrderLive.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();

            home.Show();
            this.Close();
        }
    }
}
