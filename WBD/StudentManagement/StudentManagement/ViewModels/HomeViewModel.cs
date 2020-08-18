using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class HomeViewModel
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public List<Student> Students { get; set; }
    }
}
