using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Course
{
    public class CreateCourse
    {
        public string CourseName { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
