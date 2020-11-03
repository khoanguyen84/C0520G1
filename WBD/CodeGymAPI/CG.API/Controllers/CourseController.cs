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

        /// <summary>
        /// Save or upd
        /// <param name=ate course
        /// </summary>"request"></param>
        /// <returns></returns>
        [HttpPost, HttpPatch]
        [Route("api/course/save")]
        public async Task<OkObjectResult> SaveCourse(SaveCourseReq request)
        {
            var result = await courseService.Save(request);
            return Ok(result);
        }

        [HttpGet("api/course/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var course = await courseService.Get(id);
            return Ok(course);
        }

        [HttpPatch]
        [Route("api/course/delete/{id}")]
        public async Task<OkObjectResult> Delete(int id)
        {
            var result = await courseService.Delete(id);
            return Ok(result);
        }


        [HttpPatch]
        [Route("api/course/completeCourse/{id}")]
        public async Task<OkObjectResult> CompleteCourse(int id)
        {
            var result = await courseService.CompleteCourse(id);
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/course/PendingCourse/{id}")]
        public async Task<OkObjectResult> PendingCourse(int id)
        {
            var result = await courseService.PendingCourse(id);
            return Ok(result);
        }
    }
}
