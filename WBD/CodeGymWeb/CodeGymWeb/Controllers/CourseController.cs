using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeGymWeb.Models.Course;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeGymWeb.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiHelper<List<CourseView>>.HttpGetAsync("course/gets");
            return View(data);
        }
        [Route("/Course/Get/{id}")]
        public IActionResult Detail(int id)
        {
            var result = new CourseView();
            result = ApiHelper<CourseView>.HttpGetByIdAsync(
                                                    $"course/get",id
                                                );
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(SaveCourseReq request)
        {
            if (ModelState.IsValid)
            {
                ApiHelper<CourseView>.HttpPutAsync("course/update", request);
                return RedirectToAction("index");
            }
           ModelState.AddModelError("", "Something went wrong! Please try again later");
            return View(request);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = new SaveCourseReq();
            result = ApiHelper<SaveCourseReq>.HttpGetByIdAsync(
                                                    $"course/get", id
                                                );
            var course = new SaveCourseReq()
            {
                CourseId = result.CourseId,
                CourseName = result.CourseName,
                EndDate = result.EndDate,
                StartDate = result.StartDate,
                Status = result.Status
            };
            return View(course);
        }

    }
}
