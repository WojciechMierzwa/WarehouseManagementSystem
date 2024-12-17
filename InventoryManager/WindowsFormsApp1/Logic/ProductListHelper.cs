using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using WindowsFormsApp1;

public class ProductListHelper
{
    private string connectionString;

    public ProductListHelper() { 
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
    public List<(ProductList, Product)> GetProductListsWithProducts(int invoiceId)
    {
        var result = new List<(ProductList, Product)>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = @"
                SELECT pl.Id AS ProductListId, pl.ProductId, pl.InvoiceId, pl.Quantity,
                       p.Id AS ProductId, p.Name, p.Sku, p.Category, p.NetPrice, p.Vat, p.Stock, p.Vendor
                FROM Product_list pl
                JOIN Product p ON pl.ProductId = p.Id
                WHERE pl.InvoiceId = @InvoiceId";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@InvoiceId", invoiceId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productList = new ProductList
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ProductListId")),
                            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                            InvoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"))
                        };

                        var product = new Product
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ProductId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Sku = reader.GetInt32(reader.GetOrdinal("Sku")),
                            Category = reader.GetString(reader.GetOrdinal("Category")),
                            NetPrice = reader.GetDecimal(reader.GetOrdinal("NetPrice")),
                            Vat = reader.GetDecimal(reader.GetOrdinal("Vat")),
                            Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                            Vendor = reader.GetString(reader.GetOrdinal("Vendor"))
                        };

                        result.Add((productList, product));
                    }
                }
            }
        }

        return result;
    }
}
