using System;
using System.Data.SQLite;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=inventory2.db;Version=3;";

        // Execute the SQL commands from the schema file
        try
        {
            ExecuteSqlFile("dblite.sql", connectionString);
            Console.WriteLine("Database schema loaded from file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading database schema: {ex.Message}");
            return;
        }

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Database loaded successfully!");
            Console.WriteLine("Welcome to Inventory Manager 0.1");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. Read from database");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddProduct(connection);
                        break;
                    case "2":
                        ReadDatabase(connection);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }

            connection.Close();
        }
    }

    static void ExecuteSqlFile(string filePath, string connectionString)
    {
        string sql = File.ReadAllText(filePath);

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    static void AddProduct(SQLiteConnection connection)
    {
        try
        {
            Console.WriteLine("Before we add a product, we need vendor information.");
            Console.WriteLine("Please insert vendor data:");

            // Collect vendor information
            Console.Write("Vendor Name: ");
            string vendorName = Console.ReadLine();

            Console.Write("Phone Number (optional): ");
            string vendorPhoneNumber = Console.ReadLine();
            vendorPhoneNumber = string.IsNullOrEmpty(vendorPhoneNumber) ? null : vendorPhoneNumber;

            Console.Write("Email (optional): ");
            string vendorMail = Console.ReadLine();
            vendorMail = string.IsNullOrEmpty(vendorMail) ? null : vendorMail;

            Console.Write("NIP (optional): ");
            string vendorNip = Console.ReadLine();
            vendorNip = string.IsNullOrEmpty(vendorNip) ? null : vendorNip;

            // Insert Vendor into the database
            int vendorId = InsertVendor(connection, vendorName, vendorPhoneNumber, vendorMail, vendorNip);
            Vendor newVendor = new Vendor(vendorId, vendorName, vendorPhoneNumber, vendorMail, vendorNip);

            Console.WriteLine("\nVendor added successfully:");
            Console.WriteLine(newVendor);

            Console.WriteLine("\nPlease insert product data:");

            // Collect product information
            Console.Write("Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("SKU: ");
            int sku = int.Parse(Console.ReadLine());

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Net Price: ");
            double netPrice = double.Parse(Console.ReadLine());

            Console.Write("VAT (optional): ");
            string vatInput = Console.ReadLine();
            double? vat = string.IsNullOrEmpty(vatInput) ? null : double.Parse(vatInput);

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            // Insert Product into the database
            int productId = InsertProduct(connection, productName, sku, category, netPrice, vat, stock, newVendor);
            Product newProduct = new Product(productId, productName, sku, category, netPrice, vat, stock, newVendor);

            Console.WriteLine("\nProduct added successfully:");
            Console.WriteLine(newProduct);

            // Confirm data has been saved by querying back
            DisplayProducts(connection);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while adding product: {ex.Message}");
        }
    }

    static int InsertVendor(SQLiteConnection connection, string name, string? phoneNumber, string? mail, string? nip)
    {
        string query = "INSERT INTO Vendor (name, phone_number, mail, nip) VALUES (@name, @phone_number, @mail, @nip); SELECT last_insert_rowid();";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone_number", (object)phoneNumber ?? DBNull.Value);
            command.Parameters.AddWithValue("@mail", (object)mail ?? DBNull.Value);
            command.Parameters.AddWithValue("@nip", (object)nip ?? DBNull.Value);

            int vendorId = Convert.ToInt32(command.ExecuteScalar());
            return vendorId;
        }
    }

    static int InsertProduct(SQLiteConnection connection, string name, int sku, string category, double netPrice, double? vat, int stock, Vendor vendor)
    {
        string query = "INSERT INTO Product (name, sku, category, net_price, vat, stock, Vendor_id) VALUES (@name, @sku, @category, @net_price, @vat, @stock, @vendorId); SELECT last_insert_rowid();";

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@sku", sku);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@net_price", netPrice);
            command.Parameters.AddWithValue("@vat", (object)vat ?? DBNull.Value);
            command.Parameters.AddWithValue("@stock", stock);
            command.Parameters.AddWithValue("@vendorId", vendor.Id);

            int productId = Convert.ToInt32(command.ExecuteScalar());
            return productId;
        }
    }

    static void DisplayProducts(SQLiteConnection connection)
    {
        string query = "SELECT * FROM Product;"; // Query to retrieve all products

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("\nCurrent Products in Database:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["name"]}, SKU: {reader["sku"]}, Category: {reader["category"]}, Net Price: {reader["net_price"]}, VAT: {reader["vat"]}, Stock: {reader["stock"]}");
                }
            }
        }
    }

    static void ReadDatabase(SQLiteConnection connection)
    {
        Console.WriteLine("\n--- Vendors in Database ---");
        DisplayVendors(connection);

        Console.WriteLine("\n--- Products in Database ---");
        DisplayProducts(connection);
    }

    static void DisplayVendors(SQLiteConnection connection)
    {
        string query = "SELECT * FROM Vendor;"; // Query to retrieve all vendors

        using (SQLiteCommand command = new SQLiteCommand(query, connection))
        {
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("\nCurrent Vendors in Database:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["name"]}, Phone: {reader["phone_number"]}, Email: {reader["mail"]}, NIP: {reader["nip"]}");
                }
            }
        }
    }
}

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SKU { get; set; }
    public string Category { get; set; }
    public double NetPrice { get; set; }
    public double? Vat { get; set; }
    public int Stock { get; set; }
    public Vendor Vendor { get; set; }

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

internal class Vendor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Mail { get; set; }
    public string? Nip { get; set; }

    public Vendor(int id, string name, string? phoneNumber, string? mail, string? nip)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Mail = mail;
        Nip = nip;
    }

    public override string ToString()
    {
        return $"Vendor ID: {Id}\nName: {Name}\nPhone: {PhoneNumber}\nEmail: {Mail}\nNIP: {Nip}";
    }
}
