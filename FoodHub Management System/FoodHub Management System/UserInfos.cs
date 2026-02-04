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
    public partial class UserInfos : Form
    {
        public UserInfos()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
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
                cmd.CommandText = "SELECT * FROM userinfo";

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);


                DataTable dt = ds.Tables[0];

                dgvUsers.DataSource = dt;
                dgvUsers.AutoGenerateColumns = false;

                dgvUsers.Refresh();
                dgvUsers.ClearSelection();
               

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UserInfos_Load(object sender, EventArgs e)
        {

            this.LoadData();

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLastName.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPass.Text = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbUserType.Text = dgvUsers.Rows[e.RowIndex].Cells[7].Value.ToString();

                string userType = cmbUserType.Text;

                if (userType == "Employee" || userType == "Chef")
                {

                    ShowEmployeePanel(true);

                        txtSalary.Text = dgvUsers.Rows[e.RowIndex].Cells[8].Value.ToString();
              
                        dtpJoiningDate.Value = Convert.ToDateTime(dgvUsers.Rows[e.RowIndex].Cells[9].Value);
               
                }
                else
                {

                    ShowEmployeePanel(false);

                    txtSalary.Clear();
                    dtpJoiningDate.Value = DateTime.Today;
                }
            }
        }


        private void ShowEmployeePanel(bool show)
        {
            panelEmployee.Visible = show;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NewData()
        {

            txtID.Text = "Auto Generated";
            txtName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            cmbUserType.SelectedIndex = -1;
            rdFemale.Checked = false;
            rdMale.Checked = false;

            txtSalary.Text = "";
            dtpJoiningDate.Value = DateTime.Today;

            ShowEmployeePanel(false);
            dgvUsers.ClearSelection();



        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.NewData();
            if (cmbUserType.Text == "Employee")
            {
                this.ShowEmployeePanel(true);
            }
            else
            {
                this.ShowEmployeePanel(false);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtLastName.Text == "" ||
                txtEmail.Text == "" || txtPass.Text == "" || cmbUserType.Text == "")
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            if (cmbUserType.Text == "Employee" && txtSalary.Text == "")
            {
                MessageBox.Show("Salary is required for Employee");
                return;
            }
            if (cmbUserType.Text == "Chef" && txtSalary.Text == "")
            {
                MessageBox.Show("Salary is required for Employee");
                return;
            }

            string id = txtID.Text;
            string fname = txtName.Text;
            string lname = txtLastName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string userType = cmbUserType.Text;
            string salary = txtSalary.Text;
            string joiningDate = dtpJoiningDate.Value.ToString("yyyy-MM-dd");
            string gender = "";

            if (rdMale.Checked)
            {
                gender = "Male";
            }
            else if (rdFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("Please select gender");
                return;
            }

            string query = "";

            if (id == "Auto Generated")
            {
                if (userType == "Employee" || userType == "Admin" || userType == "Chef")
                {
                    query = $"INSERT INTO userinfo (FirstName, LastName, Email, Password, Gender, UserType, Salary, JoiningDate) VALUES ('{fname}', '{lname}', '{email}', '{pass}', '{gender}', '{userType}', '{salary}', '{joiningDate}')";
                }
                else
                {
                    query = $"INSERT INTO userinfo (FirstName, LastName, Email, Password, Gender, UserType) VALUES ('{fname}', '{lname}', '{email}', '{pass}', '{gender}', '{userType}')";
                }
            }
            else
            {
                if (userType == "Employee" || userType == "Admin" || userType == "Chef")
                {
                    query = $"UPDATE userinfo SET FirstName='{fname}', LastName='{lname}', Email='{email}', Password='{pass}', Gender='{gender}', UserType='{userType}', Salary='{salary}', JoiningDate='{joiningDate}' WHERE ID={id}";
                }
                else
                {
                    query = $"UPDATE userinfo SET FirstName='{fname}', LastName='{lname}', Email='{email}', Password='{pass}', Gender='{gender}', UserType='{userType}' WHERE ID={id}";
                }
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
            string id = txtID.Text;
            if (txtID.Text == "Auto Generated")
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
                cmd.CommandText = $"delete from userinfo where id={id}";

                cmd.ExecuteNonQuery();
                con.Close();

                dgvUsers.ClearSelection();
                this.NewData();

                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.LoadData();
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserType.Text == "Employee" || cmbUserType.Text == "Chef" )
            {
                ShowEmployeePanel(true);
            }
            else
            {
                ShowEmployeePanel(false);
                txtSalary.Clear();
                dtpJoiningDate.Value = DateTime.Today;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}