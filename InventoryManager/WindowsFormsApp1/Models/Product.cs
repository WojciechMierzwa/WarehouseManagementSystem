using System;

namespace WindowsFormsApp1
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sku { get; set; }
        public string Category { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Vat { get; set; }
        public int Stock { get; set; }
        public string Vendor { get; set; }
    }
}
