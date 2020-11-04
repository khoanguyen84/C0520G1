using CodeGymWeb.Models.Course;
using CodeGymWeb.Models.Wiki;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Delete(int id)
        {
            var data = ApiHelper<SaveCourseRes>.HttpPatchAsync($"course/delete/{id}");
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create() => View(new SaveCourseReq()
        {
            StartDate=DateTime.Today,
            EndDate = DateTime.Today,
            Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}")
        });

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
            req.Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");

            return View(req);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            var data = ApiHelper<SaveCourseReq>.HttpGetAsync($"course/get/{id}");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(SaveCourseReq req)
        {
            var result = new SaveCourseRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "PATCH", req);
                if (result.CourseId != 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View(req);
        }

        public IActionResult Complete(int id)
        {
            var data = ApiHelper<CourseView>.HttpPatchAsync($"course/completeCourse/{id}");
            return RedirectToAction("index");
        }


        public IActionResult Pending(int id)
        {
            var data = ApiHelper<CourseView>.HttpPatchAsync($"course/PendingCourse/{id}");
            return RedirectToAction("index");
        }
    }
}
