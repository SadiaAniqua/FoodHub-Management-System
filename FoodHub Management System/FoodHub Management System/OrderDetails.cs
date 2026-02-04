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
    public partial class OrderDetails : Form
    {
        public OrderDetails()
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
                cmd.CommandText = "SELECT ID, Type, Status, DateTime FROM Customer_Order";

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                dgvOrders.DataSource = dt;
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.ClearSelection();

                con.Close();

                cmbOrderType.SelectedIndex = -1;

                
              
                cmbOrderStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tblpInventory_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpOrder_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtOrderID.Text;
            string type = cmbOrderType.Text;
            string status = cmbOrderStatus.Text;
            string dateTime = dtpDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "";

            if (id == "Auto Generated")
            {
                query = $"INSERT INTO Customer_Order (Type, Status, DateTime) VALUES ('{type}', '{status}', '{dateTime}')";
            }
            else
            {
                query = $"UPDATE Customer_Order SET Type='{type}', Status='{status}', DateTime='{dateTime}' WHERE ID={id}";
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.NewData();
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text == "Auto Generated")
            {
                MessageBox.Show("Please select an order to cancel");
                return;
            }

            DialogResult result = MessageBox.Show("Please select an order to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            string id = txtOrderID.Text;
          

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"DELETE FROM Customer_Order WHERE ID={id}";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Order cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.NewData();
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void NewData()
        {
            txtOrderID.Text = "Auto Generated";
            cmbOrderType.SelectedIndex = -1;
            cmbOrderStatus.SelectedIndex = -1;
            dtpDateTime.Value = DateTime.Now;

            dgvOrders.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            this.LoadData();   
        }

        private void dgvOrders_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
             {
                  txtOrderID.Text = dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                  cmbOrderType.Text = dgvOrders.Rows[e.RowIndex].Cells[1].Value.ToString();
                  cmbOrderStatus.Text = dgvOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
                  dtpDateTime.Value = Convert.ToDateTime(dgvOrders.Rows[e.RowIndex].Cells[3].Value);
             }
        }
    }
}
