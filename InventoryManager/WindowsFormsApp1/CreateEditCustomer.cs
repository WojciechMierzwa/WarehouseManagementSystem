using System;
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
    public partial class CreateEditCustomer : Form
    {
        public CreateEditCustomer()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.IdTxt.Enabled = false;
            this.IdTxt.Text = string.Empty;
        }
        private Boolean action = true;
        public void EditCustomer(Customer customer)
        {
            action = false;
            this.IdTxt.Text = customer.Id.ToString();
            this.Text = "Edit customer";
            this.lb.Text = "Edit customer";
            this.IdTxt.Text = "" + customer.Id;
            this.nameTxt.Text = "" + customer.Name;
            this.phoneNumberTxt.Text = "" + customer.Phone_number;
            this.mailTxt.Text = "" + customer.Mail;
            this.nipTxt.Text = customer.Nip;
            this.countryTxt.Text = "" + customer.Country;
            this.cityTxt.Text = "" + customer.City;
            this.postalCodeTxt.Text = "" + customer.Postal_code;
            this.addressRow1Txt.Text = "" + customer.Address_row1;
            this.addressRow2Txt.Text = "" + customer.Address_row2;


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Tworzenie obiektu Customer na podstawie wprowadzonych danych
                Customer customer = new Customer
                {
                    Id = action ? 0 : int.Parse(this.IdTxt.Text),
                    Name = this.nameTxt.Text,
                    Phone_number = this.phoneNumberTxt.Text,
                    Mail = this.mailTxt.Text,
                    Nip = this.nipTxt.Text,
                    Country = this.countryTxt.Text,
                    City = this.cityTxt.Text,
                    Postal_code = this.postalCodeTxt.Text,
                    Address_row1 = this.addressRow1Txt.Text,
                    Address_row2 = this.addressRow2Txt.Text
                };

                var logic = new CustomerParser();

                if (action)
                {
                    logic.AddCustomer(customer); // Dodawanie nowego klienta
                }
                else
                {
                    logic.EditCustomer(customer); 
                }

                this.DialogResult = DialogResult.OK; // Zamknięcie okna dialogowego
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid data for the customer fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CreateEditCustomer_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
