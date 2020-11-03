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
    //[Route("api/[controller]")]
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
        [HttpPost, HttpPatch]
        [Route("api/course/save")]
        public async Task<OkObjectResult> SaveCourse(SaveCourseReq request)
        {
            var result = await courseService.Save(request);
            return Ok(result);
        }
        [HttpPost("api/course/delete/{id}")]
        public async Task<CourseNotFound> Delete(int id)
        {
            return await courseService.ChangeStatusCourse(id, 4);
        }
        [HttpPost("api/course/active/{id}")]
        public async Task<CourseNotFound> Active(int id)
        {
            return await courseService.ChangeStatusCourse(id, 1);
        }
        [HttpPut("api/course/complete/{id}")]
        public async Task<CourseNotFound> Complete(int id)
        {
            return await courseService.ChangeStatusCourse(id, 2);
        }
        [HttpGet("api/course/get/{courseId}")]
        public async Task<OkObjectResult> Get(int courseId)
        {
            var courses = await courseService.GetCourseById(courseId);
            return Ok(courses);
        }
    }
}
