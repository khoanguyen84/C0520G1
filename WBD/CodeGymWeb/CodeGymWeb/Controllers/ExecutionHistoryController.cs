using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeGymWeb.Models.ExHis;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace CodeGymWeb.Controllers
{
    public class ExecutionHistoryController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiHelper<List<ExecutionHistoryView>>.HttpGetAsync("executionhistory/gets");
            return View(data);
        }
    }
}
