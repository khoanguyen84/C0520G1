using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\JsonDemo\Data\matrix.json";
            var result = new Data();
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Data>(data);
            }

            foreach(var item in result.matrix)
            {
                foreach(var number in item)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }

            foreach(var arr in result.array)
            {
                Console.Write($"{arr} ");
            }

            Console.WriteLine();
            foreach(var emp in result.employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }
    }

    class Data
    {
        public List<List<int>> matrix { get; set; }
        public List<int> array { get; set; }
        public List<Employee> employees { get; set; }
    }
    class Employee
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public override string ToString()
        {
            return $"{name}, {age}, {gender}, {dob}";
        }
    }
}
