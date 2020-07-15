using System;
using System.Collections;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new Student()
            {
                StudentId = 1,
                StudentName = "Long"
            });
            arrayList.Add(new Student()
            {
                StudentId = 2,
                StudentName = "Vui"
            });

            Console.WriteLine($"StudentId\tStudentName");
            foreach (Student std in arrayList)
            {
                Console.WriteLine(std.ToString());
            }
        }
    }

    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return $"{StudentId}\t{StudentName}";
        }
    }
}
