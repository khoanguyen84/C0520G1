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
        public async Task<OkObjectResult> Gets()
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
        [HttpPatch]
        [Route("api/course/ChangeCourseStatusToInProcess/{id}")]
        public async Task<OkObjectResult> ChangeCourseStatusToInProcess(int id)
        {
            var result = await courseService.ChangeStatusToInProcess(id);
            return Ok(result);
        }
        [HttpPatch]
        [Route("api/course/ChangeStatusToCompleted/{id}")]
        public async Task<OkObjectResult> ChangeStatusToCompleted(int id)
        {
            var result = await courseService.ChangeStatusToCompleted(id);
            return Ok(result);
        }
        [HttpPatch]
        [Route("api/course/delete/{id}")]
        public async Task<OkObjectResult> DeleteCourse(int id)
        {
            var result = await courseService.Delete(id);
            return Ok(result);
        }
    }
}
