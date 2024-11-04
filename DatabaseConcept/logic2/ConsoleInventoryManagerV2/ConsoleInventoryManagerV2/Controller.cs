using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

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

    }
}
