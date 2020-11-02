using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request.Course;
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

        [HttpPost, HttpPatch]
        [Route("api/course/save")]
        public async Task<OkObjectResult> SaveCourse(SaveCourseReq request)
        {
            var result = await courseService.Save(request);
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/course/changeStatus/{id}/{status}")]
        public async Task<OkObjectResult> changeStatus(int id, int status)
        {
            var result = await courseService.ChangeStatus(id, status);
            return Ok(result);
        }
    }
}
