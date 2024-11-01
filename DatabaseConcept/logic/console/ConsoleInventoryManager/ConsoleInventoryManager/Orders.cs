using System;

namespace ConsoleInventoryManager
{
    public class Order
    {
        public int Id { get; set; }                // Automatically incrementing ID
        public int Status { get; set; }            // Status of the order (e.g., pending, completed)
        public DateTime Date { get; set; }         // The date when the order was created
        public int CustomerId { get; set; }        // ID of the customer who placed the order
        public int InvoiceId { get; set; }         // ID of the associated invoice

        public Order(int id, int status, DateTime date, int customerId, int invoiceId)
        {
            Id = id;
            Status = status;
            Date = date;
            CustomerId = customerId;
            InvoiceId = invoiceId;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Status: {Status}, Date: {Date}, Customer ID: {CustomerId}, Invoice ID: {InvoiceId}";
        }
    }
}
