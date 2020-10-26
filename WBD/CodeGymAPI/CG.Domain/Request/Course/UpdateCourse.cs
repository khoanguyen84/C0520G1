using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CG.Domain.Request.Course
{
    public class UpdateCourse
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "CourseName không được trống")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Status không được trống")]
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
