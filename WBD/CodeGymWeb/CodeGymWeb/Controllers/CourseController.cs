﻿using CodeGymWeb.Models.Course;
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
        public IActionResult Create() => View(new SaveCourseReq()
        {
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
                    return RedirectToAction("index");

                ModelState.AddModelError("", result.Message);
            }
            req.Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View(req);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SaveCourseReq saveCourseReq = ApiHelper<SaveCourseReq>.HttpGetAsync($"course/get/{id}");
            saveCourseReq.Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View(saveCourseReq);
        }

        [HttpPost]
        public IActionResult Edit(SaveCourseReq req)
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

        public IActionResult ToInProcess(int id, SaveCourseReq req)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPostAsync($"course/ChangeCourseStatus/{id}/1", "Patch", req);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id, SaveCourseReq req)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPostAsync($"course/ChangeCourseStatus/{id}/4", "Patch", req);
            return RedirectToAction("index");
        }

        public IActionResult ToCompleted(int id, SaveCourseReq req)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPostAsync($"course/ChangeCourseStatus/{id}/2", "Patch", req);
            return RedirectToAction("index");
        }
    }
}
