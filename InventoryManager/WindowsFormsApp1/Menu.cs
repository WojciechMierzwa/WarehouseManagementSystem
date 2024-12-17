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
    public partial class Menu : Form
    {
        public Employee employee {  get; set; }
        public Menu(Employee employee)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.employee = employee;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordManager form = new RecordManager(5);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecordManager form = new RecordManager(4);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordManager form = new RecordManager(2);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RecordManager form = new RecordManager(1);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            CreateEditEmployee form = new CreateEditEmployee();
            form.EditEmployee(this.employee);
           
            if (form.ShowDialog() == DialogResult.OK)
            {
               ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
