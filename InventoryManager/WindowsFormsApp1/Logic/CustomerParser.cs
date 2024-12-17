using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1.Logic
{
    public class CustomerParser
    {
        // Define the connection string (replace with your actual connection string).
        private string connectionString;

        Boolean action = false;

        public CustomerParser()
        {
            loadConnectionString();
        }

        public void loadConnectionString()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(exeDirectory, "connectionString.txt");

            try
            {
                connectionString = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> Customers = new List<Customer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    string sql = "SELECT * FROM Customer ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer Customer = new Customer
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Phone_number = reader.GetString(reader.GetOrdinal("phone_number")),
                                    Mail = reader.GetString(reader.GetOrdinal("mail")),
                                    Nip = reader.GetString(reader.GetOrdinal("nip")),
                                    Country = reader.GetString(reader.GetOrdinal("country")),
                                    City = reader.GetString(reader.GetOrdinal("city")),
                                    Postal_code = reader.GetString(reader.GetOrdinal("postal_code")),
                                    Address_row1 = reader.GetString(reader.GetOrdinal("address_row1")),
                                    Address_row2 = reader.GetString(reader.GetOrdinal("address_row2")),
                                };

                                Console.WriteLine($"Customer read: ID = {Customer.Id}, Name = {Customer.Name}");
                                Customers.Add(Customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine($"Total Customers retrieved: {Customers.Count}");
            return Customers;
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Customer WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Use if since we're expecting only one result
                            {
                                // Create and return the Customer instance populated with data from the reader
                                return new Customer
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Phone_number = reader.GetString(reader.GetOrdinal("phone_number")),
                                    Mail = reader.GetString(reader.GetOrdinal("mail")),
                                    Nip = reader.GetString(reader.GetOrdinal("nip")),
                                    Country = reader.GetString(reader.GetOrdinal("country")),
                                    City = reader.GetString(reader.GetOrdinal("city")),
                                    Postal_code = reader.GetString(reader.GetOrdinal("postal_code")),
                                    Address_row1 = reader.GetString(reader.GetOrdinal("address_row1")),
                                    Address_row2 = reader.GetString(reader.GetOrdinal("address_row2")),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // Return null if no Customer is found or an error occurs
            return null;
        }

        public bool EditCustomer(Customer Customer)
        {
            try
            {
                // Ensure the Customer id is valid for updating.
                if (Customer.Id <= 0)
                {
                    throw new ArgumentException("Invalid Customer ID.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to update the Customer details.
                    string sql = @"
                UPDATE Customer
                SET 
                    name = @name,
                    phone_number = @phone_number,
                    mail = @mail,
                    nip = @nip,
                    country = @country,
                    city = @city,
                    postal_code = @postal_code,
                    address_row1 = @address_row1,
                    address_row2 = @address_row2
                WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to the SQL query to prevent SQL injection.
                        command.Parameters.AddWithValue("@id", Customer.Id);
                        command.Parameters.AddWithValue("@name", Customer.Name);
                        command.Parameters.AddWithValue("@phone_number", Customer.Phone_number);
                        command.Parameters.AddWithValue("@mail", Customer.Mail);
                        command.Parameters.AddWithValue("@nip", Customer.Nip);
                        command.Parameters.AddWithValue("@country", Customer.Country);
                        command.Parameters.AddWithValue("@city", Customer.City);
                        command.Parameters.AddWithValue("@postal_code", Customer.Postal_code);
                        command.Parameters.AddWithValue("@address_row1", Customer.Address_row1);
                        command.Parameters.AddWithValue("@address_row2", Customer.Address_row2);

                        // Execute the command and check if any rows were affected.
                        int rowsAffected = command.ExecuteNonQuery();

                        // Return true if the Customer was updated, false otherwise.
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as needed.
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }



        public void AddCustomer(Customer Customer)
        {
            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL INSERT statement to add a new Customer to the database
                    string sql = "INSERT INTO Customer (name, phone_number, mail, nip, country, city, postal_code,address_row1, address_row2) " +
                                 "VALUES (@name, @phone_number, @mail, @nip, @country, @city, @postal_code,@address_row1,@address_row2)";

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to the command to prevent SQL injection

                        command.Parameters.AddWithValue("@id", Customer.Id);
                        command.Parameters.AddWithValue("@name", Customer.Name);
                        command.Parameters.AddWithValue("@phone_number", Customer.Phone_number);
                        command.Parameters.AddWithValue("@mail", Customer.Mail);
                        command.Parameters.AddWithValue("@nip", Customer.Nip);
                        command.Parameters.AddWithValue("@country", Customer.Country);
                        command.Parameters.AddWithValue("@city", Customer.City);
                        command.Parameters.AddWithValue("@postal_code", Customer.Postal_code);
                        command.Parameters.AddWithValue("@address_row1", Customer.Address_row1);
                        command.Parameters.AddWithValue("@address_row2", Customer.Address_row2);

                        // Execute the command
                        int result = command.ExecuteNonQuery();

                        // If the result is 1 or greater, the insert was successful

                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the error (for now, just print to the console)
                Console.WriteLine("Error: " + ex.Message);

            }
        }

        public bool DeleteCustomer(int CustomerId)
        {
            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL DELETE statement to remove the Customer from the database
                    string sql = "DELETE FROM Customer WHERE id = @id";

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add the parameter to the command
                        command.Parameters.AddWithValue("@id", CustomerId);

                        // Execute the command
                        int result = command.ExecuteNonQuery();

                        // If the result is 1 or greater, the delete was successful
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or display the error (for now, just print to the console)
                Console.WriteLine("Error: " + ex.Message);
                return false; // Return false if an error occurs
            }
        }


    }
}
