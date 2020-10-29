using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Teacher;
using CG.Domain.Response.Teacher;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CG.API.Controllers
{
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        private readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherService teacherService,ITeacherRepository teacherRepository)
        {
            this.teacherService = teacherService;
            this.teacherRepository = teacherRepository;
        }

        [HttpGet]
        [Route("/api/teacher/GetstatusteacherbyId/{Id}/{Status}")]
        public async Task<TeacherResult> GetStatusTeacherById(int Id, int Status)
        {
            return await teacherRepository.GetStatusTeacherById(Id, Status);
        }
        [HttpPost]
        [Route("/api/teacher/SaveTeacher")]
        public async Task<TeacherSaveResult> SaveTeacher(Teacher teacher)
        {
            return await teacherRepository.Save(teacher);
        }
        [HttpGet]
        [Route("/api/teacher/GetTeacherById/{Id}")]
        public async Task<Teacher> GetTeacherId(int Id)
        {
            return await teacherRepository.TeacherById(Id);
        }
        [HttpGet]
        [Route("/api/teacher/GetTeacher")]
        public async Task<Teacher> GetTeacher()
        {
            return await teacherRepository.Get();
        }
    }
}
