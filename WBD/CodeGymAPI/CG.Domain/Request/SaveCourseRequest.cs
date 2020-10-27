using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CG.Domain.Request
{
    public class SaveCourseRequest
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage ="Tên khóa học không được để trống")]
        public string CourseName { get; set; }
        [Range(1,3,ErrorMessage ="Status is not valid")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Ngày bắt đầu không được để trống")]     
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime,ErrorMessage ="Ngày sai định dạng")]
        [Required(ErrorMessage = "Ngày kết thúc không được để trống")]
        public DateTime EndDate { get; set; }
    }
}
