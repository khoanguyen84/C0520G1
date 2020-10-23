using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeGymWeb.Models.Course
{
    public class CourseView
    {
        [Display(Name = "Mã khóa học")]
        public int CourseId { get; set; }
        [Display(Name = "Tên khóa học")]
        public string CourseName { get; set; }
    }
}
