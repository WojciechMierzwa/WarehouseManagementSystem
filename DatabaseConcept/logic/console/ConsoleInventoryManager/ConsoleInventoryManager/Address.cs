using System;

namespace ConsoleInventoryManager
{
    public class Address
    {
        public int Id { get; set; }                    // Automatically incrementing ID
        public string Country { get; set; }            // Country, required
        public string City { get; set; }               // City, required
        public string PostalCode { get; set; }         // Postal code, required
        public string? Street { get; set; }            // Street, optional
        public string? BuildingNumber { get; set; }    // Building number, optional
        public int? VendorId { get; set; }             // Optional Vendor foreign key
        public int? CustomerId { get; set; }           // Optional Customer foreign key
        public int? EmployeeId { get; set; }           // Optional Employee foreign key

        public Address(int id, string country, string city, string postalCode,
                       string? street, string? buildingNumber,
                       int? vendorId, int? customerId, int? employeeId)
        {
            Id = id;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Street = street;
            BuildingNumber = buildingNumber;
            VendorId = vendorId;
            CustomerId = customerId;
            EmployeeId = employeeId;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Country: {Country}, City: {City}, Postal Code: {PostalCode}, " +
                   $"Street: {Street}, Building Number: {BuildingNumber}, " +
                   $"Vendor ID: {VendorId}, Customer ID: {CustomerId}, Employee ID: {EmployeeId}";
        }
    }
}
