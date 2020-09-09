using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagment.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid format")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Rememer me")]
        public bool RememberMe { get; set; }
    }
}
