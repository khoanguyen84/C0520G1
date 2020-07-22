using System;
using System.Collections.Generic;

namespace CustomGenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyGeneric<int> numbers = new MyGeneric<int>();

            MyGeneric<User> users = new MyGeneric<User>();
            users.Add(new User()
            {
                Email = "khoa.nguyen@codegym.vn",
                Password = "1234546",
                UserId = 1,
                UserName = "Khoa Nguyen"
            });

            Dictionary

            Console.WriteLine(users.Count);
           
        }
    }
}
