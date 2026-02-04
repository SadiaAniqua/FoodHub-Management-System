using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodHub_Management_System
{
    public partial class chefPanel : Form
    {
        public chefPanel()
        {
            InitializeComponent();
        }

        private void LoadForm(Form form)

        {

            MainPanel.Controls.Clear();

            form.TopLevel = false;

            form.Dock = DockStyle.Fill;

            MainPanel.Controls.Add(form);

            form.Show();

        }


        private void chefPanel_Load(object sender, EventArgs e)
        {

        }

        private void pandingOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new pandingOrder());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            Login login = new Login();
            login.Show();

            this.Hide();
        }
    }
}
