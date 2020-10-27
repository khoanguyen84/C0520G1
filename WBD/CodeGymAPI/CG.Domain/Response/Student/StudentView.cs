using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Student
{
    public class StudentView
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public string DobStr { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }        
        public string Address { get; set; }
    }
}
