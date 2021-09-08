using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeGymWeb.Models.Student;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace CodeGymWeb.Controllers
{
    public class StudentController : Controller
    {
        private int courseId = 0;
        public IActionResult Index(int id)
        {
            courseId = id;
            var students = ApiHelper<Students>.HttpGetAsync($"student/getbycourseid/{id}");
            return View(students);
        }

    }
}
