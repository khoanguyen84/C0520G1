using PeopleManagement.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models.ViewModels
{
    public class RegisterUser
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        public string Fullname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [RegularExpression(@"(09|01[2|6|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có 6 ký tự trở lên")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có 6 ký tự trở lên")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Tỉnh thành")]
        public int ProvinceId { get; set; }
        [Display(Name = "Quận/huyện")]
        public int DistrictId { get; set; }
        [Display(Name = "Phường/xã")]
        public int WardId { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        public string Address { get; set; }
    }
}
