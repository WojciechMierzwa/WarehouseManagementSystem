using System;

namespace ConsoleInventoryManagerV2
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Nip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressRow1 { get; set; }
        public string AddressRow2 { get; set; }

        public Customer(int id, string name, string phoneNumber, string mail,
                        string nip, string country, string city,
                        string postalCode, string addressRow1, string addressRow2)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Nip = nip;
            Country = country;
            City = city;
            PostalCode = postalCode;
            AddressRow1 = addressRow1;
            AddressRow2 = addressRow2;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Phone: {PhoneNumber}, Mail: {Mail}, " +
                   $"NIP: {Nip}, Country: {Country}, City: {City}, " +
                   $"Postal Code: {PostalCode}, Address 1: {AddressRow1}, Address 2: {AddressRow2}";
        }
    }
}
