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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoadMenuData();
        }

        private void LoadMenuData()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM ShowMenu";


                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);


                dgvMenu.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = cmbCategory.SelectedItem.ToString();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (selectedItem == "All")
                {
                  
                    cmd.CommandText = "SELECT * FROM ShowMenu";
                }
                else
                {
                   
                    cmd.CommandText = "SELECT * FROM ShowMenu WHERE Name LIKE @name";
                    cmd.Parameters.AddWithValue("@name", "%" + selectedItem + "%");
                }

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvMenu.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {

                string foodName = dgvMenu.SelectedRows[0].Cells["Name"].Value.ToString();
                string foodPrice = dgvMenu.SelectedRows[0].Cells["Price"].Value.ToString();


                OrderForm orderPage = new OrderForm();
                orderPage.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a food item from the menu.");
                this.Hide();
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
