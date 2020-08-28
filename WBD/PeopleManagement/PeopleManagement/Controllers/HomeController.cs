using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleManagement.Models;
using PeopleManagement.Models.Entities;
using PeopleManagement.Models.ViewModels;
using PeopleManagement.Services;

namespace PeopleManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPeopleService peopleService;
        private const int defaultProvinceId = 15;
        private const int defaultDistrictId = 194;
        public HomeController(ILogger<HomeController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            RegisterView model = Gets();
            return View(model);
        }
        /// <summary>
        /// Html Hepler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Show()
        {
            return View(Gets());
        }

        [HttpPost]
        public IActionResult Show(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                var people = new People()
                {
                    Address = model.Address,
                    DistrictId = model.DistrictId,
                    Email = model.Email,
                    Fullname = model.Fullname,
                    Password = model.Password,
                    ProvinceId = model.ProvinceId,
                    PhoneNumber = model.PhoneNumber,
                    WardId = model.WardId
                };
                if (peopleService.SavePeople(people) > 0)
                {
                    return RedirectToAction("Show", "Home");
                }
            }
            return View(Gets());
        }

        private RegisterView Gets()
        {
            var model = new RegisterView();
            model.Provinces = peopleService.GetProvinces();
            model.Districts = peopleService.GetDistricts(defaultProvinceId);
            model.Wards = peopleService.GetWards(defaultProvinceId, defaultDistrictId);
            model.WardId = model.Wards.FirstOrDefault().id;
            model.DistrictId = defaultDistrictId;
            model.ProvinceId = defaultProvinceId;
            return model;
        }

        [HttpPost]
        public IActionResult Index(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                var people = new People()
                {
                    Address = model.Address,
                    DistrictId = model.DistrictId,
                    Email = model.Email,
                    Fullname = model.Fullname,
                    Password = model.Password,
                    ProvinceId = model.ProvinceId,
                    PhoneNumber = model.PhoneNumber,
                    WardId = model.WardId
                };
                if (peopleService.SavePeople(people) > 0)
                {
                    return RedirectToAction("List", "Home");
                }
            }
            return View(Gets());
        }

        public IActionResult ChangeProvince(int id)
        {
            var districts = peopleService.GetDistricts(id);
            var districtId = districts.FirstOrDefault().id;
            var wards = peopleService.GetWards(id, districtId);
            var result = new ProvinceView();
            result.Districts = districts;
            result.Wards = wards;
            return Json(new { result });
        }

        [Route("/Home/ChangeDistrict/{provinceId}/{districtId}")]
        public JsonResult ChangeDistrict(int provinceId, int districtId)
        {
            var wards = peopleService.GetWards(provinceId, districtId);
            return Json(new { wards });
        }

        public IActionResult List()
        {
            var people = peopleService.GetPeople();
            return View(people);
        }
    }
}
