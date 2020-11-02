using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeGymWeb.Models.Module;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

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
    }
}
