using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Course
{
    public class GetCourse
    {
        [Display(Name = "Mã khóa học")]
        public int CourseId { get; set; }
        [Display(Name = "Tên khóa học")]
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public string StartDateStr { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public string EndDateStr { get; set; }
    }
}
