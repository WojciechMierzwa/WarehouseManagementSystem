using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Logic;

namespace WindowsFormsApp1
{
    public partial class CreateEditProduct : Form
    {

        public CreateEditProduct()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.IdTxt.Enabled = false;
            this.IdTxt.Text = string.Empty; 
        }

        private Boolean action = true;
        public void EditProduct(Product product)
        {
            action = false;
            this.IdTxt.Text = product.Id.ToString();
            this.Text = "Edit product";
            this.lb.Text = "Edit Product";
            this.IdTxt.Text = "" + product.Id;
            this.nameTxt.Text = "" + product.Name;
            this.skuTxt.Text = "" + product.Sku;
            this.vatTxt.Text = "" + product.Vat;
            this.vendorTxt.Text = product.Vendor;
            this.netPriceTxt.Text = "" + product.NetPrice;
            this.categoryTxt.Text = "" + product.Category;
            this.stockTxt.Text = "" + product.Stock;
          
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    Id = action ? 0 : int.Parse(this.IdTxt.Text),
                    Name = this.nameTxt.Text,
                    Sku = int.Parse(this.skuTxt.Text),
                    Vat = decimal.Parse(this.vatTxt.Text),
                    Vendor = this.vendorTxt.Text,
                    NetPrice = decimal.Parse(this.netPriceTxt.Text),
                    Category = this.categoryTxt.Text,
                    Stock = int.Parse(this.stockTxt.Text)
                };

                var logic = new ProductParser();

                if (action)
                {
                    logic.AddProduct(product);
                }
                else
                {
                    logic.EditProduct(product);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for SKU, VAT, Net Price, and Stock.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lb_Click(object sender, EventArgs e)
        {

        }

        private void CreateEditProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
