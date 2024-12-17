using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Logic;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Diagnostics;


namespace WindowsFormsApp1
{
    public partial class CreateInvoice : Form
    {
        public Customer selectedCustomer {  get; set; }
        public Invoice currentInvoice {  get; set; }
        private List<RecordCheckout> productList;
        private decimal totalSum = 0;
        public String connectionString;
        public CreateInvoice(Customer customer, Invoice invoice)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.selectedCustomer = customer;
            this.currentInvoice = invoice;
            InitializeComponent();
            loadConnectionString();
            customerNameTxt.Text = customer.Name;

            productList = new List<RecordCheckout>();
            LoadProductsForInvoice();
        }

        public void loadConnectionString()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(exeDirectory, "connectionString.txt");

            try
            {
                connectionString = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        private void addButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecordManager form = new RecordManager(6);
            form.currentInvoice = currentInvoice;
            form.SelectedCustomer = selectedCustomer;
            form.Show();
        }

        






       

        private void button1_Click(object sender, EventArgs e)
        {
            

            

        }

        private void LoadProductsForInvoice()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                SELECT p.name AS ProductName, 
                       p.net_price AS Price, 
                       p.vat AS VAT, 
                       pl.quantity AS Quantity
                FROM Product_list pl
                JOIN Product p ON pl.Product_id = p.id
                WHERE pl.Invoice_id = @InvoiceId";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceId", currentInvoice.Id);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable productsData = new DataTable();
                            adapter.Fill(productsData);
                            checkoutTable.DataSource = productsData;
                            LoadProductsToArrayList(productsData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProductsToArrayList(DataTable productsData)
        {
            this.productList.Clear(); 
            this.totalSum = 0;
            foreach (DataRow row in productsData.Rows)
            {
                string productName = row["ProductName"].ToString();
                decimal nettoPrice = Convert.ToDecimal(row["Price"]); 
                decimal vatPercentage = Convert.ToDecimal(row["VAT"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                this.totalSum += quantity * (nettoPrice + nettoPrice * (vatPercentage/100));
                this.productList.Add(new RecordCheckout(productName, nettoPrice, vatPercentage, quantity));
            }
            MessageBox.Show($"Loaded {productList.Count} products into the productList.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }









        private void productsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreateInvoice_Load(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.hurtowniaDataSet.Product);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.checkoutTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var val = this.checkoutTable.SelectedRows[0].Cells["ProductName"].Value?.ToString();
            if (string.IsNullOrEmpty(val))
            {
                MessageBox.Show("Invalid selection. Please select a valid product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show(
                $"Do you want to remove the product '{val}' from the invoice?",
                "Delete Product from Invoice",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                return;
            }
            string productName = val;
            int invoiceId = currentInvoice.Id;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                DELETE FROM Product_list
                WHERE Product_id = (SELECT id FROM Product WHERE name = @ProductName)
                AND Invoice_id = @InvoiceId";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@InvoiceId", invoiceId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Product '{productName}' was removed from the invoice.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove the product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                LoadProductsForInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while deleting the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createInvoiceButton_Click(object sender, EventArgs e)
        {
            GenerateInvoiceFile();
        }
      
        private void GenerateInvoiceFile()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            string filePath = Path.Combine($"Invoice_{currentInvoice.Id}_{currentInvoice.Date.Hour}_{currentInvoice.Date.Day}.{currentInvoice.Date.Month}.{currentInvoice.Date.Year}.pdf");

            try
            {
                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.Content().Column(column =>
                        {
                            column.Spacing(10);
                            Company company = loadDataFromFile();

                            column.Item().Text("----------------------------------------------------------------------------------------------------");
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text($"Invoice ID: {currentInvoice.Id}").Bold();
                                row.RelativeItem().Text($"Date: {DateTime.Now:yyyy-MM-dd}").AlignRight();
                            });

                            column.Item().Text("----------------------------------------------------------------------------------------------------");

                            // Seller Details
                            column.Item().Text("Invoice").Bold().FontSize(18).AlignCenter();
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(seller =>
                                {
                                    seller.Item().Text("Seller:").Bold().FontSize(14);
                                    seller.Item().Text("Name: "+company.Name);
                                    seller.Item().Text("Nip: " + company.Nip);
                                    seller.Item().Text("Address: ");
                                    seller.Item().Text(company.Country);
                                    seller.Item().Text(company.Postal_code + ", " +company.City);
                                    seller.Item().Text(company.Address_row1);
                                    seller.Item().Text(company.Address_row2);
                                });

                                row.ConstantItem(50); // Spacer between columns

                                row.RelativeItem().Column(buyer =>
                                {
                                    buyer.Item().Text("Buyer:").Bold().FontSize(14);
                                    buyer.Item().Text($"Name: {selectedCustomer.Name}");
                                    buyer.Item().Text("Nip: " + selectedCustomer.Nip);
                                    buyer.Item().Text($"Address: ");
                                    buyer.Item().Text(selectedCustomer.Country);
                                    buyer.Item().Text(selectedCustomer.Postal_code + ", " + selectedCustomer.City);
                                    buyer.Item().Text(selectedCustomer.Address_row1);
                                    buyer.Item().Text(selectedCustomer.Address_row2);
                                });
                            });



                            // Product Table
                            column.Item().Text("----------------------------------------------------------------------------------------------------");
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Product Name
                                    columns.RelativeColumn(2); // Net Price
                                    columns.RelativeColumn(2); // VAT
                                    columns.RelativeColumn(2); // Quantity
                                    columns.RelativeColumn(2); // Total
                                });
                                
                                // Table Header
                                table.Header(header =>
                                {
                                    header.Cell().Text("Product").Bold();
                                    header.Cell().Text("Net Price (PLN)").Bold().AlignRight();
                                    header.Cell().Text("VAT (%)").Bold().AlignRight();
                                    header.Cell().Text("Quantity").Bold().AlignCenter();
                                    header.Cell().Text("Total (PLN)").Bold().AlignRight();
                                });

                                decimal totalAmount = 0;

                                // Table Rows
                                foreach (var product in productList)
                                {
                                    totalAmount += product.totalPrice;

                                    table.Cell().Text(product.productName);
                                    table.Cell().Text($"{product.nettoPrice:F2}").AlignRight();
                                    table.Cell().Text($"{product.vatPercentage:F2}").AlignRight();
                                    table.Cell().Text(product.quantity.ToString()).AlignCenter();
                                    table.Cell().Text($"{product.totalPrice:F2}").AlignRight();
                                }
                            });

                            column.Item().Text("----------------------------------------------------------------------------------------------------");

                            // Total Amount
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text("Total Amount:").Bold().FontSize(14);
                                row.RelativeItem().Text($"{this.totalSum:F2} PLN").Bold().FontSize(14).AlignRight();
                            });

                            column.Item().Text("----------------------------------------------------------------------------------------------------");

                            // Footer
                            column.Item().Text("Thank you for your purchase!")
                                .Bold()
                                .FontSize(12)
                                .AlignCenter();
                        });
                    });
                });

                document.GeneratePdf(filePath);
                UpdateInvoiceStatus(filePath);
                OpenFile(filePath);

                MessageBox.Show($"Invoice PDF has been generated at: {filePath}", "Invoice Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating invoice file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile(string filePath)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Company loadDataFromFile()
        {
            string file = "companyInfo.txt";

            // Initialize a new Company object
            Company company = new Company();

            try
            {
                // Check if the file exists
                if (!System.IO.File.Exists(file))
                {
                    // Default placeholder values
                    string[] defaultData = new string[]
                    {
                "Your Company Name",     // Placeholder for company name
                "0000000000",            // Placeholder for NIP
                "Country",               // Placeholder for country
                "City",                  // Placeholder for city
                "000-000",               // Placeholder for postal code
                "Street Address Line 1", // Placeholder for address row 1
                "Street Address Line 2"  // Placeholder for address row 2
                    };
                    System.IO.File.WriteAllLines(file, defaultData);
                    MessageBox.Show("The file was not found and has been created with default values.",
                                    "File Created",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                string[] lines = System.IO.File.ReadAllLines(file);
                if (lines.Length < 7)
                {
                    MessageBox.Show("The file format is incorrect. Please ensure the file contains 7 lines of company information.",
                                    "File Format Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    company.Name = lines[0];       // Company Name
                    company.Nip = lines[1];        // NIP
                    company.Country = lines[2];    // Country
                    company.City = lines[3];       // City
                    company.Postal_code = lines[4]; // Postal Code
                    company.Address_row1 = lines[5]; // Address Row 1
                    company.Address_row2 = lines[6]; // Address Row 2
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing the file: {ex.Message}",
                                "File Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            return company;
        }




        private void UpdateInvoiceStatus(string filePath)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateInvoiceSql = @"
                UPDATE Invoice
                SET status = 1, invoice = @FilePath
                WHERE id = @InvoiceId";

                    using (SqlCommand command = new SqlCommand(updateInvoiceSql, connection))
                    {
                        command.Parameters.AddWithValue("@FilePath", filePath);
                        command.Parameters.AddWithValue("@InvoiceId", currentInvoice.Id);
                        command.ExecuteNonQuery();
                    }
                    foreach (var product in productList)
                    {
                        string updateStockSql = @"
                    UPDATE Product
                    SET stock = stock - @Quantity
                    WHERE id = (SELECT Product_id FROM Product_list WHERE Invoice_id = @InvoiceId AND Product_id = (SELECT id FROM Product WHERE name = @ProductName))";

                        using (SqlCommand stockCommand = new SqlCommand(updateStockSql, connection))
                        {
                            stockCommand.Parameters.AddWithValue("@Quantity", product.quantity);
                            stockCommand.Parameters.AddWithValue("@InvoiceId", currentInvoice.Id);
                            stockCommand.Parameters.AddWithValue("@ProductName", product.productName);
                            stockCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating invoice status or stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            var repo = new InvoiceParser();
            bool isDeleted = repo.DeleteInvoice(currentInvoice.Id);

            if (isDeleted)
            {
                MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to delete the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }
    }
}
