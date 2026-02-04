using Final_Project;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text;
            string password = txtPassword.Text;

            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter email and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $" SELECT * FROM userinfo WHERE Email = '{email}' AND Password = '{password}'";

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                con.Close();

               
                if (dt.Rows.Count == 1)
                {
                    string userType = dt.Rows[0][7].ToString(); 

                    if (userType == "Admin")
                    {
                        
                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                    }
                    else if (userType == "Employee")
                    {
                       EmployeeMainPage emp = new EmployeeMainPage();
                        emp.Show();
                        this.Hide();
                    }
                    else if (userType == "Chef")
                    {
                       chefPanel chef = new chefPanel();
                        chef.Show();
                        this.Hide();
                    }
                    else if (userType == "Customer")
                    {
                        Form1 customer = new Form1();
                        customer.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Unauthorized user type detected.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPass.Checked) {
                txtPassword.UseSystemPasswordChar = false;
            } else {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
