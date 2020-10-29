using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace CG.Domain.Response.Teacher
{
   public class Teacher
    {
        public int TeacherId { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Level { get; set; }
        public string  Address { get; set; }
        public string Avatar { get; set; }
        public int  Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy{ get; set; }
    }
}
