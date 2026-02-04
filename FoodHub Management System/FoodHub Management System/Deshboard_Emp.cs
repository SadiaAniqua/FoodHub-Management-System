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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Final_Project
{
    public partial class Deshboard_Emp : Form
    {
        public Deshboard_Emp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                cmd.CommandText = $"select *from Customer_order";

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = dt;
                dgvData.Refresh();
                dgvData.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            this.NewData();
            this.LoadData();

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
           
            cbType.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbStatus.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTime.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }
        private void NewData()
        {
            txtID.Text = "Auto Generated";
            
            cbType.Text = "";
            cbStatus.Text = "";
            dateTime.Text = "";
            dgvData.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if(id == "Auto Generated")
            {
                MessageBox.Show("Please Select a row first!");
                return;
            }
            var result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) {
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;


                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from Customer_order where ID = {id}";

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
            string type = cbType.SelectedItem.ToString();
            string status = cbStatus.SelectedItem.ToString();
            DateTime dt = DateTime.Parse(dateTime.Text);
            string query = "";

            if (id == "Auto Generated")
            {
                query = $"INSERT INTO Customer_Order (Type, Status, DateTime) VALUES ('{type}', '{status}', '{dt:yyyy-MM-dd HH:mm:ss}')";
            }
            else
            {
                query = $"UPDATE Customer_Order SET Type='{type}', Status='{status}', DateTime='{dt:yyyy-MM-dd HH:mm:ss}' WHERE ID={id}";
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

                MessageBox.Show("Operation completed successfully.");
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        EmployeeMainPage _main;

        public Deshboard_Emp(EmployeeMainPage main)
        {
            InitializeComponent();
            _main = main;
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
           
            

        }
    }
}
