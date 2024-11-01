using System;

namespace ConsoleInventoryManager
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public Customer(int id, string name, string? phoneNumber, string? email, string? address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Phone: {PhoneNumber}, Email: {Email}, Address: {Address}";
        }
    }
}
