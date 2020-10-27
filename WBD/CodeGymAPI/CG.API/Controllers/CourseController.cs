﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request;
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
        /// Create a new course
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/course/save")]
        public async Task<SaveCourseResult> Save(SaveCourseRequest request)
        {
            return await courseService.Save(request);

        }
        [HttpGet("api/course/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var courses = await courseService.Get(id);
            if(courses != null)
            {
                
                return Ok(courses);
            }
           else
            {
                var result =  new SaveCourseResult()
                {
                    CourseId = 0,
                    Message = "Id not found"
                };
                return Ok(result.Message);
            }
            
        }



    }
}
