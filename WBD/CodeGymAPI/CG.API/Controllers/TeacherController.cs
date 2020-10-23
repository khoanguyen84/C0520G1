using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request;
using CG.Domain.Response.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        [Route("api/Teacher/Gets")]
        public IEnumerable<TeacherView> Gets()
        {
            return teacherService.Gets();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Teacher/CreateTeacher")]
        public int CreateTeacher([FromBody] CreateTeacher request)
        {
            var id = teacherService.CreateTeacher(request);
            return id;
        }
    }
}
