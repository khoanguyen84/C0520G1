using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CG.Domain.Request
{
    public class EditTeacher
    {
        public int TeacherId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "more than 50 characters")]
        public string FullName { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"^[\w-\.]+@([\w -]+\.)+[\w-]{2,4}$", ErrorMessage = "E-mail is not valid")]
        //[Remote("EmailExists", "Teacher", HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number Required!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Level { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        [Range(0, 2, ErrorMessage = "Must enter 0 - 2")]
        public int Status { get; set; }
        public int ModifiedBy { get; set; }
    }
}
