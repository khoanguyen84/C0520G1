using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Teacher;
using CG.Domain.Response.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository  teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public Task<Teacher> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<TeacherResult> GetStatusTeacherById(int Id, int Status)
        {
            return await teacherRepository.GetStatusTeacherById(Id, Status);
        }

        public async Task<TeacherSaveResult> Save(Teacher teacher)
        {
            return await teacherRepository.Save(teacher);
        }

        public Task<Teacher> TeacherById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
