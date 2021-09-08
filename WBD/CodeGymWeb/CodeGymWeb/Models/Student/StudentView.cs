using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Student
{
    public class StudentView
    {
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public string GenderStr { get; set; }
        public DateTime Dob { get; set; }
        public string DobStr { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
}
