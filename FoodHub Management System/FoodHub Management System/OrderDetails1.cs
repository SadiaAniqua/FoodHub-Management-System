using FoodHub_Management_System;
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

namespace Final_Project
{
    public partial class OrderDetails1 : Form
    {
        public OrderDetails1()
        {
            InitializeComponent();
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            this.LoadData();
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
                cmd.CommandText = $"Select Menu1.*,Customer_order.Type,Category.CategoryName from Menu1 inner join Customer_order on Customer_order.ID = Menu1.CustomerID inner join Category on Category.CategoryID = Menu1.CategoryID; Select *from Customer_order; Select *from Category";

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
               

                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = dt;
                dgvData.Refresh();
                dgvData.ClearSelection();


                DataTable dt1 = ds.Tables[1];
                DataView dv = new DataView(dt1);
                DataTable distinctTable = dv.ToTable(true, "ID", "Type");

                cmbType.DataSource = distinctTable;
                cmbType.DisplayMember = "Type";
                cmbType.ValueMember = "ID";
                cmd.Parameters.AddWithValue("@TypeID", cmbType.SelectedValue);


                DataTable dt2 = ds.Tables[2];
                cmbCatagory.DataSource = dt2;
                cmbCatagory.ValueMember = "CategoryID";
                cmbCatagory.DisplayMember = "CategoryName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();

            txtName.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPrice.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQuantity.Text = dgvData.Rows[e.RowIndex].Cells[7].Value.ToString();
            cmbType.SelectedValue = dgvData.Rows[e.RowIndex].Cells[1].Value;
            cmbCatagory.SelectedValue = dgvData.Rows[e.RowIndex].Cells[5].Value;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtID.Text = "Auto Genarated";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.NewData();
            this.LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Genarated")
            {
                MessageBox.Show("Please Select a row first!");
                return;
            }
            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
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
                cmd.CommandText = $"delete from Menu1 where MenuID = {id}";

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Oparation Completed");
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string cmID = cmbCatagory.SelectedValue.ToString();
            string CID = cmbType.SelectedValue.ToString();
            string Price = txtPrice.Text;
            string Quantity = txtQuantity.Text;
            string Name = txtName.Text;
            
            
            string query = "";
            if (id == "Auto Genarated")
            {
                query = $" INSERT INTO Menu1 (ItemName, UnitPrice, CustomerID, CategoryID, Quantity)  VALUES ('{Name}', {Price}, {CID}, {cmID}, {Quantity})";
            }

            else
            {
                query = query = $"UPDATE Menu1 SET ItemName = '{Name}', UnitPrice = {Price}, CustomerID = {CID}, CategoryID = {cmID}, Quantity = {Quantity} WHERE MenuID = {id}";


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
                MessageBox.Show("Oparation Completed");
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTotalPrice_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Price or Quantity missing");
                return;
            }

            try
            {
                decimal price = Convert.ToDecimal(txtPrice.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                decimal total = price * quantity;

                txtTotalPrice.Text = total.ToString();
            }
            catch
            {
                MessageBox.Show("Invalid number format");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
