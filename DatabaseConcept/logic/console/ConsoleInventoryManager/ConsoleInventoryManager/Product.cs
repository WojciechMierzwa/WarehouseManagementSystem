using System;

namespace ConsoleInventoryManager
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sku { get; set; }
        public string Category { get; set; }
        public double NetPrice { get; set; }
        public double? Vat { get; set; }
        public int Stock { get; set; }
        public Vendor Vendor { get; set; }

        public Product(int id, string name, int sku, string category, double netPrice, double? vat, int stock, Vendor vendor)
        {
            Id = id;
            Name = name;
            Sku = sku;
            Category = category;
            NetPrice = netPrice;
            Vat = vat;
            Stock = stock;
            Vendor = vendor;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, SKU: {Sku}, Category: {Category}, Net Price: {NetPrice}, VAT: {Vat}, Stock: {Stock}, Vendor: {Vendor.Name}";
        }
    }
}
