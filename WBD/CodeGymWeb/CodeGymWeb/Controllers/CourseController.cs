using CodeGymWeb.Models.Course;
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
            var data = ApiHelper<CourseView>.HttpGetAsync($"course/gets/{id}");
            return View(data);
        }
        public IActionResult Create()
        {
            TempData["thanhcong"] = null;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPostAsync("course/Create",model);
            var result = ApiHelper<CourseView>.result("course/Create", model);
            var tam = JsonConvert.DeserializeObject<CourseNotFound>(result);
            TempData["thanhcong"] = tam.Message;
            return View(new CourseView());
        }
        public IActionResult Delete(int id, CourseView model)
        {
            var data = ApiHelper<CourseView>.HttpPutAsync($"course/Delete/{id}", model);
            var data1 = ApiHelper<List<CourseView>>.HttpGetAsync("course/gets");
            return View(data1);
        }
    }
}
