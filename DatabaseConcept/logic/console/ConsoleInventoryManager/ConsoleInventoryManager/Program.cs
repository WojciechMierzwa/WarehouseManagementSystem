using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Inventory Manager 0.1\nChoose an action");
        Console.WriteLine("Do you want to add a product? y/n");

        string input = Console.ReadLine();
        char answer = input.Length > 0 ? input[0] : 'n';

        if (answer == 'y')
        {
            Console.WriteLine("Before we add a product, we need vendor information.");
            Console.WriteLine("Please insert vendor data:");

            Console.Write("Vendor Name: ");
            string vendorName = Console.ReadLine();

            Console.Write("Phone Number (optional): ");
            string? vendorPhoneNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(vendorPhoneNumber)) vendorPhoneNumber = null;

            Console.Write("Email (optional): ");
            string? vendorMail = Console.ReadLine();
            if (string.IsNullOrEmpty(vendorMail)) vendorMail = null;

            Console.Write("NIP (optional): ");
            string? vendorNip = Console.ReadLine();
            if (string.IsNullOrEmpty(vendorNip)) vendorNip = null;

            int newVendorId = 1; 

            Vendor newVendor = new Vendor(newVendorId, vendorName, vendorPhoneNumber, vendorMail, vendorNip);

            Console.WriteLine("\nVendor added successfully:");
            Console.WriteLine(newVendor);

            Console.WriteLine("\nPlease insert product data:");

            Console.Write("Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("SKU: ");
            int sku = int.Parse(Console.ReadLine());

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Net Price: ");
            double netPrice = double.Parse(Console.ReadLine());

            Console.Write("VAT (optional): ");
            string? vatInput = Console.ReadLine();
            double? vat = string.IsNullOrEmpty(vatInput) ? (double?)null : double.Parse(vatInput);

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            int newProductId = 1;  

            Product newProduct = new Product(newProductId, productName, sku, category, netPrice, vat, stock, newVendor);

            Console.WriteLine("\nProduct added successfully:");
            Console.WriteLine(newProduct);
        }
        else
        {
            Console.WriteLine("No product added. Exiting program.");
        }
    }
}