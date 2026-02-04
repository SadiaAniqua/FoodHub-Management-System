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
    public partial class Inventory_Employee : Form
    {
        public Inventory_Employee()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Access denied. This feature is available to administrators only.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Access denied. This feature is available to administrators only.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void NewData()
        {
            txtID.Text = "Auto Generated";
            dgvInventory.ClearSelection();
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void tblpInventory_Paint(object sender, PaintEventArgs e)
        {

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
                cmd.CommandText = "select inventory.*, category.CategoryName, menu.MenuName from Inventory inner join Category on category.categoryid = Inventory.CategoryID  inner join Menu on menu.MenuID = Inventory.MenuID;select * from Category;select * from Menu";

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);


                DataTable dt = ds.Tables[0];
                dgvInventory.DataSource = dt;

                dgvInventory.AutoGenerateColumns = false;

                dgvInventory.Refresh();
                dgvInventory.ClearSelection();

                DataTable dt1 = ds.Tables[1];
                cmbCategory.DataSource = dt1;
                cmbCategory.ValueMember = "CategoryID";
                cmbCategory.DisplayMember = "CategoryName";


                cmbMenu.ValueMember = "MenuID";
                cmbMenu.DisplayMember = "MenuName";
                DataTable dt2 = ds.Tables[2];
                cmbMenu.DataSource = dt2;

                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inventory_Employee_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string id = txtID.Text;
                string categoryID = cmbCategory.SelectedValue.ToString();
                string menuID = cmbMenu.SelectedValue.ToString();
                string quantity = txtQuantity.Text;
                string unitPrice = txtUnitPrice.Text;

                string query = "";

                if (id == "Auto Generated")
                {
                    query = $"INSERT INTO Inventory (CategoryID, MenuID, UnitPrice, Quantity) VALUES ({categoryID}, {menuID}, {unitPrice}, {quantity});";
                }
                else
                {
                    query = $"UPDATE Inventory SET CategoryID={categoryID}, MenuID={menuID}, UnitPrice={unitPrice}, Quantity={quantity} WHERE ProductID={id};";
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
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvInventory.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbCategory.SelectedValue = dgvInventory.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbMenu.SelectedValue = dgvInventory.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtQuantity.Text = dgvInventory.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtUnitPrice.Text = dgvInventory.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
