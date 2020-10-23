using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request
{
    public class CreateTeacher
    {
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Level { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
