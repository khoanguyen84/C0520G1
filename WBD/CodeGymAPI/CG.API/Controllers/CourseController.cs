using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Response.Course;
using CG.Domain.Response.Module;
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
        [HttpGet]
        [Route("api/course/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var status = await courseService.Get(id);
            if (status.CourseName != null)
                return Ok(status);

            return Ok(new NotFound()
            {
                ID = id,
                ErrorMessage = "Not Found !"
            });
        }
    }
}
