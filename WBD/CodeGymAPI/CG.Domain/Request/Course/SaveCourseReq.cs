using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request.Course
{
    public class SaveCourseReq
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateStr { get; set; }
        public string EndDateStr { get; set; }
    }
}
