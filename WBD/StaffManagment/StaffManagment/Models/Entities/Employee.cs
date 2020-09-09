using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Fullname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
