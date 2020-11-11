using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CodeGymWeb.Models.Student
{
    public class SaveStudentReq
    {
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public int GenderInt { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile AvatarPath { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public int CourseId { get; set; }
    }
}
