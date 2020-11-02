using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CG.Domain.Response.Course
{
    public class CourseView
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }
        public string StatusName { get; set; }
    }
}
