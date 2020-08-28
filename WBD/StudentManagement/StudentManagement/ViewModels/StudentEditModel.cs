using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class StudentEditModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [Display(Name = "Họ và tên")]
        [MinLength(10, ErrorMessage = "Họ và tên phải hơn 10 ký tự")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        [Required(ErrorMessage = "Thư điện tử không được để trống")]
        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$",
                ErrorMessage = "Thư điện tử không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Lớp")]
        [Required(ErrorMessage = "Bạn chưa chọn lớp")]
        public Classes Classes { get; set; }
    }
}
