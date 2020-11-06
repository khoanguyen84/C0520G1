using CodeGymWeb.Models.Module;
using CodeGymWeb.Models.Wiki;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeGymWeb.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/module/gets")]
        public JsonResult Gets()
        {
            var modules = ApiHelper<List<ModuleView>>.HttpGetAsync("module/gets");
            return Json(new { data = modules });
        }
        public IActionResult Detail(int id)
        {
            var data = ApiHelper<ModuleView>.HttpGetAsync($"module/get/{id}");
            return View(data);
        }

        [HttpGet]
        [Route("/module/status/gets")]
        public JsonResult GetStatus()
        {
            var status = ApiHelper<List<Status>>.HttpGetAsync($"wiki/status/{(int)Common.Table.Module}");
            return Json(new { data = status });
        }

        [HttpPost]
        [Route("/module/save")]
        public JsonResult Save([FromBody] SaveModule request)
        {
            var result = ApiHelper<SaveModuleResult>.HttpPostAsync($"module/save", "POST", request);
            return Json(new { data = result });
        }

     
        public IActionResult Delete(int id, SaveModule req)
        {
            var result = ApiHelper<SaveModuleResult>.HttpPostAsync($"module/changeModuleStatus/{id}/4", "Patch", req);
            return RedirectToAction("index");
        }

    }
}
