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
            TempData["success"] = null;
            TempData["error"] = null;
            SaveCourseReq result = new SaveCourseReq()
            {
                Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}")
            };
            return View(result);
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    TempData["success"] = null;
        //    TempData["error"] = null;
        //    ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
        //    return View();
        //} --su dung view bag

        //[HttpGet]
        //public IActionResult Create() => View(new SaveCourseReq()
        //{
        //    Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}")
        //});--strongly typed view =>


        [HttpPost]
        public IActionResult Create(SaveCourseReq req)
        {
            //ViewBag.Status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}"); viewbag;
            var result = new SaveCourseRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "POST", req);
                if(result.CourseId != 0)
                {
                    TempData["success"] = result.Message;
                }    
                else
                {
                    TempData["error"] = result.Message;
                }    
            }
            req.Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}"); //strongly typed view
            return View(req);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TempData["success"] = null;
            TempData["error"] = null;
            var data = ApiHelper<SaveCourseReq>.HttpGetAsync($"course/GetCourseById/{id}");
            data.Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(SaveCourseReq req)
        {
            var result = new SaveCourseRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCourseRes>.HttpPostAsync("course/save", "PATCH", req);
                if(result.CourseId != 0)
                {
                    TempData["success"] = result.Message;
                }    
                else
                {
                    TempData["error"] = result.Message;
                }  
            }
            req.Statuses = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Course}");
            return View(req);
        }
        [Route("/course/GetCourseById/{id}")]
        public IActionResult Detail(int id)
        {
            var data = ApiHelper<CourseView>.HttpGetAsync($"course/GetCourseById/{id}");
            return View(data);
        }
        [Route("course/completed/{id}")]
        public IActionResult Completed(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/completed/{id}", model);
            return RedirectToAction("Index");
        }
        [Route("course/inprocess/{id}")]
        public IActionResult Inprocess(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/inprocess/{id}", model);
            return RedirectToAction("Index");
        }
        [HttpPut]
        [Route("course/deleted/{id}")]
        public IActionResult Deleted(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/deleted/{id}", model);
            return RedirectToAction("Index");
        }
    }
}
