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
    public partial class CustomerManager : Form
    {
        public CustomerManager()
        {
            InitializeComponent();
            ReadCustomers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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

                // Populate the row with the customer data
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

                // Add the row to the DataTable

                dataTable.Rows.Add(row);
            }
          

            this.customersTable.DataSource = dataTable;


        }

        private void customersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            CreateEditCustomer form = new CreateEditCustomer();
            if(form.ShowDialog() == DialogResult.OK)
            {
                ReadCustomers();
            }
        }

        private void editCustomerButton_Click_1(object sender, EventArgs e)
        {
            var val = this.customersTable.SelectedRows[0].Cells[0].Value.ToString();
            if (val == null || val.Length == 0) return;

            int customerId = int.Parse(val);

            var repo = new CustomerParser();
            var customer = repo.GetCustomer(customerId);

            if(customer == null) return;

            CreateEditCustomer form = new CreateEditCustomer();

            form.EditCustomer(customer);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ReadCustomers();
            }
        }

        private void customersTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteCustomerButton_Click_1(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (this.customersTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var val = this.customersTable.SelectedRows[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(val)) return;

            // Parse the customer ID
            int customerId = int.Parse(val);

            // Ask the user for confirmation
            DialogResult dialogResult = MessageBox.Show(
                "Do you want to delete this record?",
                "Delete customer",
                MessageBoxButtons.YesNo, // Correct the button style
                MessageBoxIcon.Question); // Add an icon to the message box

            // If the user clicks "No", return without deleting
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // Call the method to delete the customer
            var repo = new CustomerParser();
            bool isDeleted = repo.DeleteCustomer(customerId);

            if (isDeleted)
            {
                MessageBox.Show("customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to delete the customer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Refresh the customer list after deletion
            ReadCustomers();
        }

      
    }
}
