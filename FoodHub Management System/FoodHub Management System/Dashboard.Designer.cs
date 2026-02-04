namespace FoodHub_Management_System
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Userspanel = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.Button();
            this.Employeespanel = new System.Windows.Forms.Panel();
            this.btnCus = new System.Windows.Forms.Button();
            this.Adminpanel = new System.Windows.Forms.Panel();
            this.btnOrders = new System.Windows.Forms.Button();
            this.Customerpanel = new System.Windows.Forms.Panel();
            this.btnEmp = new System.Windows.Forms.Button();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.Userspanel.SuspendLayout();
            this.Employeespanel.SuspendLayout();
            this.Adminpanel.SuspendLayout();
            this.Customerpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // Userspanel
            // 
            this.Userspanel.BackColor = System.Drawing.Color.Azure;
            this.Userspanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Userspanel.Controls.Add(this.btnUser);
            this.Userspanel.Location = new System.Drawing.Point(25, 51);
            this.Userspanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Userspanel.Name = "Userspanel";
            this.Userspanel.Size = new System.Drawing.Size(266, 107);
            this.Userspanel.TabIndex = 0;
            this.Userspanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Userspanel_Paint);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.PowderBlue;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Image = global::FoodHub_Management_System.Properties.Resources.people;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(19, 9);
            this.btnUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(226, 51);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "Total Users";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // Employeespanel
            // 
            this.Employeespanel.BackColor = System.Drawing.Color.Azure;
            this.Employeespanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Employeespanel.Controls.Add(this.btnCus);
            this.Employeespanel.Location = new System.Drawing.Point(630, 51);
            this.Employeespanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Employeespanel.Name = "Employeespanel";
            this.Employeespanel.Size = new System.Drawing.Size(266, 107);
            this.Employeespanel.TabIndex = 1;
            this.Employeespanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Employeespanel_Paint);
            // 
            // btnCus
            // 
            this.btnCus.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCus.Image = global::FoodHub_Management_System.Properties.Resources.target_audience;
            this.btnCus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCus.Location = new System.Drawing.Point(17, 9);
            this.btnCus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCus.Name = "btnCus";
            this.btnCus.Size = new System.Drawing.Size(226, 51);
            this.btnCus.TabIndex = 6;
            this.btnCus.Text = "Total Customers";
            this.btnCus.UseVisualStyleBackColor = false;
            this.btnCus.Click += new System.EventHandler(this.btnCus_Click);
            // 
            // Adminpanel
            // 
            this.Adminpanel.BackColor = System.Drawing.Color.Azure;
            this.Adminpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Adminpanel.Controls.Add(this.btnOrders);
            this.Adminpanel.Location = new System.Drawing.Point(933, 51);
            this.Adminpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Adminpanel.Name = "Adminpanel";
            this.Adminpanel.Size = new System.Drawing.Size(266, 107);
            this.Adminpanel.TabIndex = 3;
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.PowderBlue;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.Image = global::FoodHub_Management_System.Properties.Resources.checkout__1_;
            this.btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.Location = new System.Drawing.Point(21, 9);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(226, 51);
            this.btnOrders.TabIndex = 7;
            this.btnOrders.Text = "Total Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // Customerpanel
            // 
            this.Customerpanel.BackColor = System.Drawing.Color.Azure;
            this.Customerpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Customerpanel.Controls.Add(this.btnEmp);
            this.Customerpanel.Location = new System.Drawing.Point(327, 51);
            this.Customerpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Customerpanel.Name = "Customerpanel";
            this.Customerpanel.Size = new System.Drawing.Size(266, 107);
            this.Customerpanel.TabIndex = 2;
            // 
            // btnEmp
            // 
            this.btnEmp.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmp.Image = global::FoodHub_Management_System.Properties.Resources.teamwork;
            this.btnEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmp.Location = new System.Drawing.Point(18, 9);
            this.btnEmp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(226, 51);
            this.btnEmp.TabIndex = 5;
            this.btnEmp.Text = "Total Employees";
            this.btnEmp.UseVisualStyleBackColor = false;
            this.btnEmp.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Location = new System.Drawing.Point(25, 188);
            this.dgvInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersWidth = 51;
            this.dgvInfo.RowTemplate.Height = 24;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(1174, 604);
            this.dgvInfo.TabIndex = 4;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1222, 806);
            this.Controls.Add(this.dgvInfo);
            this.Controls.Add(this.Adminpanel);
            this.Controls.Add(this.Employeespanel);
            this.Controls.Add(this.Customerpanel);
            this.Controls.Add(this.Userspanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Userspanel.ResumeLayout(false);
            this.Employeespanel.ResumeLayout(false);
            this.Adminpanel.ResumeLayout(false);
            this.Customerpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Userspanel;
        private System.Windows.Forms.Panel Employeespanel;
        private System.Windows.Forms.Panel Adminpanel;
        private System.Windows.Forms.Panel Customerpanel;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Button btnCus;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Button btnOrders;
    }
}