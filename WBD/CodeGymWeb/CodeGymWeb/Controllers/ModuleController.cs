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
            var data = ApiHelper<List<ModuleView>>.HttpGetAsync("module/gets");
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = ApiHelper<ModuleView>.HttpGetAsync($"module/get/{id}");
            return View(data);
        }
    }
}
