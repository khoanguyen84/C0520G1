using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Course
{
    public class CourseView
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }
    }
}
