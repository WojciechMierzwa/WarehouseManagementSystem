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
    }
}
