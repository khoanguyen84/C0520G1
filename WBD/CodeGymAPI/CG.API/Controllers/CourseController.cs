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
    //[Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        /// <summary>
        /// Get all Courses with status is inprocess
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/course/gets")]
        public async Task<IEnumerable<CourseView>> GetCourses()
        {
            return await courseService.Gets();
        }
        /// <summary>
        /// Get Course By Id is inprocess
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("api/course/GetCourseById/{Id}")]
        public async Task<CourseView> GetCourse(int Id)
        {
            return await courseService.GetCourseById(Id);
        }
    }
}
