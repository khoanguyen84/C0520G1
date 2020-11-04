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
        public IActionResult Details(int id)
        {
            var data = ApiHelper<CourseView>.HttpGetAsync($"course/get/{id}");
            return View(data);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            var data = ApiHelper<SaveCourseReq>.HttpGetAsync($"course/get/{id}");
            TempData["thanhcong"] = null;
            TempData["loi"] = null;
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(SaveCourseReq model)
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            var data = ApiHelper<SaveCourseRes>.HttpPostAsync("Course/save", "PATCH", model);
            if (data.CourseId != 0)
                TempData["thanhcong"] = data.Message;
            else
                TempData["loi"] = data.Message;
            return View(model);
        }
        public IActionResult Delete(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"Course/Delete/{id}", model);
            return RedirectToAction("Index");
        }
        public IActionResult Complete(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/Complete/{id}", model);
            return RedirectToAction("Index");
        }
        public IActionResult Active(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/Active/{id}", model);
            return RedirectToAction("Index");
        }
    }
}
