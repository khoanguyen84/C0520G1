using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CollectionDemo
{
    class SortedListDemo
    {
        public static void Main()
        {
            SortedList sortedList = new SortedList();
            sortedList.Add("Tan", new Student() { 
                StudentId = 1,
                StudentName = "Tan"
            });
            sortedList.Add("Son", new Student()
            {
                StudentId = 2,
                StudentName = "Son"
            });
            sortedList.Add("Tung", new Student()
            {
                StudentId = 3,
                StudentName = "Tung"
            });

            foreach(var key in sortedList.Keys)
            {
                Console.WriteLine(sortedList[key].ToString());
            }

            //sortedList.RemoveAt(1);
            sortedList.Remove("Son");
            Console.WriteLine("---------------------------------");
            foreach (var key in sortedList.Keys)
            {
                Console.WriteLine(sortedList[key].ToString());
            }
        }
    }
}
