using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoodHub_Management_System
{
    public partial class Inventory_Admin : Form
    {
        public Inventory_Admin()
        {
            InitializeComponent();
        }

        private void Inventory_Admin_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void NewData()
        {
            txtID.Text = "Auto Generated";
            dgvInventory.ClearSelection();
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewData();
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

        private void button1_Click(object sender, EventArgs e)
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


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        { 
            this.LoadData(); 
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;

            if (id == "Auto Generated")
            {
                MessageBox.Show("Please select a record to delete.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show( "Are you sure you want to delete this record?","Confirm Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

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
                cmd.CommandText = $"DELETE FROM Inventory WHERE ProductID={id};";
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                dgvInventory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if(txtSearch.Text == "")
                {
                    cmd.CommandText = "select inventory.*, category.CategoryName, menu.MenuName from Inventory inner join Category on category.categoryid = Inventory.CategoryID  inner join Menu on menu.MenuID = Inventory.MenuID;select * from Category;select * from Menu";
                }
                else
                {
                    cmd.CommandText = $"select inventory.*, category.CategoryName, menu.MenuName from Inventory inner join Category on category.categoryid = Inventory.CategoryID inner join Menu on menu.MenuID = Inventory.MenuID where inventory.ProductID like '%{txtSearch.Text}%' or inventory.CategoryID like '%{txtSearch.Text}%' or category.CategoryName like '%{txtSearch.Text}%' or menu.MenuName like '%{txtSearch.Text}%';select * from Category;select * from Menu";
                }

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
    }
}
