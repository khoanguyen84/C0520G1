using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionDemo
{
    class HashTableDemo
    {
        public static void Main()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, new Student()
            {
                StudentId = 1,
                StudentName = "Nhan"
            });
            hashtable.Add(2, new Student()
            {
                StudentId = 2,
                StudentName = "An"
            });
            hashtable.Add(3, new Student()
            {
                StudentId = 3,
                StudentName = "My"
            });

            foreach(var value in hashtable.Values)
            {
                Console.WriteLine(value.ToString());
            }
        }
    }
}
