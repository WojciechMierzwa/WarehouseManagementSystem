using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleInventoryManagerV2
{
    internal class Controller
    {
        private readonly string connectionString;

        public Controller()
        {
            // Set the connection string to connect to your SQLite database file
            Console.WriteLine(Directory.GetCurrentDirectory());
            connectionString = "Data Source=database.db;Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // Check if the database file exists
            if (!File.Exists("database.db"))
            {
                SQLiteConnection.CreateFile("database.db"); // Create the database file

                using (var connection = OpenConnection())
                {
                    // Load schema from the SQL file and create tables
                    LoadSchema(connection, "dblite.sql");
                }
            }
        }

        private void LoadSchema(SQLiteConnection connection, string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Schema file not found.", filePath);
            }

            string schema = File.ReadAllText(filePath);
            var commands = schema.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var command in commands)
            {
                ExecuteNonQuery(command.Trim(), connection);
            }
        }

        private void ExecuteNonQuery(string query, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Method to open a connection to the database
        private SQLiteConnection OpenConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }


        //sql employee logic

        public void AddEmployee(Employee employee)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
                    INSERT INTO Employee (name, surname, pesel, phone_number, login, password) 
                    VALUES (@name, @surname, @pesel, @phoneNumber, @login, @password);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@surname", employee.Surname);
                    command.Parameters.AddWithValue("@pesel", employee.Pesel);
                    command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@login", employee.Login);
                    command.Parameters.AddWithValue("@password", employee.Password);

                    command.ExecuteNonQuery();
                }
            }
        }

    
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM Employee;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee(
                            id: Convert.ToInt32(reader["id"]),
                            name: reader["name"].ToString(),
                            surname: reader["surname"].ToString(),
                            pesel: reader["pesel"].ToString(),
                            phoneNumber: reader["phone_number"].ToString(),
                            login: reader["login"].ToString(),
                            password: reader["password"].ToString(),
                            accountType: 'e'
                        );

                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
                    UPDATE Employee 
                    SET name = @name,
                        surname = @surname,
                        pesel = @pesel,
                        phone_number = @phoneNumber,
                        login = @login,
                        password = @password
                    WHERE id = @id;
                ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", employee.Id);
                    command.Parameters.AddWithValue("@name", employee.Name);
                    command.Parameters.AddWithValue("@surname", employee.Surname);
                    command.Parameters.AddWithValue("@pesel", employee.Pesel);
                    command.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@login", employee.Login);
                    command.Parameters.AddWithValue("@password", employee.Password);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM Employee WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //customer
        // Method to add a new customer
        public void AddCustomer(Customer customer)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
            INSERT INTO Customer (name, phone_number, mail, nip, country, city, postal_code, address_row1, address_row2) 
            VALUES (@name, @phoneNumber, @mail, @nip, @country, @city, @postalCode, @addressRow1, @addressRow2);
        ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@mail", customer.Mail);
                    command.Parameters.AddWithValue("@nip", customer.Nip);
                    command.Parameters.AddWithValue("@country", customer.Country);
                    command.Parameters.AddWithValue("@city", customer.City);
                    command.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    command.Parameters.AddWithValue("@addressRow1", customer.AddressRow1);
                    command.Parameters.AddWithValue("@addressRow2", customer.AddressRow2);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to retrieve all customers
        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM Customer;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customer = new Customer(
                            id: Convert.ToInt32(reader["id"]),
                            name: reader["name"].ToString(),
                            phoneNumber: reader["phone_number"].ToString(),
                            mail: reader["mail"].ToString(),
                            nip: reader["nip"]?.ToString(), // Optional
                            country: reader["country"].ToString(),
                            city: reader["city"].ToString(),
                            postalCode: reader["postal_code"].ToString(),
                            addressRow1: reader["address_row1"].ToString(),
                            addressRow2: reader["address_row2"].ToString()
                        );

                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }

        // Method to update an existing customer
        public void UpdateCustomer(Customer customer)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
            UPDATE Customer 
            SET name = @name,
                phone_number = @phoneNumber,
                mail = @mail,
                nip = @nip,
                country = @country,
                city = @city,
                postal_code = @postalCode,
                address_row1 = @addressRow1,
                address_row2 = @addressRow2
            WHERE id = @id;
        ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", customer.Id);
                    command.Parameters.AddWithValue("@name", customer.Name);
                    command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@mail", customer.Mail);
                    command.Parameters.AddWithValue("@nip", customer.Nip);
                    command.Parameters.AddWithValue("@country", customer.Country);
                    command.Parameters.AddWithValue("@city", customer.City);
                    command.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                    command.Parameters.AddWithValue("@addressRow1", customer.AddressRow1);
                    command.Parameters.AddWithValue("@addressRow2", customer.AddressRow2);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a customer
        public void DeleteCustomer(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM Customer WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //vendor

        public void AddVendor(Vendor vendor)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
                    INSERT INTO Vendor (name, phone_number, mail, nip) 
                    VALUES (@name, @phoneNumber, @mail, @nip);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", vendor.Name);
                    command.Parameters.AddWithValue("@phoneNumber", vendor.PhoneNumber);
                    command.Parameters.AddWithValue("@mail", vendor.Mail);
                    command.Parameters.AddWithValue("@nip", vendor.Nip);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Vendor> GetAllVendors()
        {
            var vendors = new List<Vendor>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM Vendor;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var vendor = new Vendor(
                            id: Convert.ToInt32(reader["id"]),
                            name: reader["name"].ToString(),
                            phoneNumber: reader["phone_number"]?.ToString(),
                            mail: reader["mail"]?.ToString(),
                            nip: reader["nip"]?.ToString()
                        );

                        vendors.Add(vendor);
                    }
                }
            }
            return vendors;
        }

        public void UpdateVendor(Vendor vendor)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
                    UPDATE Vendor 
                    SET name = @name,
                        phone_number = @phoneNumber,
                        mail = @mail,
                        nip = @nip
                    WHERE id = @id;
                ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", vendor.Id);
                    command.Parameters.AddWithValue("@name", vendor.Name);
                    command.Parameters.AddWithValue("@phoneNumber", vendor.PhoneNumber);
                    command.Parameters.AddWithValue("@mail", vendor.Mail);
                    command.Parameters.AddWithValue("@nip", vendor.Nip);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteVendor(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM Vendor WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddProduct(Product product)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
                    INSERT INTO Product (name, sku, category, net_price, vat, stock, Vendor_id) 
                    VALUES (@name, @sku, @category, @netPrice, @vat, @stock, @vendorId);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@sku", product.Sku);
                    command.Parameters.AddWithValue("@category", product.Category);
                    command.Parameters.AddWithValue("@netPrice", product.NetPrice);
                    command.Parameters.AddWithValue("@vat", product.Vat);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    command.Parameters.AddWithValue("@vendorId", product.VendorId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM Product;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product(
                            id: Convert.ToInt32(reader["id"]),
                            name: reader["name"].ToString(),
                            sku: Convert.ToInt32(reader["sku"]),
                            category: reader["category"].ToString(),
                            netPrice: Convert.ToDouble(reader["net_price"]),
                            vat: Convert.ToDouble(reader["vat"]),
                            stock: Convert.ToInt32(reader["stock"]),
                            vendorId: Convert.ToInt32(reader["Vendor_id"])
                        );

                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
                    UPDATE Product 
                    SET name = @name,
                        sku = @sku,
                        category = @category,
                        net_price = @netPrice,
                        vat = @vat,
                        stock = @stock,
                        Vendor_id = @vendorId
                    WHERE id = @id;
                ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", product.Id);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@sku", product.Sku);
                    command.Parameters.AddWithValue("@category", product.Category);
                    command.Parameters.AddWithValue("@netPrice", product.NetPrice);
                    command.Parameters.AddWithValue("@vat", product.Vat);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    command.Parameters.AddWithValue("@vendorId", product.VendorId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM Product WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddOrder(Order order)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
                    INSERT INTO 'Order' (status, date, Customer_id, Employee_id) 
                    VALUES (@status, @date, @customerId, @employeeId);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@status", order.Status);
                    command.Parameters.AddWithValue("@date", order.Date);
                    command.Parameters.AddWithValue("@customerId", order.CustomerId);
                    command.Parameters.AddWithValue("@employeeId", order.EmployeeId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM 'Order';";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order(
                            id: Convert.ToInt32(reader["id"]),
                            status: Convert.ToInt32(reader["status"]),
                            date: Convert.ToDateTime(reader["date"]),
                            customerId: Convert.ToInt32(reader["Customer_id"]),
                            employeeId: Convert.ToInt32(reader["Employee_id"])
                        );

                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
                    UPDATE 'Order' 
                    SET status = @status,
                        date = @date,
                        Customer_id = @customerId,
                        Employee_id = @employeeId
                    WHERE id = @id;
                ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", order.Id);
                    command.Parameters.AddWithValue("@status", order.Status);
                    command.Parameters.AddWithValue("@date", order.Date);
                    command.Parameters.AddWithValue("@customerId", order.CustomerId);
                    command.Parameters.AddWithValue("@employeeId", order.EmployeeId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM 'Order' WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //invoice

        public void CreateInvoice(int orderId)
        {
            using (var connection = OpenConnection())
            {
                // SQL script to create an invoice and update product stock
                string sqlQuery = @"
            -- 1. Calculate the total amount for the invoice
            WITH order_total AS (
                SELECT 
                    SUM(pl.total_price) AS total_amount
                FROM 
                    Product_list pl
                WHERE 
                    pl.Order_id = @Order_id
            )

            -- 2. Insert a new invoice record using the calculated total amount
            INSERT INTO Invoice (status, invoice_date, total_amount, Order_id)
            SELECT 
                1,                    -- Invoice status (e.g., 1 for 'issued')
                CURRENT_TIMESTAMP,    -- Invoice date
                total_amount,         -- Total amount calculated
                @Order_id             -- Order ID
            FROM 
                order_total;

            -- 3. Update product stock for each product in the order
            UPDATE Product
            SET stock = stock - (
                    SELECT quantity 
                    FROM Product_list 
                    WHERE Product_list.Product_id = Product.id
                      AND Product_list.Order_id = @Order_id
                )
            WHERE id IN (
                    SELECT Product_id 
                    FROM Product_list 
                    WHERE Order_id = @Order_id
                );
        ";

                using (var command = new SQLiteCommand(sqlQuery, connection))
                {
                    // Add the parameter for the Order ID
                    command.Parameters.AddWithValue("@Order_id", orderId);

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GenerateInvoiceDataFile(int orderId)
        {
            using (var connection = OpenConnection())
            {
                // SQL query to retrieve order details and associated products
                string sqlQuery = @"
            SELECT 
                o.id AS OrderID,
                c.name AS CustomerName,
                c.mail AS CustomerEmail,
                c.phone_number AS CustomerPhone,
                p.name AS ProductName,
                pl.quantity AS ProductQuantity,
                pl.unit_price AS UnitPrice,
                pl.total_price AS TotalPrice
            FROM 
                [Order] o
            JOIN 
                Customer c ON o.Customer_id = c.id
            JOIN 
                Product_list pl ON o.id = pl.Order_id
            JOIN 
                Product p ON pl.Product_id = p.id
            WHERE 
                o.id = @Order_id;
        ";

                using (var command = new SQLiteCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Order_id", orderId);

                    using (var reader = command.ExecuteReader())
                    {
                        // Prepare the file path
                        string filePath = $"Invoice_{orderId}.txt";

                        using (var writer = new StreamWriter(filePath))
                        {
                            // Write header
                            writer.WriteLine("Invoice Details");
                            writer.WriteLine("------------------------------------------------");
                            writer.WriteLine($"Order ID: {orderId}");
                            writer.WriteLine();

                            // Write customer details
                            if (reader.Read())
                            {
                                writer.WriteLine($"Customer Name: {reader["CustomerName"]}");
                                writer.WriteLine($"Email: {reader["CustomerEmail"]}");
                                writer.WriteLine($"Phone: {reader["CustomerPhone"]}");
                                writer.WriteLine();

                                // Write table header for products
                                writer.WriteLine("Products:");
                                writer.WriteLine("------------------------------------------------");
                                writer.WriteLine("Product Name\tQuantity\tUnit Price\tTotal Price");

                                // Write product details
                                do
                                {
                                    writer.WriteLine($"{reader["ProductName"]}\t{reader["ProductQuantity"]}\t{reader["UnitPrice"]}\t{reader["TotalPrice"]}");
                                } while (reader.Read());
                            }

                            writer.WriteLine("------------------------------------------------");
                            writer.WriteLine("End of Invoice");
                        }

                        Console.WriteLine($"Invoice data has been written to {filePath}");
                    }
                }
            }
        }


        public void AddInvoice(Invoice invoice)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
                    INSERT INTO Invoice (status, invoice_date, total_amount, Order_id) 
                    VALUES (@status, @invoiceDate, @totalAmount, @orderId);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@status", invoice.Status);
                    command.Parameters.AddWithValue("@invoiceDate", invoice.InvoiceDate);
                    command.Parameters.AddWithValue("@totalAmount", invoice.TotalAmount);
                    command.Parameters.AddWithValue("@orderId", invoice.OrderId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            var invoices = new List<Invoice>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM Invoice;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var invoice = new Invoice(
                            id: Convert.ToInt32(reader["id"]),
                            status: Convert.ToInt32(reader["status"]),
                            invoiceDate: Convert.ToDateTime(reader["invoice_date"]),
                            totalAmount: Convert.ToDouble(reader["total_amount"]),
                            orderId: Convert.ToInt32(reader["Order_id"])
                        );

                        invoices.Add(invoice);
                    }
                }
            }
            return invoices;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
                    UPDATE Invoice 
                    SET status = @status,
                        invoice_date = @invoiceDate,
                        total_amount = @totalAmount,
                        Order_id = @orderId
                    WHERE id = @id;
                ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", invoice.Id);
                    command.Parameters.AddWithValue("@status", invoice.Status);
                    command.Parameters.AddWithValue("@invoiceDate", invoice.InvoiceDate);
                    command.Parameters.AddWithValue("@totalAmount", invoice.TotalAmount);
                    command.Parameters.AddWithValue("@orderId", invoice.OrderId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteInvoice(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM Invoice WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddProductList(ProductList productList)
        {
            using (var connection = OpenConnection())
            {
                string insertQuery = @"
                    INSERT INTO Product_list (Product_id, Order_id, quantity, unit_price, total_price) 
                    VALUES (@productId, @orderId, @quantity, @unitPrice, @totalPrice);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@productId", productList.ProductId);
                    command.Parameters.AddWithValue("@orderId", productList.OrderId);
                    command.Parameters.AddWithValue("@quantity", productList.Quantity);
                    command.Parameters.AddWithValue("@unitPrice", productList.UnitPrice);
                    command.Parameters.AddWithValue("@totalPrice", productList.TotalPrice);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ProductList> GetAllProductLists()
        {
            var productLists = new List<ProductList>();

            using (var connection = OpenConnection())
            {
                string query = "SELECT * FROM Product_list;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productList = new ProductList(
                            id: Convert.ToInt32(reader["id"]),
                            productId: Convert.ToInt32(reader["Product_id"]),
                            orderId: Convert.ToInt32(reader["Order_id"]),
                            quantity: Convert.ToInt32(reader["quantity"]),
                            unitPrice: Convert.ToDouble(reader["unit_price"]),
                            totalPrice: Convert.ToDouble(reader["total_price"])
                        );

                        productLists.Add(productList);
                    }
                }
            }
            return productLists;
        }

        public void UpdateProductList(ProductList productList)
        {
            using (var connection = OpenConnection())
            {
                string updateQuery = @"
                    UPDATE Product_list 
                    SET Product_id = @productId,
                        Order_id = @orderId,
                        quantity = @quantity,
                        unit_price = @unitPrice,
                        total_price = @totalPrice
                    WHERE id = @id;
                ";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", productList.Id);
                    command.Parameters.AddWithValue("@productId", productList.ProductId);
                    command.Parameters.AddWithValue("@orderId", productList.OrderId);
                    command.Parameters.AddWithValue("@quantity", productList.Quantity);
                    command.Parameters.AddWithValue("@unitPrice", productList.UnitPrice);
                    command.Parameters.AddWithValue("@totalPrice", productList.TotalPrice);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProductList(int id)
        {
            using (var connection = OpenConnection())
            {
                string deleteQuery = "DELETE FROM Product_list WHERE id = @id;";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    


    }
}
