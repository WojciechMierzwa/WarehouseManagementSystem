using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Logic
{
    public class ProductListParser
    {
        private string connectionString;

        public ProductListParser()
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

        public List<ProductList> GetProductLists()
        {
            List<ProductList> productLists = new List<ProductList>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    string sql = "SELECT * FROM Product_list ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductList productList = new ProductList
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("Product_id")),
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("Invoice_id")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("quantity"))
                                };

                                Console.WriteLine($"ProductList read: ID = {productList.Id}, Product ID = {productList.ProductId}, Invoice ID = {productList.InvoiceId}");
                                productLists.Add(productList);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine($"Total product lists retrieved: {productLists.Count}");
            return productLists;
        }

        public ProductList GetProductList(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Product_list WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ProductList
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("Product_id")),
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("Invoice_id")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("quantity"))
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

            return null;
        }

        public void AddProductList(ProductList productList)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Product_list (Product_id, Invoice_id, quantity) " +
                                 "VALUES (@productId, @invoiceId, @quantity)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productList.ProductId);
                        command.Parameters.AddWithValue("@invoiceId", productList.InvoiceId);
                        command.Parameters.AddWithValue("@quantity", productList.Quantity);

                        command.ExecuteNonQuery();
                        Console.WriteLine($"ProductList added: Product ID = {productList.ProductId}, Invoice ID = {productList.InvoiceId}, Quantity = {productList.Quantity}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool EditProductList(ProductList productList)
        {
            try
            {
                if (productList.Id <= 0)
                {
                    throw new ArgumentException("Invalid product list ID.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE Product_list
                    SET 
                        Product_id = @productId,
                        Invoice_id = @invoiceId,
                        quantity = @quantity
                    WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", productList.Id);
                        command.Parameters.AddWithValue("@productId", productList.ProductId);
                        command.Parameters.AddWithValue("@invoiceId", productList.InvoiceId);
                        command.Parameters.AddWithValue("@quantity", productList.Quantity);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool DeleteProductList(int productListId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Product_list WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", productListId);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
