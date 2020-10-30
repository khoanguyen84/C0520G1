using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using CodeGymWeb.Models.Course;
using CodeGymWeb.Models.Module;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeGymWeb.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiHelper<List<ModuleView>>.HttpGetAsync("Module/gets");
            return View(data);
        }
    }
}
