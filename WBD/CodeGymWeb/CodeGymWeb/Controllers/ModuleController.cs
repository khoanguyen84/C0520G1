﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeGymWeb.Models.Module;
using CodeGymWeb.Models.Wiki;
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

        [HttpGet]
        [Route("/module/get/{id}")]
        public JsonResult Get(int id)
        {
            var result = ApiHelper<ModuleView>.HttpGetAsync($"module/get/{id}");
            return Json(new { result });
        }

        [Route("/module/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = ApiHelper<DeleteModuleResult>.HttpGetAsync($"module/delete/{id}");
            return Json(new { result });
        }

        [HttpGet]
        [Route("/module/detail/{id}")]
        public JsonResult Detail(int id)
        {
            var result = ApiHelper<ModuleView>.HttpGetAsync($"module/get/{id}");
            return Json(new { result });
        }
    }
}
