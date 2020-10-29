using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Domain.Request.Teacher
{
   public class TeacherResult
    {
        public int TeacherId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
