using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.DAL.Interface;
using Coffee.Domain.Request.Table;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Web.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableRepository tableRepository;

        public TableController(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTableReq request)
        {
            return View();
        }
    }
}
