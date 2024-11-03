using System;
using System.Data.SQLite;
using System.IO;

namespace ConsoleInventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=inventory2.db;Version=3;";

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
                    Console.WriteLine("\nChoose an entity to manage:");
                    Console.WriteLine("1. Vendor");
                    Console.WriteLine("2. Customer");
                    Console.WriteLine("3. Employee");
                    Console.WriteLine("4. Address");
                    Console.WriteLine("5. Product");
                    Console.WriteLine("6. Order");
                    Console.WriteLine("7. Invoice");
                    Console.WriteLine("8. Product List");
                    Console.WriteLine("9. Exit");

                    string entityChoice = Console.ReadLine();
                    switch (entityChoice)
                    {
                        case "1":
                            ManageVendor(connection);
                            break;
                        case "2":
                            ManageCustomer(connection);
                            break;
                        case "3":
                            ManageEmployee(connection);
                            break;
                        case "4":
                            ManageAddress(connection);
                            break;
                        case "5":
                            ManageProduct(connection);
                            break;
                        case "6":
                            ManageOrder(connection);
                            break;
                        case "7":
                            ManageInvoice(connection);
                            break;
                        case "8":
                            ManageProductList(connection);
                            break;
                        case "9":
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

        // Entity management methods

        static void ManageVendor(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Vendor Management ---");
            Console.WriteLine("1. Add Vendor");
            Console.WriteLine("2. Edit Vendor");
            Console.WriteLine("3. Display Vendors");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddVendor(connection);
                    break;
                case "2":
                    EditVendor(connection);
                    break;
                case "3":
                    DisplayVendors(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageCustomer(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Customer Management ---");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Edit Customer");
            Console.WriteLine("3. Display Customers");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddCustomer(connection);
                    break;
                case "2":
                    EditCustomer(connection);
                    break;
                case "3":
                    DisplayCustomers(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageEmployee(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Employee Management ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Edit Employee");
            Console.WriteLine("3. Display Employees");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddEmployee(connection);
                    break;
                case "2":
                    EditEmployee(connection);
                    break;
                case "3":
                    DisplayEmployees(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageAddress(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Address Management ---");
            Console.WriteLine("1. Add Address");
            Console.WriteLine("2. Edit Address");
            Console.WriteLine("3. Display Addresses");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddAddress(connection);
                    break;
                case "2":
                    EditAddress(connection);
                    break;
                case "3":
                    DisplayAddresses(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageProduct(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Product Management ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Display Products");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddProduct(connection);
                    break;
                case "2":
                    EditProduct(connection);
                    break;
                case "3":
                    DisplayProducts(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageOrder(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Order Management ---");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Edit Order");
            Console.WriteLine("3. Display Orders");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddOrder(connection);
                    break;
                case "2":
                    EditOrder(connection);
                    break;
                case "3":
                    DisplayOrders(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageInvoice(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Invoice Management ---");
            Console.WriteLine("1. Add Invoice");
            Console.WriteLine("2. Edit Invoice");
            Console.WriteLine("3. Display Invoices");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddInvoice(connection);
                    break;
                case "2":
                    EditInvoice(connection);
                    break;
                case "3":
                    DisplayInvoices(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ManageProductList(SQLiteConnection connection)
        {
            Console.WriteLine("\n--- Product List Management ---");
            Console.WriteLine("1. Add Product List Entry");
            Console.WriteLine("2. Edit Product List Entry");
            Console.WriteLine("3. Display Product List");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    AddProductListEntry(connection);
                    break;
                case "2":
                    EditProductListEntry(connection);
                    break;
                case "3":
                    DisplayProductList(connection);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        // Add methods for each entity go here, like AddVendor, AddCustomer, etc.
        // Similarly, Edit and Display methods for each entity.

        // For example:

        static void AddVendor(SQLiteConnection connection)
        {
            Console.WriteLine("Adding a new vendor...");
            // Collect input and execute insertion query
        }

        static void EditVendor(SQLiteConnection connection)
        {
            Console.WriteLine("Editing a vendor...");
            // Collect input and execute update query
        }

        static void DisplayVendors(SQLiteConnection connection)
        {
            Console.WriteLine("Displaying all vendors...");
            // Execute select query and display results
        }
    }
}
