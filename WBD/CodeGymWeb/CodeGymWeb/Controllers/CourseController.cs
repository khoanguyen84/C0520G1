﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeGymWeb.Models.Course;
using CodeGymWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeGymWeb.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiHelper<List<CourseView>>.HttpGetAsync("course/gets");
            return View(data);
        }
        [Route("/Course/Get/{id}")]
        public IActionResult Detail(int id)
        {
            var result = new CourseView();
            result = ApiHelper<CourseView>.HttpGetByIdAsync(
                                                    $"course/get",id
                                                );
            return View(result);
        }
    }
}
