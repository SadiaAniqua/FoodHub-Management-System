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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtName.Text;
            string lastName = txtLastname.Text;
            string email = txtEmail.Text;
            string password = txtPass.Text;
            string confirmPassword = txtConfirmPass.Text;
            string gender = "";
            string usertype = cmbUserType.Text;

            /*if (firstName == "" || lastName == "" || email == "" || password == "" || confirmPassword == "" || gender == "" || usertype == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

            if (firstName == "")
            {
                MessageBox.Show("First name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (lastName == "")
            {
                MessageBox.Show("Last name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastname.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }
            if (email.Contains("@") == false || email.Contains(".") == false)
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if (password == "")
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPass.Focus();
                return;
            }

            if (rdbtnMale.Checked)
            {
                gender = "Male";
            }
            else if (rdbtnFemale.Checked)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("Invalid gender selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            DateTime dob = DateTime.Parse(DOB.Text);
            try
                {
                double age = (DateTime.Now - dob).TotalDays/365;
                if (age < 18)
                {
                    MessageBox.Show("You must be at least 18 years old to register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid date of birth.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbUserType.SelectedItem == null)
            {
                MessageBox.Show("Please select a user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUserType.Focus();
                return;
            }
            string result = "Name:\t\t" + firstName + " " + lastName + "\n" + "Email:\t\t" + email + "\n" + "Password:\t" + password + "\n" + "User Type:\t" + usertype + "\n" + "Date of birth:\t" + dob.ToString("yyyy-MM-dd") + "\n"+ "Gender:\t\t" + gender;
            
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.CS;
                    
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $" INSERT INTO userinfo (FirstName, LastName, Email, Password, Gender, UserType, DateOfBirth) VALUES ('{firstName}', '{lastName}', '{email}', '{password}', '{gender}', '{usertype}', '{dob:yyyy-MM-dd}') ";

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Account Created Successfully!\n\n" + result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = "";
                txtLastname.Text = "";
                txtEmail.Text = "";
                txtPass.Text = "";
                txtConfirmPass.Text = "";
                rdbtnMale.Checked = false;
                rdbtnFemale.Checked = false;
                chkbPass.Checked = false;
                if (cmbUserType.Items.Count > 0) { cmbUserType.SelectedIndex = -1; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        private void chkbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbPass.Checked)
            {
                chkbPass.ForeColor = Color.Red; 
                txtPass.UseSystemPasswordChar = false;
                txtConfirmPass.UseSystemPasswordChar = false;
            }
            else
            {
                chkbPass.ForeColor = Color.FromArgb(64, 64, 64);
                txtPass.UseSystemPasswordChar = true;
                txtConfirmPass.UseSystemPasswordChar = true;
            }   
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

