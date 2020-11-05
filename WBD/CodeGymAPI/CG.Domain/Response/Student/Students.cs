using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Response.Student
{
    public class Students
    {
        public string CourseName { get; set; }
        public IEnumerable<StudentView> StudentList { get; set; }
    }
}
