using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Logic;
using WindowsFormsApp1.Models;
/*
 * mode 1 Customers
 * mode 2 Products
 * mode 3 Employees
 * mode 4 Invoice
 * mode 5 choose customer for invoice
 * mode 6 chose products for invoice
 */
namespace WindowsFormsApp1
{ 
    public partial class RecordManager : Form
    {
        int mode;
        private Cart cart;
        public String connectionString;
        public Customer SelectedCustomer { get; set; }
        public Invoice currentInvoice { get; set; }


        public RecordManager(int mode)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            loadConnectionString();
            this.mode = mode;
            Mode();


        }




        private void Mode()
        {
            quantityLabel.Hide();
            quantityTxt.Hide();

            if (mode == 1)
            {
                labelTitle.Text = "Manage Customers";
                addButton.Text = "Add Customer";
                editButton.Text = "Edit Customer";
                deleteButton.Text = "Delete Customer";
                ReadCustomers();

            }

            else if (mode == 2)
            {
                labelTitle.Text = "Manage Products";
                addButton.Text = "Add Product";
                editButton.Text = "Edit Product";
                deleteButton.Text = "Delete Product";
                ReadProducts();

            }

            else if (mode == 3)
            {
                labelTitle.Text = "Manage Employees";
                addButton.Text = "Add Employee";
                editButton.Text = "Edit Employee";
                deleteButton.Text = "Delete Employee";
                ReadEmployees();

            }

            else if (mode == 4)
            {
                labelTitle.Text = "Manage Orders";
                addButton.Text = "Add Order";
                editButton.Text = "View invoice";
                deleteButton.Text = "Delete Order";
                ReadInvoices();
            }
            else if (mode == 5)
            {
                labelTitle.Text = "Manage Customers";
                addButton.Text = "Add Customer";
                editButton.Text = "Edit Customer";
                deleteButton.Text = "Select Customer";
                ReadCustomers();

            }
            else if (mode == 6)
            {
                addButton.Hide();
                quantityLabel.Show();
                quantityTxt.Show();
                editButton.Text = "Checkout";
                deleteButton.Text = "Select Product";
                ReadProducts();
                
            }


        }

      

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }




        //READERS
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

                row["ID"] = product.Id;
                row["Name"] = product.Name;
                row["SKU"] = product.Sku;
                row["Category"] = product.Category;
                row["Net Price"] = product.NetPrice;
                row["Vat"] = product.Vat;
                row["Stock"] = product.Stock;
                row["Vendor"] = product.Vendor;

                dataTable.Rows.Add(row);
            }


            this.recordTable.DataSource = dataTable;



        }
        private void ReadCustomers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Phone Number");
            dataTable.Columns.Add("Mail");
            dataTable.Columns.Add("Nip");
            dataTable.Columns.Add("Country");
            dataTable.Columns.Add("City");
            dataTable.Columns.Add("Postal Code");
            dataTable.Columns.Add("Address Row 1");
            dataTable.Columns.Add("Address Row 2");

            var logic = new CustomerParser();
            var customers = logic.GetCustomers();

            foreach (var customer in customers)
            {
                var row = dataTable.NewRow();
                row["ID"] = customer.Id;
                row["Name"] = customer.Name;
                row["Phone Number"] = customer.Phone_number;
                row["Mail"] = customer.Mail;
                row["Nip"] = customer.Nip;
                row["Country"] = customer.Country;
                row["City"] = customer.City;
                row["Postal Code"] = customer.Postal_code;
                row["Address Row 1"] = customer.Address_row1;
                row["Address Row 2"] = customer.Address_row2;
                dataTable.Rows.Add(row);
            }

            this.recordTable.DataSource = dataTable;
            Console.WriteLine($"Total customers retrieved: {customers.Count}");

        }

        private void ReadEmployees()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("Login", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));

            var logic = new EmployeeParser();
            var employees = logic.GetEmployees();


            foreach (var employee in employees)
            {
                var row = dataTable.NewRow();

                row["ID"] = employee.Id;
                row["Name"] = employee.Name;
                row["Surname"] = employee.Surname;
                row["Login"] = employee.Login;
                row["Password"] = employee.Password;

                dataTable.Rows.Add(row);
            }

            this.recordTable.DataSource = dataTable;
        }

        

       
        private void ReadInvoices()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Status");
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("Customer ID");
            dataTable.Columns.Add("Invoice");

            var logic = new InvoiceParser();
            var invoices = logic.GetInvoices();

            foreach (var invoice in invoices)
            {
                var row = dataTable.NewRow();

                row["ID"] = invoice.Id;
                row["Status"] = invoice.Status;
                row["Date"] = invoice.Date;
                row["Customer ID"] = invoice.CustomerId;
                row["Invoice"] = invoice.InvoiceFilePath;

                dataTable.Rows.Add(row);
            }

            // Bind the DataTable to the DataGridView (or your desired control)
            this.recordTable.DataSource = dataTable;
        }




        private void addButton_Click(object sender, EventArgs e)
        {
            if (mode == 1 || mode ==5)
            {
                CreateEditCustomer form = new CreateEditCustomer();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadCustomers();
                }
            }
            else if (mode == 2)
            {
                CreateEditProduct form = new CreateEditProduct();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadProducts();
                }
            }
            else if (mode == 3)
            {
                CreateEditEmployee form = new CreateEditEmployee();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadEmployees();
                }
            }
            else if (mode == 4) {
                mode = 5;
                ReadCustomers();
                deleteButton.Text = "Select";
            }
            else if (mode == 6)
            {
                quantityLabel.Show();
                quantityLabel.Show();
                addButton.Hide();
                editButton.Text = "Checkout";
                deleteButton.Text = "Select Product";
                ReadProducts();
            }




        }

  

        private void editButton_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (val == null || val.Length == 0) return;

                int recordId = int.Parse(val);

                var repo = new CustomerParser();
                var record = repo.GetCustomer(recordId);

                if (record == null) return;

                CreateEditCustomer form = new CreateEditCustomer();

                form.EditCustomer(record);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadCustomers();
                }
            }
            else if (mode == 2)
            {
                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (val == null || val.Length == 0) return;

                int recordId = int.Parse(val);

                var repo = new ProductParser();
                var record = repo.GetProduct(recordId);

                if (record == null) return;

                CreateEditProduct form = new CreateEditProduct();

                form.EditProduct(record);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadProducts();
                }
            }
            else if (mode == 3)
            {
                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (val == null || val.Length == 0) return;

                int recordId = int.Parse(val);

                var repo = new EmployeeParser();
                var record = repo.GetEmployee(recordId);

                if (record == null) return;

                CreateEditEmployee form = new CreateEditEmployee();

                form.EditEmployee(record);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadEmployees();
                }

            }
            else if(mode == 4)
            {
                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (val == null || val.Length == 0) return;

                int recordId = int.Parse(val);

                var repo = new InvoiceParser();
                var record = repo.GetInvoice(recordId);

                if (record == null) return;

                OpenFile(record.InvoiceFilePath);
                

                
            }
            else if(mode == 5)
            {
                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (val == null || val.Length == 0) return;

                int recordId = int.Parse(val);

                var repo = new CustomerParser();
                var record = repo.GetCustomer(recordId);

                if (record == null) return;

                CreateEditCustomer form = new CreateEditCustomer();

                form.EditCustomer(record);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadCustomers();
                }
            }
            else if (mode == 6)
            {
                CreateInvoice createInvoice = new CreateInvoice(SelectedCustomer,currentInvoice);
                createInvoice.Show();
                this.Hide();

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
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (this.recordTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(val)) return;

                int recordId = int.Parse(val);

                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to delete this record?",
                    "Delete Cusomer",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                var repo = new CustomerParser();
                bool isDeleted = repo.DeleteCustomer(recordId);

                if (isDeleted)
                {
                    MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the customer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReadCustomers();
            }
            if (mode == 5)
            {
                deleteButton.Text = "Select";
                //ReadCustomers();

                // Ensure a row is selected
                if (this.recordTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve the Customer ID from the selected row
                var val = this.recordTable.SelectedRows[0].Cells["id"].Value?.ToString();
                if (string.IsNullOrEmpty(val))
                {
                    MessageBox.Show("Selected row does not contain a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(val, out int customerId))
                {
                    MessageBox.Show("Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Fetch the Customer object
                var customerRepo = new CustomerParser();
                var customer = customerRepo.GetCustomer(customerId);

                if (customer == null)
                {
                    MessageBox.Show("No customer found for the selected ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the selected customer is already set
                if (SelectedCustomer != null && SelectedCustomer.Id == customer.Id)
                {
                    MessageBox.Show("This customer is already selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Set the selected customer
                SelectedCustomer = customer;

                // Create an invoice for the selected customer
                var currentInvoice = new Invoice
                {
                    Status = false, // Default to false
                    Date = DateTime.Now, // Current time
                    CustomerId = SelectedCustomer.Id, // Assign the selected customer's ID
                    InvoiceFilePath = null // Not set for now
                };

                // Save the invoice to the database
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string sql = @"
                INSERT INTO Invoice (status, date, Customer_id, invoice)
                OUTPUT INSERTED.id
                VALUES (@status, @date, @customerId, @invoiceFilePath)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@status", currentInvoice.Status);
                            command.Parameters.AddWithValue("@date", currentInvoice.Date);
                            command.Parameters.AddWithValue("@customerId", currentInvoice.CustomerId);
                            command.Parameters.AddWithValue("@invoiceFilePath", (object)currentInvoice.InvoiceFilePath ?? DBNull.Value);

                            // Retrieve the ID of the newly inserted invoice
                            currentInvoice.Id = (int)command.ExecuteScalar();
                        }
                    }

                    MessageBox.Show($"Invoice created successfully with ID: {currentInvoice.Id}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.currentInvoice = currentInvoice;

                // Proceed with setting up for product selection
                labelTitle.Text = "Select Product";
                addButton.Hide();
                editButton.Text = "Checkout";
                deleteButton.Text = "Select Product";
                ReadProducts();

                mode = 6;
                quantityLabel.Show();
                quantityTxt.Show();
            }



            else if (mode == 2)
            {
                if (this.recordTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(val)) return;

                int recordId = int.Parse(val);

                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to delete this record?",
                    "Delete Product",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question); 

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                var repo = new ProductParser();
                bool isDeleted = repo.DeleteProduct(recordId);

                if (isDeleted)
                {
                    MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReadProducts();
            }
            else if (mode == 3)
            {
                if (this.recordTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a employee to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(val)) return;

                int recordId = int.Parse(val);

                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to delete this record?",
                    "Delete Product",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                var repo = new EmployeeParser();
                bool isDeleted = repo.DeleteEmployee(recordId);

                if (isDeleted)
                {
                    MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the employee. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReadEmployees();
            }
            else if (mode == 4)
            {
                if (this.recordTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a order to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var val = this.recordTable.SelectedRows[0].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(val)) return;

                int recordId = int.Parse(val);

                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to delete this record?",
                    "Delete Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                var repo = new InvoiceParser();
                bool isDeleted = repo.DeleteInvoice(recordId);

                if (isDeleted)
                {
                    MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the employee. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReadInvoices();
            }
            else if (mode == 6)
            {
                quantityTxt.Show();
                quantityLabel.Show();

                // Ensure a row is selected
                if (this.recordTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product to add to the invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve the Product ID from the selected row
                var val = this.recordTable.SelectedRows[0].Cells["ID"].Value?.ToString();
                if (string.IsNullOrEmpty(val) || !int.TryParse(val, out int productId))
                {
                    MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the quantity entered is valid
                if (string.IsNullOrEmpty(quantityTxt.Text) || !int.TryParse(quantityTxt.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the invoice exists
                if (currentInvoice == null)
                {
                    MessageBox.Show("No valid Invoice found. Please select a customer first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a ProductList entry for the selected product and current invoice
                var productListEntry = new ProductList
                {
                    ProductId = productId,
                    InvoiceId = currentInvoice.Id,
                    Quantity = quantity
                };

                // Save the ProductList entry to the database
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string sql = @"
                INSERT INTO Product_list (Product_id, Invoice_id, quantity)
                VALUES (@productId, @invoiceId, @quantity)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@productId", productListEntry.ProductId);
                            command.Parameters.AddWithValue("@invoiceId", productListEntry.InvoiceId);
                            command.Parameters.AddWithValue("@quantity", productListEntry.Quantity);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Product ID {productId} added to Invoice ID {currentInvoice.Id} with quantity {quantity}.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding product to invoice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Refresh the product list for user feedback
                ReadProducts();
            }


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

        private void RecordManager_Load(object sender, EventArgs e)
        {

        }
    }
}
