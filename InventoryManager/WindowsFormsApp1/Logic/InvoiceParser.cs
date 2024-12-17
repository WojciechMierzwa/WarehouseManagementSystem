using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Logic
{
    public class InvoiceParser
    {
        private string connectionString;

        public InvoiceParser()
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

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    string sql = "SELECT * FROM Invoice ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Invoice invoice = new Invoice
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Status = reader.GetBoolean(reader.GetOrdinal("status")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("date")),
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("Customer_id")),
                                    InvoiceFilePath = reader.IsDBNull(reader.GetOrdinal("invoice"))
                                        ? null
                                        : reader.GetString(reader.GetOrdinal("invoice"))
                                };

                                Console.WriteLine($"Invoice read: ID = {invoice.Id}, Customer ID = {invoice.CustomerId}");
                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine($"Total invoices retrieved: {invoices.Count}");
            return invoices;
        }

        public Invoice GetInvoice(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Invoice WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Invoice
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Status = reader.GetBoolean(reader.GetOrdinal("status")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("date")),
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("Customer_id")),
                                    InvoiceFilePath = reader.IsDBNull(reader.GetOrdinal("invoice"))
                                        ? null
                                        : reader.GetString(reader.GetOrdinal("invoice"))
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

        public bool EditInvoice(Invoice invoice)
        {
            try
            {
                if (invoice.Id <= 0)
                {
                    throw new ArgumentException("Invalid invoice ID.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE Invoice
                    SET 
                        status = @status,
                        date = @date,
                        Customer_id = @customerId,
                        invoice = @invoiceFilePath
                    WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", invoice.Id);
                        command.Parameters.AddWithValue("@status", invoice.Status);
                        command.Parameters.AddWithValue("@date", invoice.Date);
                        command.Parameters.AddWithValue("@customerId", invoice.CustomerId);
                        command.Parameters.AddWithValue("@invoiceFilePath", (object)invoice.InvoiceFilePath ?? DBNull.Value);

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

        public void AddInvoice(Invoice invoice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Invoice (status, date, Customer_id, invoice) " +
                                 "VALUES (@status, @date, @customerId, @invoiceFilePath)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@status", invoice.Status);
                        command.Parameters.AddWithValue("@date", invoice.Date);
                        command.Parameters.AddWithValue("@customerId", invoice.CustomerId);
                        command.Parameters.AddWithValue("@invoiceFilePath", (object)invoice.InvoiceFilePath ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /*public bool DeleteInvoice(int invoiceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Invoice WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", invoiceId);

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
        }*/
        public bool DeleteInvoice(int invoiceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First, delete all product list entries that reference the invoice
                    string deleteProductListSql = "DELETE FROM Product_list WHERE Invoice_id = @invoiceId";
                    using (SqlCommand deleteProductListCommand = new SqlCommand(deleteProductListSql, connection))
                    {
                        deleteProductListCommand.Parameters.AddWithValue("@invoiceId", invoiceId);
                        deleteProductListCommand.ExecuteNonQuery();
                        Console.WriteLine($"Product list entries for Invoice ID {invoiceId} deleted.");
                    }

                    // Now, delete the invoice itself
                    string deleteInvoiceSql = "DELETE FROM Invoice WHERE id = @id";
                    using (SqlCommand deleteInvoiceCommand = new SqlCommand(deleteInvoiceSql, connection))
                    {
                        deleteInvoiceCommand.Parameters.AddWithValue("@id", invoiceId);
                        int result = deleteInvoiceCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Console.WriteLine($"Invoice ID {invoiceId} deleted successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Invoice ID {invoiceId} not found.");
                            return false;
                        }
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
