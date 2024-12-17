using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using WindowsFormsApp1.Logic;

namespace WindowsFormsApp1
{
    public partial class ProductManager : Form
    {
        public ProductManager()
        {
            InitializeComponent();
            ReadProducts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ReadProducts()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("SKU");
            dataTable.Columns.Add("Category");
            dataTable.Columns.Add("Net Price");
            dataTable.Columns.Add("Vat");
            dataTable.Columns.Add("Stock");
            dataTable.Columns.Add("Vendor");

            var logic = new ProductParser();
            var products = logic.GetProducts();

            foreach (var product in products)
            {
                var row = dataTable.NewRow();

                // Populate the row with the product data
                row["ID"] = product.Id;
                row["Name"] = product.Name;
                row["SKU"] = product.Sku;
                row["Category"] = product.Category;
                row["Net Price"] = product.NetPrice;
                row["Vat"] = product.Vat;
                row["Stock"] = product.Stock;
                row["Vendor"] = product.Vendor;


                // Add the row to the DataTable

                dataTable.Rows.Add(row);
            }
          

            this.productsTable.DataSource = dataTable;


        }

        private void productsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            CreateEditProduct form = new CreateEditProduct();
            if(form.ShowDialog() == DialogResult.OK)
            {
                ReadProducts();
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            var val = this.productsTable.SelectedRows[0].Cells[0].Value.ToString();
            if (val == null || val.Length == 0) return;

            int productId = int.Parse(val);

            var repo = new ProductParser();
            var product = repo.GetProduct(productId);

            if(product == null) return;

            CreateEditProduct form = new CreateEditProduct();

            form.EditProduct(product);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReadProducts();
            }
        }

        private void productsTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (this.productsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var val = this.productsTable.SelectedRows[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(val)) return;

            // Parse the product ID
            int productId = int.Parse(val);

            // Ask the user for confirmation
            DialogResult dialogResult = MessageBox.Show(
                "Do you want to delete this record?",
                "Delete Product",
                MessageBoxButtons.YesNo, // Correct the button style
                MessageBoxIcon.Question); // Add an icon to the message box

            // If the user clicks "No", return without deleting
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // Call the method to delete the product
            var repo = new ProductParser();
            bool isDeleted = repo.DeleteProduct(productId);

            if (isDeleted)
            {
                MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to delete the product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Refresh the product list after deletion
            ReadProducts();
        }

    }
}
