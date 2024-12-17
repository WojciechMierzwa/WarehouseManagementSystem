using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ProductManager());
            //Application.Run(new CustomerManager());
            Application.Run(new LoginForm());
            //Application.Run(new CreateInvoice());
            //Application.Run(new RecordManager(3));
        }
    }
}
