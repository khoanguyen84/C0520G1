using CG.Domain.Response.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentView>> GetStudents();
    }
}
