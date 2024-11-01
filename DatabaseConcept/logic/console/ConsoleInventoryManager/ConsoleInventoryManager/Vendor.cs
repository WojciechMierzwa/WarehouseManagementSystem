using System;

namespace ConsoleInventoryManager
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public string? Nip { get; set; }

        public Vendor(int id, string name, string? phoneNumber, string? mail, string? nip)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Nip = nip;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Phone: {PhoneNumber}, Email: {Mail}, NIP: {Nip}";
        }
    }
}
