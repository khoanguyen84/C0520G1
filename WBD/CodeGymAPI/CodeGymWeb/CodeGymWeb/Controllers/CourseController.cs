using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeGymWeb.Models;
using CodeGymWeb.Models.Course;
using System.Net;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeGymWeb.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var courses = new List<CourseView>();
            var url = $"{Common.Common.ApiUrl}/course/gets";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var reponse = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = reponse.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                courses = JsonConvert.DeserializeObject<List<CourseView>>(responseData);
            }
            return View(courses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Detail(int id)
        {
            var course = new GetCourse();
            var url = $"{Common.Common.ApiUrl}/course/GetCourseById/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var reponse = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = reponse.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                course = JsonConvert.DeserializeObject<GetCourse>(responseData);
            }
            return View(course);
        }
            
    }
}
