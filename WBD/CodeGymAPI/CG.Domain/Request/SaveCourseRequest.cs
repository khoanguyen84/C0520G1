using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request
{
    public class SaveCourseRequest
    {
        public string CourseName { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
