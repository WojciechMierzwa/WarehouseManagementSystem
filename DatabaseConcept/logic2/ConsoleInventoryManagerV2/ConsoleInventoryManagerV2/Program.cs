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
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Edit Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Show All Employees");
                Console.WriteLine("0. Exit");
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
    }
}
