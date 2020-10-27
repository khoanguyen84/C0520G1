using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Response.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<IEnumerable<StudentView>> GetStudents()
        {
            return await studentRepository.GetStudents();
        }
    }
}
