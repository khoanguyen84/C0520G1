using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var students = studentRepository.Gets();
            var model = new HomeViewModel()
            {
                Message = "welcome to my site",
                Title = "Student management",
                Students = students.ToList()
            };

            return View(model);
        }

        //attribute routing
        //[Route("/Detail/{studentId}/{classId}/{subjectId}")]
        //[Route("/Home/Detail/{studentId}/{classId}/{subjectId}")]

        //public IActionResult Detail(int studentId, int classId, int subjectId)
        public IActionResult Detail(int id)
        {
            var student = studentRepository.Get(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateModel model)
        {
            var studentCreated = studentRepository.Create(model);
            if(studentCreated != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
