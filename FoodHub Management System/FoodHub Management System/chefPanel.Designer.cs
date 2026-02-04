namespace FoodHub_Management_System
{
    partial class chefPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelOrders = new System.Windows.Forms.Button();
            this.completeOrder = new System.Windows.Forms.Button();
            this.allorders = new System.Windows.Forms.Button();
            this.pandingOrder = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.cancelOrders);
            this.panel1.Controls.Add(this.completeOrder);
            this.panel1.Controls.Add(this.allorders);
            this.panel1.Controls.Add(this.pandingOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 653);
            this.panel1.TabIndex = 0;
            // 
            // cancelOrders
            // 
            this.cancelOrders.Location = new System.Drawing.Point(48, 427);
            this.cancelOrders.Name = "cancelOrders";
            this.cancelOrders.Size = new System.Drawing.Size(155, 45);
            this.cancelOrders.TabIndex = 3;
            this.cancelOrders.Text = "Cancel Orders";
            this.cancelOrders.UseVisualStyleBackColor = true;
            // 
            // completeOrder
            // 
            this.completeOrder.Location = new System.Drawing.Point(48, 366);
            this.completeOrder.Name = "completeOrder";
            this.completeOrder.Size = new System.Drawing.Size(155, 45);
            this.completeOrder.TabIndex = 2;
            this.completeOrder.Text = "Completed Orders";
            this.completeOrder.UseVisualStyleBackColor = true;
            // 
            // allorders
            // 
            this.allorders.Location = new System.Drawing.Point(48, 305);
            this.allorders.Name = "allorders";
            this.allorders.Size = new System.Drawing.Size(155, 45);
            this.allorders.TabIndex = 1;
            this.allorders.Text = "All Orders";
            this.allorders.UseVisualStyleBackColor = true;
            // 
            // pandingOrder
            // 
            this.pandingOrder.Location = new System.Drawing.Point(48, 235);
            this.pandingOrder.Name = "pandingOrder";
            this.pandingOrder.Size = new System.Drawing.Size(155, 52);
            this.pandingOrder.TabIndex = 0;
            this.pandingOrder.Text = "Panding Orders";
            this.pandingOrder.UseVisualStyleBackColor = true;
            this.pandingOrder.Click += new System.EventHandler(this.pandingOrder_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(254, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(897, 653);
            this.MainPanel.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::FoodHub_Management_System.Properties.Resources._switch;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(37, 592);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(179, 49);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // chefPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 653);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "chefPanel";
            this.Text = "chefPanel";
            this.Load += new System.EventHandler(this.chefPanel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button allorders;
        private System.Windows.Forms.Button pandingOrder;
        private System.Windows.Forms.Button completeOrder;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button cancelOrders;
        private System.Windows.Forms.Button btnLogout;
    }
}