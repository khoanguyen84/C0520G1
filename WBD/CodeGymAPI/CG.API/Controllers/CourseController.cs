using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Response.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
   
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
     
        [HttpGet("api/course/gets")]
        public async Task<OkObjectResult> GetCourses()
        {
            var courses = await courseService.Gets();
            return Ok(courses);
        }

        [HttpGet("api/course/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var course = await courseService.Get(id);
            return Ok(course);
        }
    }
}
