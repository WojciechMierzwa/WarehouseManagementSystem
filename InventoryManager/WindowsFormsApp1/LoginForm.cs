using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Logic;
using WindowsFormsApp1.Models;


namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) 
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)  
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
         
            string userLogin = textBox1.Text;
            string userPassword = textBox2.Text;

          
            EmployeeParser employeeParser = new EmployeeParser();

            Employee loggedInEmployee = employeeParser.GetEmployeeByLoginAndPassword(userLogin, userPassword);

            if (loggedInEmployee != null)
            {
                MessageBox.Show("Login successful!");

                if (loggedInEmployee.Name == "admin")
                {
                    this.Hide();
                    MenuAdmin menu = new MenuAdmin();
                    menu.Show();
                }
                else
                {
                    this.Hide();
                    Menu menu = new Menu(loggedInEmployee);
                    menu.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid login or password. Please try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseForm dbForm = new DatabaseForm();
            dbForm.Show();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
