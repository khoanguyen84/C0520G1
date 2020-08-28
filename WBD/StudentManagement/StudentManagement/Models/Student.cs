using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public DateTime DoB { get; set; }
        public string Aavatar { get; set; }
        public string Email { get; set; }
        public Classes Classes { get; set; }
    }
}
