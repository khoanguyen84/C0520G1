using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeGymWeb.Models.Student;
using CodeGymWeb.Models.Wiki;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CodeGymWeb.Controllers
{
    public class StudentController : Controller
    {
        
        private int courseId = 0;
        private readonly IWebHostEnvironment webHostEnvironment;
        public StudentController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index(int id)
        {
            courseId = id;
            ViewBag.CourseId = courseId;
            var students = ApiHelper<Students>.HttpGetAsync($"student/getbycourseid/{id}");
            return View(students);
            
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            courseId = id;
            ViewBag.courseId = courseId;
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Student}");
            return View();
        }
        [HttpPost]
        public IActionResult Create(SaveStudentReq request)
        {
            var result = new SaveStudentRes();
            if (ModelState.IsValid)
            {
                request.Gender = (request.GenderInt == 0 ? false : true);
                var fileName = string.Empty;
                if(request.AvatarPath != null)
                {
                    var uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{request.AvatarPath.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using(var fs = new FileStream(filePath, FileMode.Create))
                    {
                        request.AvatarPath.CopyTo(fs);
                    }
                }
                request.Avatar = fileName;
                result = ApiHelper<SaveStudentRes>.HttpPostAsync("student/save", "POST", request);
                if (result.StudentId != 0)
                {
                    return RedirectToAction("Index",new { id = request.CourseId});
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(request);
        }
        [HttpGet]
        [Route("/Student/Edit/{studentId}")]
        public IActionResult Edit(int studentId)
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Student}");
            var student = ApiHelper<SaveStudentReq>.HttpGetAsync($"student/get/{studentId}");
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(SaveStudentReq request)
        {
            var result = new SaveStudentRes();
            if (ModelState.IsValid)
            {
                request.Gender = (request.GenderInt == 0 ? false : true);
                var fileName = string.Empty;
                if(request.AvatarPath != null)
                {
                    if (!string.IsNullOrEmpty(request.Avatar))
                    {
                        string delFile = Path.Combine(webHostEnvironment.WebRootPath, "images", request.Avatar);
                        System.IO.File.Delete(delFile);
                    }
                    var uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{request.AvatarPath.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        request.AvatarPath.CopyTo(fs);
                    }
                }
                request.Avatar = fileName;
                result = ApiHelper<SaveStudentRes>.HttpPostAsync("student/save", "POST", request);
                if (result.StudentId != 0)
                {
                    return RedirectToAction("Index", new { id = request.CourseId });
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(request);
        }

    }
}
