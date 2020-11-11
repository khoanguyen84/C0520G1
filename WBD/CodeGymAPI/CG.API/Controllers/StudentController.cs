using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Implement;
using CG.BAL.Interface;
using CG.Domain.Request.Student;
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
        [HttpPost, HttpPatch]
        [Route("/api/student/save")]
        public async Task<OkObjectResult> Save(SaveStudentReq request)
        {
            var result = await studentService.Save(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/student/get/{id}")]
        public async Task<OkObjectResult> GetStudentById(int id)
        {
            var student = await studentService.Get(id);
            return Ok(student);
        } 

    }
}
