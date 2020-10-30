using CodeGymWeb.Models.Course;
using CodeGymWeb.Models.Wiki;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeGymWeb.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiHelper<List<CourseView>>.HttpGetAsync("course/gets");
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SaveCourseReq req)
        {
            var result = new SaveCourseRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "POST", req);
                if (result.CourseId != 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(req);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = ApiHelper<SaveCourseReq>.HttpGetAsync($"course/GetCourseById/{id}");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(SaveCourseReq req)
        {
            if (ModelState.IsValid)
            {
                var result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "PATCH", req);
                if (result.CourseId != 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(req);
        }
        [Route("/course/GetCourseById/{id}")]
        public IActionResult Detail(int id)
        {
            var data = ApiHelper<CourseView>.HttpGetAsync($"course/GetCourseById/{id}");
            return View(data);
        }
    }
}
