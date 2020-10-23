using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CG.Web.Models;
using CG.Domain.Response.Course;
using CG.Web.Ultilities;

namespace CG.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        public JsonResult Get(int courseId)
        {
            var course = new CourseView();
            course = ApiHelper<CourseView>.HttpGetAsync(
                                                    $"{Helper.ApiUrl}api/course/get/{courseId}"
                                                );
            return Json(new { course });
        }

    }
    }
}
