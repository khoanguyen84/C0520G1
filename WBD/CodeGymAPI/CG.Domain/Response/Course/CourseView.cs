using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Course
{
    public class CourseView
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CreatedtDate { get; set; }
        public string CreatedDateStr { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByStr { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateStr { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateStr { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateStr { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByStr { get; set; }
    }
}
