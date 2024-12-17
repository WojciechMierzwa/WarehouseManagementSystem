using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CompanyInfoForm : Form
    {
        public CompanyInfoForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            loadDataFromFile();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadDataFromFile()
        {
            string file = "companyInfo.txt";

            try
            {
              
                if (!System.IO.File.Exists(file))
                {
                    
                    string[] defaultData = new string[]
                    {
                "Your Company Name",   
                "0000000000",          
                "Country",             
                "City",               
                "000-000",             
                "Street Address Line 1",
                "Street Address Line 2" 
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
                    return;
                }

             
                nameTxt.Text = lines[0];       // Company Name
                nipTxt.Text = lines[1];        // NIP
                countryTxt.Text = lines[2];    // Country
                cityTxt.Text = lines[3];       // City
                postalCodeTxt.Text = lines[4]; // Postal Code
                addressRow1Txt.Text = lines[5]; // Address Row 1
                addressRow2Txt.Text = lines[6]; // Address Row 2
            }
            catch (Exception ex)
            {
       
                MessageBox.Show($"Error processing the file: {ex.Message}",
                                "File Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = "companyInfo.txt";

            try
            {
     
                string[] lines = new string[]
                {
            nameTxt.Text,       // Company Name
            nipTxt.Text,        // NIP
            countryTxt.Text,    // Country
            cityTxt.Text,       // City
            postalCodeTxt.Text, // Postal Code
            addressRow1Txt.Text, // Address Row 1
            addressRow2Txt.Text  // Address Row 2
                };

                // Overwrite the file with the new data
                System.IO.File.WriteAllLines(file, lines);

        
                MessageBox.Show("Company information has been successfully saved.",
                                "Save Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
  
                MessageBox.Show($"Error saving the file: {ex.Message}",
                                "Save Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
