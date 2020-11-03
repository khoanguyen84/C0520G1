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
        public IActionResult Detail(int id)
        {
            var data = ApiHelper<CourseView>.HttpGetAsync($"course/get/{id}");
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseSaveRequest request)
        {
            if (ModelState.IsValid)
            {

                var result = ApiHelper<CourseNotFound>.HttpPostAsync($"course/save", request);
                if (result.Message == "Course Name created successfully")
                {
                    return RedirectToAction("Index", "Course");
                }
                ViewData["Message"] = result.Message;
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = ApiHelper<CourseView>.HttpGetAsync($"course/get/{id}");
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(CourseSaveRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = ApiHelper<CourseNotFound>.HttpPostAsync($"course/save", request);
                //if (result.Message == "Course Name updated successfully")
                //{
                //    return RedirectToAction("Index", "Course");
                //}
                ViewData["Message"] = result.Message;
            }

            return View();
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
    }
}
