using System;
using System.Collections.Generic;

namespace ConsoleInventoryManagerV2
{
    internal class InvoiceData
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddressRow1 { get; set; }
        public string CustomerAddressRow2 { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }

        public string CustomerNip { get; set; }
        public List<ProductData> Products { get; set; } = new List<ProductData>();
        public decimal TotalAmount => CalculateTotalAmount();

        private decimal CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.TotalPrice + product.TotalPrice * product.VatRate/100;
            }
            return total;
        }
    }

    internal class ProductData
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatRate { get; set; }
    }
}
