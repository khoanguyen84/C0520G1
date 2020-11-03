using CodeGymWeb.Models.Course;
using CodeGymWeb.Models.Wiki;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeGymWeb.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiHelper<List<CourseView>>.HttpGetAsync("course/gets");
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = ApiHelper<CourseView>.HttpGetAsync(@$"course/get/{id}");
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
            //var result = new SaveCourseRes();
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
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View(req);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = ApiHelper<SaveCourseReq>.HttpGetAsync(@$"course/get/{id}");
            return View(data);
        }
        [HttpPost]
        public  IActionResult Edit(SaveCourseReq req)
        {
            var result = new SaveCourseRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "PATCH", req);
                if (result.CourseId != 0)
                {
                    TempData["Message"] = "Course Edited";
                    return Redirect($@"~/Course/Details/{result.CourseId}");
                }
                ModelState.AddModelError("", result.Message);

            }
            return View(req);

        }

        //[HttpPost]
        public  IActionResult ChangeSTT(int Id)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPatchAsync($@"course/ChangeStatus/{Id}");

            if (result != null)
            {
                TempData["Message"] = result.Message;
                return Ok(true);
            }
            TempData["Message"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult IsCompleted(int Id)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPatchAsync($@"course/IsComplete/{Id}");

            if (result != null)
            {
                TempData["Message"] = result.Message;
                return Ok(true);
            }
            TempData["Message"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCourse(int Id)
        {
            var result = ApiHelper<SaveCourseRes>.HttpPatchAsync($@"course/Delete/{Id}");

            if (result != null)
            {
                TempData["Message"] = result.Message;
                return Ok(true);
            }
            TempData["Message"] = result.Message;
            return RedirectToAction("Index");
        }

    }
}
