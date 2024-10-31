internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SKU { get; set; }
    public string Category { get; set; }
    public double NetPrice { get; set; }
    public double? Vat { get; set; }
    public int Stock { get; set; }

    public Vendor Vendor { get; set; }  // Navigation property for Vendor

    public Product(int id, string name, int sku, string category, double netPrice, double? vat, int stock, Vendor vendor)
    {
        Id = id;
        Name = name;
        SKU = sku;
        Category = category;
        NetPrice = netPrice;
        Vat = vat;
        Stock = stock;
        Vendor = vendor;
    }

    public override string ToString()
    {
        return $"Product ID: {Id}\nName: {Name}\nSKU: {SKU}\nCategory: {Category}\nNet Price: {NetPrice}\nVAT: {Vat}\nStock: {Stock}\nVendor: {Vendor.Name}";
    }
}