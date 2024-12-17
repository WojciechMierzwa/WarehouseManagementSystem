namespace WindowsFormsApp1
{
    partial class CreateInvoice
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.customerNameTxt = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.createInvoiceButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.hurtowniaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hurtowniaDataSet = new WindowsFormsApp1.HurtowniaDataSet();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new WindowsFormsApp1.HurtowniaDataSetTableAdapters.ProductTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.checkoutTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkoutTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(355, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Order";
            // 
            // customerNameTxt
            // 
            this.customerNameTxt.Location = new System.Drawing.Point(234, 93);
            this.customerNameTxt.Name = "customerNameTxt";
            this.customerNameTxt.Size = new System.Drawing.Size(375, 22);
            this.customerNameTxt.TabIndex = 4;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(245, 164);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // createInvoiceButton
            // 
            this.createInvoiceButton.Location = new System.Drawing.Point(343, 164);
            this.createInvoiceButton.Name = "createInvoiceButton";
            this.createInvoiceButton.Size = new System.Drawing.Size(133, 23);
            this.createInvoiceButton.TabIndex = 11;
            this.createInvoiceButton.Text = "Create Invoice";
            this.createInvoiceButton.UseVisualStyleBackColor = true;
            this.createInvoiceButton.Click += new System.EventHandler(this.createInvoiceButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(149, 164);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(498, 164);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(93, 23);
            this.abortButton.TabIndex = 13;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // hurtowniaDataSetBindingSource
            // 
            this.hurtowniaDataSetBindingSource.DataSource = this.hurtowniaDataSet;
            this.hurtowniaDataSetBindingSource.Position = 0;
            // 
            // hurtowniaDataSet
            // 
            this.hurtowniaDataSet.DataSetName = "HurtowniaDataSet";
            this.hurtowniaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.hurtowniaDataSetBindingSource;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Customer";
            // 
            // checkoutTable
            // 
            this.checkoutTable.AllowUserToAddRows = false;
            this.checkoutTable.AllowUserToDeleteRows = false;
            this.checkoutTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkoutTable.Location = new System.Drawing.Point(12, 209);
            this.checkoutTable.MultiSelect = false;
            this.checkoutTable.Name = "checkoutTable";
            this.checkoutTable.ReadOnly = true;
            this.checkoutTable.RowHeadersWidth = 51;
            this.checkoutTable.RowTemplate.Height = 24;
            this.checkoutTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.checkoutTable.Size = new System.Drawing.Size(791, 461);
            this.checkoutTable.TabIndex = 21;
            // 
            // CreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 682);
            this.Controls.Add(this.checkoutTable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.createInvoiceButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.customerNameTxt);
            this.Controls.Add(this.label1);
            this.Name = "CreateInvoice";
            this.Text = "CreateInvoice";
            this.Load += new System.EventHandler(this.CreateInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkoutTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customerNameTxt;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button createInvoiceButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.BindingSource hurtowniaDataSetBindingSource;
        private HurtowniaDataSet hurtowniaDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private HurtowniaDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView checkoutTable;
    }
}