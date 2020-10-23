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
        public int CreateTeacher(CreateTeacher request)
        {
            return teacherRepository.CreateTeacher(request);
        }

        public IEnumerable<TeacherView> Gets()
        {
            return teacherRepository.Gets();
        }
    }
}
