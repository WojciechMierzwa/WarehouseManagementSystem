using System;

namespace ConsoleInventoryManager
{
    public class Invoice
    {
        public int Id { get; set; }               // Automatically incrementing ID
        public int Status { get; set; }           // Status of the invoice (e.g., unpaid, paid)
        public DateTime InvoiceDate { get; set; } // Date when the invoice was created
        public decimal TotalAmount { get; set; }  // Total amount of the invoice

        public Invoice(int id, int status, DateTime invoiceDate, decimal totalAmount)
        {
            Id = id;
            Status = status;
            InvoiceDate = invoiceDate;
            TotalAmount = totalAmount;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Status: {Status}, Invoice Date: {InvoiceDate}, Total Amount: {TotalAmount:C}";
        }
    }
}
