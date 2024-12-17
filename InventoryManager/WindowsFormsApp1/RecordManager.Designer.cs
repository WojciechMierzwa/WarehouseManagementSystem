using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class RecordManager
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
            this.recordTable = new System.Windows.Forms.DataGridView();
            this.hurtowniaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hurtowniaDataSet = new WindowsFormsApp1.HurtowniaDataSet();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.recordTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // recordTable
            // 
            this.recordTable.AllowUserToAddRows = false;
            this.recordTable.AllowUserToDeleteRows = false;
            this.recordTable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.recordTable.AutoGenerateColumns = true;
            this.recordTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.recordTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordTable.DataSource = this.hurtowniaDataSetBindingSource;
            this.recordTable.Location = new System.Drawing.Point(12, 87);
            this.recordTable.MultiSelect = false;
            this.recordTable.Name = "recordTable";
            this.recordTable.ReadOnly = true;
            this.recordTable.RowHeadersWidth = 51;
            this.recordTable.RowTemplate.Height = 24;
            this.recordTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recordTable.Size = new System.Drawing.Size(1368, 572);
            this.recordTable.TabIndex = 0;
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
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.AutoSize = true;
            this.addButton.Location = new System.Drawing.Point(832, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(178, 59);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(1016, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(178, 59);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(1200, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(178, 59);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.Location = new System.Drawing.Point(25, 39);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(229, 32);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Manage Records";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // quantityTxt
            // 
            this.quantityTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.quantityTxt.Location = new System.Drawing.Point(639, 41);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(100, 30);
            this.quantityTxt.TabIndex = 5;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.quantityLabel.Location = new System.Drawing.Point(487, 45);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(136, 25);
            this.quantityLabel.TabIndex = 6;
            this.quantityLabel.Text = "Enter Quantity";
            // 
            // RecordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 671);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantityTxt);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.recordTable);
            this.Name = "RecordManager";
            this.Text = "RecordManager";
            this.Load += new System.EventHandler(this.RecordManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recordTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurtowniaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView recordTable;
        private System.Windows.Forms.BindingSource hurtowniaDataSetBindingSource;
        private HurtowniaDataSet hurtowniaDataSet;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label labelTitle;
        private TextBox quantityTxt;
        private Label quantityLabel;
    }
}