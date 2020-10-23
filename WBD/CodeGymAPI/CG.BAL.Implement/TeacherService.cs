using CG.BAL.Interface;
using CG.DAL.Interface;
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
        public async Task<IEnumerable<TeacherView>> GetTeacher()
        {
            return await teacherRepository.GetTeacher();
        }
    }
}
