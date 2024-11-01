using System;

namespace ConsoleInventoryManager
{
    public class Employee
    {
        public int Id { get; set; }               // Automatically incrementing ID
        public string Name { get; set; }          // Employee's name
        public string Surname { get; set; }       // Employee's surname
        public string Pesel { get; set; }         // Employee's PESEL number
        public string PhoneNumber { get; set; }   // Employee's phone number
        public string Login { get; set; }         // Employee's login
        public string Password { get; set; }      // Employee's password
        public char AccountType { get; set; }     // Employee's account type ('a', 'm', 'e')

        public Employee(int id, string name, string surname, string pesel,
                        string phoneNumber, string login, string password, char accountType)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel = pesel;
            PhoneNumber = phoneNumber;
            Login = login;
            Password = password;
            AccountType = accountType;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Surname: {Surname}, PESEL: {Pesel}, " +
                   $"Phone: {PhoneNumber}, Login: {Login}, Account Type: {AccountType}";
        }
    }
}
