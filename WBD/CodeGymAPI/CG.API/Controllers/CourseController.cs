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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/course/GetCourseById/{id}")]
        public async Task<OkObjectResult> GetCourseById(int id)
        {
            var status = await courseService.GetCourseById(id);
            if (status.CourseName != null)
                return Ok(status);

            return Ok(new NotFound()
            {
                CourseId = id,
                Message = "Not Found !"
            });
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
        [HttpPut("api/course/inprocess/{Id}")]
        public async Task<NotFound> ChangeInprocess(int Id)
        {
            return await courseService.ChangeInprocess(Id);
        }
        [HttpPut("api/course/completed/{Id}")]
        public async Task<NotFound> ChangeCompleted(int Id)
        {
            return await courseService.ChangeCompleted(Id);
        }
        [HttpPut("api/course/deleted/{Id}")]
        public async Task<NotFound> ChangeDeleted(int Id)
        {
            return await courseService.ChangeDeleted(Id);
        }
    }
}
