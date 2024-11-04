namespace ConsoleInventoryManagerV2
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sku { get; set; }
        public string Category { get; set; }
        public double NetPrice { get; set; }
        public double Vat { get; set; }
        public int Stock { get; set; }
        public int VendorId { get; set; }

        public Product(int id, string name, int sku, string category, double netPrice, double vat, int stock, int vendorId)
        {
            Id = id;
            Name = name;
            Sku = sku;
            Category = category;
            NetPrice = netPrice;
            Vat = vat;
            Stock = stock;
            VendorId = vendorId;
        }
    }
}
