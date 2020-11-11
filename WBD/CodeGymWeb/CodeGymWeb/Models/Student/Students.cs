using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Student
{
    public class Students
    {
        public string CourseName { get; set; }
        public IEnumerable<StudentView> StudentList { get; set; }
    }
}
