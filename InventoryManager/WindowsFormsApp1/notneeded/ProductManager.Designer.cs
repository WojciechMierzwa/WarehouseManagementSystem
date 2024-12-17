namespace WindowsFormsApp1
{
    partial class ProductManager
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
            this.hurtowniaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hurtowniaDataSet = new WindowsFormsApp1.HurtowniaDataSet();
            this.addProductButton = new System.Windows.Forms.Button();
            this.editProductButton = new System.Windows.Forms.Button();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.productsTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsTable)).BeginInit();
            this.SuspendLayout();
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
            // addProductButton
            // 
            this.addProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addProductButton.Location = new System.Drawing.Point(527, 22);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(136, 41);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Add Product";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // editProductButton
            // 
            this.editProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editProductButton.Location = new System.Drawing.Point(669, 22);
            this.editProductButton.Name = "editProductButton";
            this.editProductButton.Size = new System.Drawing.Size(135, 41);
            this.editProductButton.TabIndex = 2;
            this.editProductButton.Text = "Edit Product";
            this.editProductButton.UseVisualStyleBackColor = true;
            this.editProductButton.Click += new System.EventHandler(this.editProductButton_Click);
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteProductButton.Location = new System.Drawing.Point(810, 22);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(131, 41);
            this.deleteProductButton.TabIndex = 3;
            this.deleteProductButton.Text = "Delete Product";
            this.deleteProductButton.UseVisualStyleBackColor = true;
            this.deleteProductButton.Click += new System.EventHandler(this.deleteProductButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title.Location = new System.Drawing.Point(12, 24);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(197, 29);
            this.Title.TabIndex = 4;
            this.Title.Text = "Product Manager";
            // 
            // productsTable
            // 
            this.productsTable.AllowUserToAddRows = false;
            this.productsTable.AllowUserToOrderColumns = true;
            this.productsTable.AutoGenerateColumns = false;
            this.productsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsTable.DataSource = this.hurtowniaDataSetBindingSource;
            this.productsTable.Location = new System.Drawing.Point(12, 69);
            this.productsTable.MultiSelect = false;
            this.productsTable.Name = "productsTable";
            this.productsTable.ReadOnly = true;
            this.productsTable.RowHeadersVisible = false;
            this.productsTable.RowHeadersWidth = 51;
            this.productsTable.RowTemplate.Height = 24;
            this.productsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productsTable.Size = new System.Drawing.Size(918, 369);
            this.productsTable.TabIndex = 5;
            this.productsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productsTable_CellContentClick_1);
            // 
            // ProductManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.productsTable);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.deleteProductButton);
            this.Controls.Add(this.editProductButton);
            this.Controls.Add(this.addProductButton);
            this.Name = "ProductManager";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource hurtowniaDataSetBindingSource;
        private HurtowniaDataSet hurtowniaDataSet;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button editProductButton;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.DataGridView productsTable;
    }
}

