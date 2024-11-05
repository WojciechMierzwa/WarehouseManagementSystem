namespace InventoryManager
{
    partial class ManagementMenu
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
            ManageEmployeesButton = new Button();
            ManageOrdersButton = new Button();
            ManageProductsButton = new Button();
            ManageCustomersButton = new Button();
            NewOrderButton = new Button();
            ManageVendorsButton = new Button();
            SuspendLayout();
            // 
            // ManageEmployeesButton
            // 
            ManageEmployeesButton.Location = new Point(430, 322);
            ManageEmployeesButton.Name = "ManageEmployeesButton";
            ManageEmployeesButton.Size = new Size(248, 75);
            ManageEmployeesButton.TabIndex = 0;
            ManageEmployeesButton.Text = "Manage Employees";
            ManageEmployeesButton.UseVisualStyleBackColor = true;
            // 
            // ManageOrdersButton
            // 
            ManageOrdersButton.Location = new Point(114, 181);
            ManageOrdersButton.Name = "ManageOrdersButton";
            ManageOrdersButton.Size = new Size(241, 81);
            ManageOrdersButton.TabIndex = 1;
            ManageOrdersButton.Text = "Manage Orders";
            ManageOrdersButton.UseVisualStyleBackColor = true;
            // 
            // ManageProductsButton
            // 
            ManageProductsButton.Location = new Point(433, 52);
            ManageProductsButton.Name = "ManageProductsButton";
            ManageProductsButton.Size = new Size(245, 80);
            ManageProductsButton.TabIndex = 2;
            ManageProductsButton.Text = "Manage Products";
            ManageProductsButton.UseVisualStyleBackColor = true;
            // 
            // ManageCustomersButton
            // 
            ManageCustomersButton.Location = new Point(433, 182);
            ManageCustomersButton.Name = "ManageCustomersButton";
            ManageCustomersButton.Size = new Size(245, 80);
            ManageCustomersButton.TabIndex = 3;
            ManageCustomersButton.Text = "Manage Customers";
            ManageCustomersButton.UseVisualStyleBackColor = true;
            // 
            // NewOrderButton
            // 
            NewOrderButton.Location = new Point(114, 52);
            NewOrderButton.Name = "NewOrderButton";
            NewOrderButton.Size = new Size(244, 75);
            NewOrderButton.TabIndex = 4;
            NewOrderButton.Text = "New Order";
            NewOrderButton.UseVisualStyleBackColor = true;
            NewOrderButton.Click += button2_Click;
            // 
            // ManageVendorsButton
            // 
            ManageVendorsButton.Location = new Point(114, 322);
            ManageVendorsButton.Name = "ManageVendorsButton";
            ManageVendorsButton.Size = new Size(248, 75);
            ManageVendorsButton.TabIndex = 5;
            ManageVendorsButton.Text = "Manage Vendors";
            ManageVendorsButton.UseVisualStyleBackColor = true;
            ManageVendorsButton.Click += button3_Click;
            // 
            // ManagementMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ManageVendorsButton);
            Controls.Add(NewOrderButton);
            Controls.Add(ManageCustomersButton);
            Controls.Add(ManageProductsButton);
            Controls.Add(ManageOrdersButton);
            Controls.Add(ManageEmployeesButton);
            Name = "ManagementMenu";
            Text = "ManagementMenu";
            Load += ManagementMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ManageEmployeesButton;
        private Button ManageOrdersButton;
        private Button ManageProductsButton;
        private Button ManageCustomersButton;
        private Button NewOrderButton;
        private Button ManageVendorsButton;
    }
}