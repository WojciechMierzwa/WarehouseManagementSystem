using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Logic
{
    public class EmployeeParser
    {
        private string connectionString;

        public EmployeeParser()
        {
            loadConnectionString();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    string sql = "SELECT * FROM Employee ORDER BY id DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee employee = new Employee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Surname = reader.GetString(reader.GetOrdinal("surname")),
                                    Login = reader.GetString(reader.GetOrdinal("login")),
                                    Password = reader.GetString(reader.GetOrdinal("password"))
                                };

                                Console.WriteLine($"Employee read: ID = {employee.Id}, Name = {employee.Name}");
                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine($"Total employees retrieved: {employees.Count}");
            return employees;
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

        public Employee GetEmployee(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Employee WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Surname = reader.GetString(reader.GetOrdinal("surname")),
                                    Login = reader.GetString(reader.GetOrdinal("login")),
                                    Password = reader.GetString(reader.GetOrdinal("password"))
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

        public bool EditEmployee(Employee employee)
        {
            try
            {
                if (employee.Id <= 0)
                {
                    throw new ArgumentException("Invalid employee ID.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"
                    UPDATE Employee
                    SET 
                        name = @name,
                        surname = @surname,
                        login = @login,
                        password = @password
                    WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", employee.Id);
                        command.Parameters.AddWithValue("@name", employee.Name);
                        command.Parameters.AddWithValue("@surname", employee.Surname);
                        command.Parameters.AddWithValue("@login", employee.Login);
                        command.Parameters.AddWithValue("@password", employee.Password);

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

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Employee (name, surname, login, password) " +
                                 "VALUES (@name, @surname, @login, @password)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", employee.Name);
                        command.Parameters.AddWithValue("@surname", employee.Surname);
                        command.Parameters.AddWithValue("@login", employee.Login);
                        command.Parameters.AddWithValue("@password", employee.Password);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Employee WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", employeeId);

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

        public Employee GetEmployeeByLoginAndPassword(string login, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT Id, Name, Surname, Login, Password FROM Employee WHERE login = @login AND password = @password";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Surname = reader.GetString(reader.GetOrdinal("Surname")),
                                    Login = reader.GetString(reader.GetOrdinal("Login")),
                                    Password = reader.GetString(reader.GetOrdinal("Password"))
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

    }


}
