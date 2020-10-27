﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CG.Domain.Response.Teacher
{
    public class TeacherView
    {
        public int TeacherId { get; set; }      
        public string FullName { get; set; }
        public bool Gender { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Level { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public string Avatar { get; set; }
        
    }
}
