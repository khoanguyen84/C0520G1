using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request.Student
{
    public class SaveStudentReq
    {
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public int CourseId { get; set; }
    }
}
