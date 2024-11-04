namespace ConsoleInventoryManagerV2
{
    internal class Invoice
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalAmount { get; set; }
        public int OrderId { get; set; }

        public Invoice(int id, int status, DateTime invoiceDate, double totalAmount, int orderId)
        {
            Id = id;
            Status = status;
            InvoiceDate = invoiceDate;
            TotalAmount = totalAmount;
            OrderId = orderId;
        }
    }
}
