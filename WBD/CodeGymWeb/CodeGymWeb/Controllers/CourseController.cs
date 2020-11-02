using CodeGymWeb.Models.Course;
using CodeGymWeb.Models.Wiki;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var data = ApiHelper<CourseView>.HttpGetAsync($"course/gets/{id}");
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            TempData["thanhcong"] = null;
            TempData["loi"] = null;
            return View();
        }
        [HttpPost]
        public IActionResult Create(SaveCourseReq model)
        {
            var data = ApiHelper<SaveCourseReq>.HttpPostAsync("course/save",model);
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            if(data.CourseId >0)
                TempData["thanhcong"] = data.Message;
            else
                TempData["loi"] = data.Message;

            return View(model);
        }
        public IActionResult Delete(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/Delete/{id}", model);
            return RedirectToAction("index");
        }
        public IActionResult Active(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/Active/{id}", model);
            return RedirectToAction("index");
        }
        public IActionResult Complete(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/Complete/{id}", model);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            var data = ApiHelper<SaveCourseReq>.HttpGetAsync($"course/gets/{id}");
            TempData["thanhcong"] = null;
            TempData["loi"] = null;
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(SaveCourseReq model)
        {
            ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            var data = ApiHelper<SaveCourseRes>.HttpPostAsync("Course/save", "PATCH", model);
            if(data.CourseId!=0)
                TempData["thanhcong"] = data.Message;
            else
                TempData["loi"] = data.Message;
            return View(model);
        }
    }
}
