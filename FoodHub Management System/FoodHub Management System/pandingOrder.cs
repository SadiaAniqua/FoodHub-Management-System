using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FoodHub_Management_System
{
    public partial class pandingOrder : Form
    {
        public pandingOrder()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM ChefOrders";

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);


                DataTable dt = ds.Tables[0];

                showChefOrders.DataSource = dt;
                showChefOrders.AutoGenerateColumns = false;

                showChefOrders.Refresh();
                showChefOrders.ClearSelection();
                showChefOrders.CurrentCell = null;

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pandingOrder_Load(object sender, EventArgs e)
        {

            this.LoadData();
        }

        private void showChefOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showChefOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                orderid.Text = showChefOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                foodItem.Text = showChefOrders.Rows[e.RowIndex].Cells[1].Value.ToString();
                quantity.Text = showChefOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
                orderStatus.Text = showChefOrders.Rows[e.RowIndex].Cells[3].Value.ToString();


            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            string id = orderid.Text;
            if (orderid.Text == "Auto Generated")
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from cheforders where orderid={id}";

                cmd.ExecuteNonQuery();
                con.Close();

                showChefOrders.ClearSelection();
                this.NewData();

                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.LoadData();
        }
        private void NewData()
        {

            orderid.Text = "Auto Generated";
            foodItem.Text = "";
            quantity.Text = "";
            orderStatus.Text = "";



            showChefOrders.ClearSelection();



        }

        private void updateStatus_Click(object sender, EventArgs e)
        {
            string orderId = orderid.Text;          
            string food = foodItem.Text;
            string qty = quantity.Text;
            string status = orderStatus.Text;          

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();

                string query = "UPDATE cheforders SET FoodItemName='" + food + "', Quantity=" + qty + ", OrderStatus='" + status + "' WHERE OrderID=" + orderId;


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Order Updated Successfully");

                LoadData();
                NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

