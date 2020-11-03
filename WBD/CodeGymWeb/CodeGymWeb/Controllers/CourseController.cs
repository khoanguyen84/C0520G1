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

        [HttpGet]
        public IActionResult Create()
        {
            //var course = new SaveCourseReq()
            //{
            //    statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course},{false}")
            //};
            //return View(course);
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course},{false}");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SaveCourseReq req)
        {
            if (ModelState.IsValid)
            {
                var result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "POST", req);
                if (result.CourseId != 0)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
            }
            //req.statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course},{false}");
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course},{false}");
            return View(req);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = ApiHelper<CourseView>.HttpGetAsync(@$"course/get/{id}");
            var result = new SaveCourseReq()
            {
                CourseId = data.CourseId,
                CourseName = data.CourseName,
                Status = data.Status,
                StartDate = data.StartDate,
                EndDate = data.EndDate
            };
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync(@$"wiki/status/{(int)Common.Table.Course},{true}");
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(SaveCourseReq req)
        {
            if (ModelState.IsValid)
            {
                var result = ApiHelper<SaveCourseRes>.HttpPostAsync(@$"course/save", "PATCH", req);
                if (result.CourseId != 0)
                {
                    TempData["Message"] = result.Message;
                    return Redirect(@$"~/Course/Details/{result.CourseId}");
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync(@$"wiki/status/{(int)Common.Table.Course},{true}");
            return View(req);
        }
        [HttpPatch]
        public IActionResult Delete(int id)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPatchAsync(@$"course/delete/{id}");
            if (result != null)
            {
                TempData["Message"] = result.Message;
                return Ok(true);
            }
            TempData["Message"] = result.Message;
            return Ok(false);
        }
        [HttpPatch]
        public IActionResult ChangeCourseStatusToInProcess(int id)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPatchAsync(@$"course/ChangeCourseStatusToInProcess/{id}");
            if (result != null)
            {
                TempData["Message"] = result.Message;
                return Ok(true);
            }
            TempData["Message"] = result.Message;
            return Ok(false);
        }
        [HttpPatch]
        public IActionResult ChangeCourseStatusToCompleted(int id)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPatchAsync(@$"course/ChangeStatusToCompleted/{id}");
            if (result != null)
            {
                TempData["Message"] = result.Message;
                return Ok(true);
            }
            TempData["Message"] = result.Message;
            return Ok(false);
        }
    }
}
