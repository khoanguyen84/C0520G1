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
        public async Task<IEnumerable<TeacherView>> Gets()
        {
            return await teacherService.Gets();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Teacher/Create")]
        public async Task<DeleteTeacher> CreateTeacher([FromBody] CreateTeacher request)
        {
            //var id = teacherService.CreateTeacher(request);
            //if(id == -2)
            //{
            //    return BadRequest("Email already Register");
            //};
            //if (id == -1)
            //{
            //    return BadRequest("PhoneNumber already exists");
            //};
            //return Ok(id);
            return await teacherService.CreateTeacher(request);
        }
        [Route("api/Teacher/Edit")]
        [HttpPut]
        public async Task<DeleteTeacher> Edit([FromBody] EditTeacher request)
        {
            return await teacherService.EditTeacher(request);
        }
        [HttpGet("api/Teacher/Get/{id}")]
        public async Task<TeacherView> Get(int id)
        {
            return await teacherService.GetTeacher(id);
        }
        [HttpPut("api/Teacher/Delete")]
        public async Task<DeleteTeacher> Delete(int id)
        {
            return await teacherService.DeleteTeacher(id);
        }
    }
}
