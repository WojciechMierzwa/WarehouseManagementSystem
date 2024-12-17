using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DatabaseForm : Form
    {
        public DatabaseForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            loadDataFromFile(); // Call to load data after initializing components
        }

        private void loadDataFromFile()
        {
            string file = "connectionString.txt";
            string defaultData = "Your Connection String";

            try
            {
                if (!File.Exists(file))
                {
       
                    File.WriteAllText(file, defaultData);

                    MessageBox.Show("The file was not found and has been created with default values.",
                                    "File Created",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

   
                string connectionString = File.ReadAllText(file).Trim();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    MessageBox.Show("The connection string is empty or invalid. Please check the file.",
                                    "Invalid Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

  
                connectionStringTxt.Text = connectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing the file: {ex.Message}",
                                "File Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string file = "connectionString.txt";

            try
            {

                string connectionString = connectionStringTxt.Text;

    
                File.WriteAllText(file, connectionString);

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
    }
}
