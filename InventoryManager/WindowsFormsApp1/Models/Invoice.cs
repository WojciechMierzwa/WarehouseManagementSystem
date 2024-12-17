using System;

namespace WindowsFormsApp1.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceFilePath { get; set; }

    }
}
