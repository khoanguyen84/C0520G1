using System;

namespace PhoneManagement
{
    class Program
    {
        public static PhoneBook PhoneBook = new PhoneBook();
        static void Main(string[] args)
        {
            PhoneBook.Show();

            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter phone number: ");
            var newPhone = Console.ReadLine();

            PhoneBook.InsertPhone(name, newPhone);
            PhoneBook.Show();

            Console.Write("Enter name: ");
            var name2 = Console.ReadLine();
            Console.Write("Enter phone number: ");
            var newPhone2 = Console.ReadLine();

            PhoneBook.UpdatePhone(name2, newPhone2);
            PhoneBook.Show();

        }
    }
}
