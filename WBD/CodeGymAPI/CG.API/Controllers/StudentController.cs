using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>
        [HttpGet("/api/student/getbycourseid/{courseid}")]
        public async Task<OkObjectResult> GetStudentByCourseId(int courseid)
        {
            return Ok(await studentService.GetStudentByCourseId(courseid));
        }
    }
}
