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
                Console.WriteLine("Management System");
                Console.WriteLine("1. Employee Management");
                Console.WriteLine("2. Customer Management");
                Console.WriteLine("3. Vendor Management");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageEmployees(controller);
                        break;
                    case "2":
                        ManageCustomers(controller);
                        break;
                    case "3":
                        ManageVendors(controller);
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

        private static void ManageVendors(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Vendor Management System");
                Console.WriteLine("1. Add Vendor");
                Console.WriteLine("2. Edit Vendor");
                Console.WriteLine("3. Delete Vendor");
                Console.WriteLine("4. Show All Vendors");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddVendor(controller);
                        break;
                    case "2":
                        EditVendor(controller);
                        break;
                    case "3":
                        DeleteVendor(controller);
                        break;
                    case "4":
                        ShowAllVendors(controller);
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

        private static void AddVendor(Controller controller)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number (optional): ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Mail (optional): ");
            string mail = Console.ReadLine();
            Console.Write("Enter NIP (optional): ");
            string nip = Console.ReadLine();

            Vendor vendor = new Vendor(0, name, phoneNumber, mail, nip);
            controller.AddVendor(vendor);
            Console.WriteLine($"\nVendor {name} added successfully!");
        }

        private static void EditVendor(Controller controller)
        {
            Console.Write("Enter Vendor ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var vendors = controller.GetAllVendors();
            var vendorToEdit = vendors.Find(v => v.Id == id);

            if (vendorToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) vendorToEdit.Name = name;

                Console.Write("Enter new Phone Number (leave blank to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) vendorToEdit.PhoneNumber = phoneNumber;

                Console.Write("Enter new Mail (leave blank to keep current): ");
                string mail = Console.ReadLine();
                if (!string.IsNullOrEmpty(mail)) vendorToEdit.Mail = mail;

                Console.Write("Enter new NIP (leave blank to keep current): ");
                string nip = Console.ReadLine();
                if (!string.IsNullOrEmpty(nip)) vendorToEdit.Nip = nip;

                controller.UpdateVendor(vendorToEdit);
                Console.WriteLine($"\nVendor {vendorToEdit.Name} updated successfully!");
            }
            else
            {
                Console.WriteLine("\nVendor not found.");
            }
        }

        private static void DeleteVendor(Controller controller)
        {
            Console.Write("Enter Vendor ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteVendor(id);
            Console.WriteLine($"\nVendor with ID {id} deleted successfully!");
        }

        private static void ShowAllVendors(Controller controller)
        {
            var vendors = controller.GetAllVendors();
            Console.WriteLine("\nList of Vendors:");
            foreach (var vendor in vendors)
            {
                Console.WriteLine($"ID: {vendor.Id}, Name: {vendor.Name}, Phone: {vendor.PhoneNumber}, Mail: {vendor.Mail}, NIP: {vendor.Nip}");
            }
        }

        private static void ManageEmployees(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Edit Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Show All Employees");
                Console.WriteLine("0. Back to Main Menu");
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

        private static void ManageCustomers(Controller controller)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Customer Management System");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Edit Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Show All Customers");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer(controller);
                        break;
                    case "2":
                        EditCustomer(controller);
                        break;
                    case "3":
                        DeleteCustomer(controller);
                        break;
                    case "4":
                        ShowAllCustomers(controller);
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

        // Methods for customer management
        private static void AddCustomer(Controller controller)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Mail: ");
            string mail = Console.ReadLine();
            Console.Write("Enter NIP (optional): ");
            string nip = Console.ReadLine();
            Console.Write("Enter Country: ");
            string country = Console.ReadLine();
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            Console.Write("Enter Postal Code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter Address Row 1: ");
            string addressRow1 = Console.ReadLine();
            Console.Write("Enter Address Row 2 (optional): ");
            string addressRow2 = Console.ReadLine();

            Customer customer = new Customer(0, name, phoneNumber, mail, nip, country, city, postalCode, addressRow1, addressRow2);
            controller.AddCustomer(customer);
            Console.WriteLine($"\nCustomer {name} added successfully!");
        }

        private static void EditCustomer(Controller controller)
        {
            Console.Write("Enter Customer ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var customers = controller.GetAllCustomers();
            var customerToEdit = customers.Find(c => c.Id == id);

            if (customerToEdit != null)
            {
                Console.Write("Enter new Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) customerToEdit.Name = name;

                Console.Write("Enter new Phone Number (leave blank to keep current): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber)) customerToEdit.PhoneNumber = phoneNumber;

                Console.Write("Enter new Mail (leave blank to keep current): ");
                string mail = Console.ReadLine();
                if (!string.IsNullOrEmpty(mail)) customerToEdit.Mail = mail;

                Console.Write("Enter new NIP (leave blank to keep current): ");
                string nip = Console.ReadLine();
                if (!string.IsNullOrEmpty(nip)) customerToEdit.Nip = nip;

                Console.Write("Enter new Country (leave blank to keep current): ");
                string country = Console.ReadLine();
                if (!string.IsNullOrEmpty(country)) customerToEdit.Country = country;

                Console.Write("Enter new City (leave blank to keep current): ");
                string city = Console.ReadLine();
                if (!string.IsNullOrEmpty(city)) customerToEdit.City = city;

                Console.Write("Enter new Postal Code (leave blank to keep current): ");
                string postalCode = Console.ReadLine();
                if (!string.IsNullOrEmpty(postalCode)) customerToEdit.PostalCode = postalCode;

                Console.Write("Enter new Address Row 1 (leave blank to keep current): ");
                string addressRow1 = Console.ReadLine();
                if (!string.IsNullOrEmpty(addressRow1)) customerToEdit.AddressRow1 = addressRow1;

                Console.Write("Enter new Address Row 2 (leave blank to keep current): ");
                string addressRow2 = Console.ReadLine();
                if (!string.IsNullOrEmpty(addressRow2)) customerToEdit.AddressRow2 = addressRow2;

                controller.UpdateCustomer(customerToEdit);
                Console.WriteLine($"\nCustomer {customerToEdit.Name} updated successfully!");
            }
            else
            {
                Console.WriteLine("\nCustomer not found.");
            }
        }

        private static void DeleteCustomer(Controller controller)
        {
            Console.Write("Enter Customer ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            controller.DeleteCustomer(id);
            Console.WriteLine($"\nCustomer with ID {id} deleted successfully!");
        }

        private static void ShowAllCustomers(Controller controller)
        {
            var customers = controller.GetAllCustomers();
            Console.WriteLine("\nList of Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.PhoneNumber}, Mail: {customer.Mail}");
            }
        }
    }
}
