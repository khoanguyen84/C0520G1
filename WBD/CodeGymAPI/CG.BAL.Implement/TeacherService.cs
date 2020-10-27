using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request;
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

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public async Task<DeleteTeacher> CreateTeacher(CreateTeacher request)
        {
            return await teacherRepository.CreateTeacher(request);
        }

        public async Task<DeleteTeacher> DeleteTeacher(int id)
        {
            return await teacherRepository.DeleteTeacher(id);
        }

        public async Task<DeleteTeacher> EditTeacher(EditTeacher request)
        {
            return await teacherRepository.EditTeacher(request);
        }

        public async Task<IEnumerable<TeacherView>> Gets()
        {
            return await teacherRepository.Gets();
        }

        public async Task<TeacherView> GetTeacher(int id)
        {
            return await teacherRepository.GetTeacher(id);
        }
    }
}
