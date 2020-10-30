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

        //[Route("/gets")]
        //[HttpGet]
        /// <summary>
        /// Get all Courses with status is inprocess
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/course/gets")]
        public async Task<OkObjectResult> GetCourses()
        {
            var courses = await courseService.Gets();
            return Ok(courses);
        }
        [HttpGet("api/course/gets/{id}")]
        public async Task<OkObjectResult> GetsCourses(int id)
        {
            var status = await courseService.GetCourse(id);
            if (status.CourseName != null)
                return Ok(status);
            return Ok(new CourseNotFound()
            {
                CourseId = id,
                Message = "Not Found !"
            });
        }
        [HttpPost("api/course/Create")]
        public async Task<OkObjectResult> CreateCourse([FromBody] CreateCourse request)
        {
            var courses = await courseService.CreateCourse(request);
            return Ok(courses);
        }
        [HttpPut("api/Course/Delete/{id}")]
        public async Task<CourseNotFound> Delete(int id)
        {
            return await courseService.DeleteCourse(id);
        }

        /// <summary>
        /// Save or update course
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpPatch]
        [Route("api/course/save")]
        public async Task<OkObjectResult> SaveCourse(SaveCourseReq request)
        {
            var result = await courseService.Save(request);
            return Ok(result);
        }
    }
}
