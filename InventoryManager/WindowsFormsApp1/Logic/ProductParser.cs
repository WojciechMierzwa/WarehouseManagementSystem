using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1.Logic
{
    public class ProductParser
    {

        private string connectionString;

        public ProductParser()
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

        Boolean action = false;
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    string sql = "SELECT * FROM Product ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Sku = reader.GetInt32(reader.GetOrdinal("sku")),
                                    Category = reader.GetString(reader.GetOrdinal("category")),
                                    NetPrice = reader.GetDecimal(reader.GetOrdinal("net_price")),
                                    Vat = reader.GetDecimal(reader.GetOrdinal("vat")),
                                    Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                                    Vendor = reader.GetString(reader.GetOrdinal("vendor"))
                                };

                                Console.WriteLine($"Product read: ID = {product.Id}, Name = {product.Name}");
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine($"Total products retrieved: {products.Count}");
            return products;
        }

        public Product GetProduct(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Product WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Use if since we're expecting only one result
                            {
                                // Create and return the Product instance populated with data from the reader
                                return new Product
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Sku = reader.GetInt32(reader.GetOrdinal("sku")),
                                    Category = reader.GetString(reader.GetOrdinal("category")),
                                    NetPrice = reader.GetDecimal(reader.GetOrdinal("net_price")),
                                    Vat = reader.GetDecimal(reader.GetOrdinal("vat")),
                                    Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                                    Vendor = reader.GetString(reader.GetOrdinal("vendor"))
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

            // Return null if no product is found or an error occurs
            return null;
        }

        public bool EditProduct(Product product)
        {
            try
            {
                // Ensure the product id is valid for updating.
                if (product.Id <= 0)
                {
                    throw new ArgumentException("Invalid product ID.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query to update the product details.
                    string sql = @"
                UPDATE Product
                SET 
                    name = @name,
                    sku = @sku,
                    category = @category,
                    net_price = @net_price,
                    vat = @vat,
                    stock = @stock,
                    vendor = @vendor
                WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to the SQL query to prevent SQL injection.
                        command.Parameters.AddWithValue("@id", product.Id);
                        command.Parameters.AddWithValue("@name", product.Name);
                        command.Parameters.AddWithValue("@sku", product.Sku);
                        command.Parameters.AddWithValue("@category", product.Category);
                        command.Parameters.AddWithValue("@net_price", product.NetPrice);
                        command.Parameters.AddWithValue("@vat", product.Vat);
                        command.Parameters.AddWithValue("@stock", product.Stock);
                        command.Parameters.AddWithValue("@vendor", product.Vendor);

                        // Execute the command and check if any rows were affected.
                        int rowsAffected = command.ExecuteNonQuery();

                        // Return true if the product was updated, false otherwise.
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



        public void AddProduct(Product product)
        {
            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL INSERT statement to add a new product to the database
                    string sql = "INSERT INTO Product (name, sku, category, net_price, vat, stock, vendor) " +
                                 "VALUES (@name, @sku, @category, @netPrice, @vat, @stock, @vendor)";

                    // Create the SQL command
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to the command to prevent SQL injection
                        
                        command.Parameters.AddWithValue("@name", product.Name);
                        command.Parameters.AddWithValue("@sku", product.Sku);
                        command.Parameters.AddWithValue("@category", product.Category);
                        command.Parameters.AddWithValue("@netPrice", product.NetPrice);
                        command.Parameters.AddWithValue("@vat", product.Vat);
                        command.Parameters.AddWithValue("@stock", product.Stock);
                        command.Parameters.AddWithValue("@vendor", product.Vendor);

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

        public bool DeleteProduct(int productId)
        {
            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL DELETE statement to remove dependent product_list rows
                    string sqlDeleteProductList = "DELETE FROM Product_list WHERE Product_id = @id";
                    using (SqlCommand command = new SqlCommand(sqlDeleteProductList, connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
                        command.ExecuteNonQuery();
                    }

                    // SQL DELETE statement to remove the product from the Product table
                    string sqlDeleteProduct = "DELETE FROM Product WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(sqlDeleteProduct, connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);
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
