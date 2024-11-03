using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInventoryManagerV2
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public char AccountType { get; set; }

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
