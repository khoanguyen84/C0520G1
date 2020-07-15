using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> employees = new SortedList<int, string>();
            employees.Add(1, "Son");
            employees.Add(2, "Nhan");

            Queue<double> queue = new Queue<double>();

            Stack<string> stack = new Stack<string>();

            Dictionary<int, Employee> emps = new Dictionary<int, Employee>();
            emps.Add(1, new Employee() {
                EmployeeId = 1,
                EmployeeName = "Tan"
            });

            List<Employee> employeeList = new List<Employee>();

            employeeList.Add(new Employee()
            {
                EmployeeId = 1,
                EmployeeName = "Tan"
            });

            LinkedList<Employee> empList = new LinkedList<Employee>();
            empList.AddLast(new Employee() { 
                EmployeeId = 1,
                EmployeeName = "My"
            });
        }
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
