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
        public IActionResult Index()
        {
            //ViewData["Message"] = "Hello everyone come to my site";
            //ViewBag.Hello = "Nice to meet you.";
            //TempData["msg"] = "welcome to my site";
            var students = new List<Student>()
            {
                new Student()
                {
                    DoB = "10/10/2000",
                    Fullname = "Khoa Nguyen",
                    ID  = 1,
                    Aavatar = "noavatar.png"
                },
                new Student()
                {
                    DoB = "10/10/2000",
                    Fullname = "Nhan Nguyen",
                    ID  = 2,
                    Aavatar = "avatar10.jpg"
                }
            };
            //ViewData["Message"] = "welcome to my site";
            //ViewBag.Title = "Student management";

            var model = new HomeViewModel()
            {
                Message = "welcome to my site",
                Title = "Student management",
                Students = students
            };


            return View(model);
        }
    }
}
