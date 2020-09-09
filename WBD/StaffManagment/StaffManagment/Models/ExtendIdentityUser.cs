using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models
{
    public class ExtendIdentityUser : IdentityUser
    {
        public bool Gender { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(300)]
        public string AvatarPath { get; set; }
    }
}
