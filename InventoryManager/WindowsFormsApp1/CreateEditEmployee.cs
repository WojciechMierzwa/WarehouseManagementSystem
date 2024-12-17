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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class CreateEditEmployee : Form
    {
        public CreateEditEmployee()
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.IdTxt.Enabled = false;
            this.IdTxt.Text = string.Empty;
        }
        private Boolean action = true;

        public void EditEmployee(Employee employee)
        {
            action = false;
            this.IdTxt.Text = employee.Id.ToString();
            this.Text = "Edit employee";
            this.lb.Text = "Edit employee";
            this.IdTxt.Text = "" + employee.Id;
            this.nameTxt.Text = "" + employee.Name;
            this.surnameTxt.Text = "" + employee.Surname;
            this.loginTxt.Text = "" + employee.Login;
            this.passwordTxt.Text = "" + employee.Password;



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee
                {
                    Id = action ? 0 : int.Parse(this.IdTxt.Text),
                    Name = this.nameTxt.Text,
                    Surname = this.surnameTxt.Text,
                    Login = this.loginTxt.Text,
                    Password = this.passwordTxt.Text,

                };

                var logic = new EmployeeParser();

                if (action)
                {
                    logic.AddEmployee(employee);
                }
                else
                {
                    logic.EditEmployee(employee);
                    
                }

                this.DialogResult = DialogResult.OK; 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid data for the employee fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
