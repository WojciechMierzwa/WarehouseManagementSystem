using System;
using System.Collections.Generic;

namespace ConsoleInventoryManagerV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Management System");
                Console.WriteLine("1. Employee Management");
                Console.WriteLine("2. Customer Management");
                Console.WriteLine("3. Vendor Management");
                Console.WriteLine("4. Product Management");
                Console.WriteLine("5. Order Management");
                Console.WriteLine("6. Invoice Management");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageEmployees(controller);
                        break;
                    case "2":
                        ManageCustomers(controller);
                        break;
                    case "3":
                        ManageVendors(controller);
                        break;
                    case "4":
                        ManageProducts(controller);
                        break;
                    case "5":
                        ManageOrders(controller);
                        break;
                    case "6":
                        ManageInvoices(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void ManageInvoices(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Invoice Management System");
                Console.WriteLine("1. Add Invoice");
                Console.WriteLine("2. Edit Invoice");
                Console.WriteLine("3. Delete Invoice");
                Console.WriteLine("4. Show All Invoices");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddInvoice(controller);
                        break;
                    case "2":
                        EditInvoice(controller);
                        break;
                    case "3":
                        DeleteInvoice(controller);
                        break;
                    case "4":
                        ShowAllInvoices(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void AddInvoice(Controller controller)
        {
            Console.Write("Enter Status: ");
            int status = int.Parse(Console.ReadLine());
            Console.Write("Enter Invoice Date (yyyy-mm-dd hh:mm:ss): ");
            DateTime invoiceDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Total Amount: ");
            double totalAmount = double.Parse(Console.ReadLine());
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());

            Invoice invoice = new Invoice(0, status, invoiceDate, totalAmount, orderId);
            controller.AddInvoice(invoice);
            Console.WriteLine($"\nInvoice added successfully!");
        }

        private static void EditInvoice(Controller controller)
        {
            Console.Write("Enter Invoice ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var invoices = controller.GetAllInvoices();
            var invoiceToEdit = invoices.Find(i => i.Id == id);

            if (invoiceToEdit != null)
            {
                Console.Write("Enter new Status (leave blank to keep current): ");
                string statusInput = Console.ReadLine();
                if (int.TryParse(statusInput, out int status)) invoiceToEdit.Status = status;

                Console.Write("Enter new Invoice Date (leave blank to keep current): ");
                string dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out DateTime invoiceDate)) invoiceToEdit.InvoiceDate = invoiceDate;

                Console.Write("Enter new Total Amount (leave blank to keep current): ");
                string totalAmountInput = Console.ReadLine();
                if (double.TryParse(totalAmountInput, out double totalAmount)) invoiceToEdit.TotalAmount = totalAmount;

                Console.Write("Enter new Order ID (leave blank to keep current): ");
                string orderIdInput = Console.ReadLine();
                if (int.TryParse(orderIdInput, out int orderId)) invoiceToEdit.OrderId = orderId;

                controller.UpdateInvoice(invoiceToEdit);
                Console.WriteLine($"\nInvoice updated successfully!");
            }
            else
            {
                Console.WriteLine("\nInvoice not found.");
            }
        }

        private static void DeleteInvoice(Controller controller)
        {
            Console.Write("Enter Invoice ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteInvoice(id);
            Console.WriteLine($"\nInvoice with ID {id} deleted successfully!");
        }

        private static void ShowAllInvoices(Controller controller)
        {
            var invoices = controller.GetAllInvoices();
            Console.WriteLine("\nList of Invoices:");
            foreach (var invoice in invoices)
            {
                Console.WriteLine($"ID: {invoice.Id}, Status: {invoice.Status}, Invoice Date: {invoice.InvoiceDate}, Total Amount: {invoice.TotalAmount}, Order ID: {invoice.OrderId}");
            }
        }

        private static void ManageOrders(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Order Management System");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Edit Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. Show All Orders");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddOrder(controller);
                        break;
                    case "2":
                        EditOrder(controller);
                        break;
                    case "3":
                        DeleteOrder(controller);
                        break;
                    case "4":
                        ShowAllOrders(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void AddOrder(Controller controller)
        {
            Console.Write("Enter Status: ");
            int status = int.Parse(Console.ReadLine());
            Console.Write("Enter Date (yyyy-mm-dd hh:mm:ss): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());

            Order order = new Order(0, status, date, customerId, employeeId);
            controller.AddOrder(order);
            Console.WriteLine($"\nOrder added successfully!");
        }

        private static void EditOrder(Controller controller)
        {
            Console.Write("Enter Order ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var orders = controller.GetAllOrders();
            var orderToEdit = orders.Find(o => o.Id == id);

            if (orderToEdit != null)
            {
                Console.Write("Enter new Status (leave blank to keep current): ");
                string statusInput = Console.ReadLine();
                if (int.TryParse(statusInput, out int status)) orderToEdit.Status = status;

                Console.Write("Enter new Date (leave blank to keep current): ");
                string dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out DateTime date)) orderToEdit.Date = date;

                Console.Write("Enter new Customer ID (leave blank to keep current): ");
                string customerIdInput = Console.ReadLine();
                if (int.TryParse(customerIdInput, out int customerId)) orderToEdit.CustomerId = customerId;

                Console.Write("Enter new Employee ID (leave blank to keep current): ");
                string employeeIdInput = Console.ReadLine();
                if (int.TryParse(employeeIdInput, out int employeeId)) orderToEdit.EmployeeId = employeeId;

                controller.UpdateOrder(orderToEdit);
                Console.WriteLine($"\nOrder updated successfully!");
            }
            else
            {
                Console.WriteLine("\nOrder not found.");
            }
        }

        private static void DeleteOrder(Controller controller)
        {
            Console.Write("Enter Order ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteOrder(id);
            Console.WriteLine($"\nOrder with ID {id} deleted successfully!");
        }

        private static void ShowAllOrders(Controller controller)
        {
            var orders = controller.GetAllOrders();
            Console.WriteLine("\nList of Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id}, Status: {order.Status}, Date: {order.Date}, Customer ID: {order.CustomerId}, Employee ID: {order.EmployeeId}");
            }
        }

        private static void ManageProducts(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Product Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Edit Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Show All Products");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(controller);
                        break;
                    case "2":
                        EditProduct(controller);
                        break;
                    case "3":
                        DeleteProduct(controller);
                        break;
                    case "4":
                        ShowAllProducts(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void AddProduct(Controller controller)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter SKU: ");
            int sku = int.Parse(Console.ReadLine());
            Console.Write("Enter Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Net Price: ");
            double netPrice = double.Parse(Console.ReadLine());
            Console.Write("Enter VAT: ");
            double vat = double.Parse(Console.ReadLine());
            Console.Write("Enter Stock: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Enter Vendor ID: ");
            int vendorId = int.Parse(Console.ReadLine());

            Product product = new Product(0, name, sku, category, netPrice, vat, stock, vendorId);
            controller.AddProduct(product);
            Console.WriteLine($"\nProduct {name} added successfully!");
        }

        private static void EditProduct(Controller controller)
        {
            Console.Write("Enter Product ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var products = controller.GetAllProducts();
            var productToEdit = products.Find(p => p.Id == id);

            if (productToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) productToEdit.Name = name;

                Console.Write("Enter new SKU (leave blank to keep current): ");
                string skuInput = Console.ReadLine();
                if (int.TryParse(skuInput, out int sku)) productToEdit.Sku = sku;

                Console.Write("Enter new Category (leave blank to keep current): ");
                string category = Console.ReadLine();
                if (!string.IsNullOrEmpty(category)) productToEdit.Category = category;

                Console.Write("Enter new Net Price (leave blank to keep current): ");
                string netPriceInput = Console.ReadLine();
                if (double.TryParse(netPriceInput, out double netPrice)) productToEdit.NetPrice = netPrice;

                Console.Write("Enter new VAT (leave blank to keep current): ");
                string vatInput = Console.ReadLine();
                if (double.TryParse(vatInput, out double vat)) productToEdit.Vat = vat;

                Console.Write("Enter new Stock (leave blank to keep current): ");
                string stockInput = Console.ReadLine();
                if (int.TryParse(stockInput, out int stock)) productToEdit.Stock = stock;

                Console.Write("Enter new Vendor ID (leave blank to keep current): ");
                string vendorIdInput = Console.ReadLine();
                if (int.TryParse(vendorIdInput, out int vendorId)) productToEdit.VendorId = vendorId;

                controller.UpdateProduct(productToEdit);
                Console.WriteLine($"\nProduct {productToEdit.Name} updated successfully!");
            }
            else
            {
                Console.WriteLine("\nProduct not found.");
            }
        }

        private static void DeleteProduct(Controller controller)
        {
            Console.Write("Enter Product ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteProduct(id);
            Console.WriteLine($"\nProduct with ID {id} deleted successfully!");
        }

        private static void ShowAllProducts(Controller controller)
        {
            var products = controller.GetAllProducts();
            Console.WriteLine("\nList of Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, SKU: {product.Sku}, Category: {product.Category}, Net Price: {product.NetPrice}, VAT: {product.Vat}, Stock: {product.Stock}, Vendor ID: {product.VendorId}");
            }
        }

        private static void ManageVendors(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Vendor Management System");
                Console.WriteLine("1. Add Vendor");
                Console.WriteLine("2. Edit Vendor");
                Console.WriteLine("3. Delete Vendor");
                Console.WriteLine("4. Show All Vendors");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddVendor(controller);
                        break;
                    case "2":
                        EditVendor(controller);
                        break;
                    case "3":
                        DeleteVendor(controller);
                        break;
                    case "4":
                        ShowAllVendors(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void AddVendor(Controller controller)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number (optional): ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Mail (optional): ");
            string mail = Console.ReadLine();
            Console.Write("Enter NIP (optional): ");
            string nip = Console.ReadLine();

            Vendor vendor = new Vendor(0, name, phoneNumber, mail, nip);
            controller.AddVendor(vendor);
            Console.WriteLine($"\nVendor {name} added successfully!");
        }

        private static void EditVendor(Controller controller)
        {
            Console.Write("Enter Vendor ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var vendors = controller.GetAllVendors();
            var vendorToEdit = vendors.Find(v => v.Id == id);

            if (vendorToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) vendorToEdit.Name = name;

                Console.Write("Enter new Phone Number (leave blank to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) vendorToEdit.PhoneNumber = phoneNumber;

                Console.Write("Enter new Mail (leave blank to keep current): ");
                string mail = Console.ReadLine();
                if (!string.IsNullOrEmpty(mail)) vendorToEdit.Mail = mail;

                Console.Write("Enter new NIP (leave blank to keep current): ");
                string nip = Console.ReadLine();
                if (!string.IsNullOrEmpty(nip)) vendorToEdit.Nip = nip;

                controller.UpdateVendor(vendorToEdit);
                Console.WriteLine($"\nVendor {vendorToEdit.Name} updated successfully!");
            }
            else
            {
                Console.WriteLine("\nVendor not found.");
            }
        }

        private static void DeleteVendor(Controller controller)
        {
            Console.Write("Enter Vendor ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteVendor(id);
            Console.WriteLine($"\nVendor with ID {id} deleted successfully!");
        }

        private static void ShowAllVendors(Controller controller)
        {
            var vendors = controller.GetAllVendors();
            Console.WriteLine("\nList of Vendors:");
            foreach (var vendor in vendors)
            {
                Console.WriteLine($"ID: {vendor.Id}, Name: {vendor.Name}, Phone: {vendor.PhoneNumber}, Mail: {vendor.Mail}, NIP: {vendor.Nip}");
            }
        }

        private static void ManageEmployees(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Edit Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Show All Employees");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(controller);
                        break;
                    case "2":
                        EditEmployee(controller);
                        break;
                    case "3":
                        DeleteEmployee(controller);
                        break;
                    case "4":
                        ShowAllEmployees(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void ManageCustomers(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Customer Management System");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Edit Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Show All Customers");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer(controller);
                        break;
                    case "2":
                        EditCustomer(controller);
                        break;
                    case "3":
                        DeleteCustomer(controller);
                        break;
                    case "4":
                        ShowAllCustomers(controller);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void AddEmployee(Controller controller)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter PESEL: ");
            string pesel = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Login: ");
            string login = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // Setting a default account type, modify as needed
            char accountType = 'C'; // Default or ask user for input

            Employee employee = new Employee(0, name, surname, pesel, phoneNumber, login, password, accountType);
            controller.AddEmployee(employee);
            Console.WriteLine($"\nEmployee {name} {surname} added successfully!");
        }

        private static void EditEmployee(Controller controller)
        {
            Console.Write("Enter Employee ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var employees = controller.GetAllEmployees();
            var employeeToEdit = employees.Find(e => e.Id == id);

            if (employeeToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) employeeToEdit.Name = name;

                Console.Write("Enter new Surname (leave blank to keep current): ");
                string surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname)) employeeToEdit.Surname = surname;

                Console.Write("Enter new PESEL (leave blank to keep current): ");
                string pesel = Console.ReadLine();
                if (!string.IsNullOrEmpty(pesel)) employeeToEdit.Pesel = pesel;

                Console.Write("Enter new Phone Number (leave blank to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) employeeToEdit.PhoneNumber = phoneNumber;

                Console.Write("Enter new Login (leave blank to keep current): ");
                string login = Console.ReadLine();
                if (!string.IsNullOrEmpty(login)) employeeToEdit.Login = login;

                Console.Write("Enter new Password (leave blank to keep current): ");
                string password = Console.ReadLine();
                if (!string.IsNullOrEmpty(password)) employeeToEdit.Password = password;

                controller.UpdateEmployee(employeeToEdit);
                Console.WriteLine($"\nEmployee {employeeToEdit.Name} {employeeToEdit.Surname} updated successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found.");
            }
        }

        private static void DeleteEmployee(Controller controller)
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteEmployee(id);
            Console.WriteLine($"\nEmployee with ID {id} deleted successfully!");
        }

        private static void ShowAllEmployees(Controller controller)
        {
            var employees = controller.GetAllEmployees();
            Console.WriteLine("\nList of Employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name} {employee.Surname}, PESEL: {employee.Pesel}, Phone: {employee.PhoneNumber}, Login: {employee.Login}");
            }
        }

        // Methods for customer management
        private static void AddCustomer(Controller controller)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Mail: ");
            string mail = Console.ReadLine();
            Console.Write("Enter NIP (optional): ");
            string nip = Console.ReadLine();
            Console.Write("Enter Country: ");
            string country = Console.ReadLine();
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            Console.Write("Enter Postal Code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter Address Row 1: ");
            string addressRow1 = Console.ReadLine();
            Console.Write("Enter Address Row 2 (optional): ");
            string addressRow2 = Console.ReadLine();

            Customer customer = new Customer(0, name, phoneNumber, mail, nip, country, city, postalCode, addressRow1, addressRow2);
            controller.AddCustomer(customer);
            Console.WriteLine($"\nCustomer {name} added successfully!");
        }

        private static void EditCustomer(Controller controller)
        {
            Console.Write("Enter Customer ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var customers = controller.GetAllCustomers();
            var customerToEdit = customers.Find(c => c.Id == id);

            if (customerToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) customerToEdit.Name = name;

                Console.Write("Enter new Phone Number (leave blank to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) customerToEdit.PhoneNumber = phoneNumber;

                Console.Write("Enter new Mail (leave blank to keep current): ");
                string mail = Console.ReadLine();
                if (!string.IsNullOrEmpty(mail)) customerToEdit.Mail = mail;

                Console.Write("Enter new NIP (leave blank to keep current): ");
                string nip = Console.ReadLine();
                if (!string.IsNullOrEmpty(nip)) customerToEdit.Nip = nip;

                Console.Write("Enter new Country (leave blank to keep current): ");
                string country = Console.ReadLine();
                if (!string.IsNullOrEmpty(country)) customerToEdit.Country = country;

                Console.Write("Enter new City (leave blank to keep current): ");
                string city = Console.ReadLine();
                if (!string.IsNullOrEmpty(city)) customerToEdit.City = city;

                Console.Write("Enter new Postal Code (leave blank to keep current): ");
                string postalCode = Console.ReadLine();
                if (!string.IsNullOrEmpty(postalCode)) customerToEdit.PostalCode = postalCode;

                Console.Write("Enter new Address Row 1 (leave blank to keep current): ");
                string addressRow1 = Console.ReadLine();
                if (!string.IsNullOrEmpty(addressRow1)) customerToEdit.AddressRow1 = addressRow1;

                Console.Write("Enter new Address Row 2 (leave blank to keep current): ");
                string addressRow2 = Console.ReadLine();
                if (!string.IsNullOrEmpty(addressRow2)) customerToEdit.AddressRow2 = addressRow2;

                controller.UpdateCustomer(customerToEdit);
                Console.WriteLine($"\nCustomer {customerToEdit.Name} updated successfully!");
            }
            else
            {
                Console.WriteLine("\nCustomer not found.");
            }
        }

        private static void DeleteCustomer(Controller controller)
        {
            Console.Write("Enter Customer ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteCustomer(id);
            Console.WriteLine($"\nCustomer with ID {id} deleted successfully!");
        }

        private static void ShowAllCustomers(Controller controller)
        {
            var customers = controller.GetAllCustomers();
            Console.WriteLine("\nList of Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.PhoneNumber}, Mail: {customer.Mail}");
            }
        }
    }
}
