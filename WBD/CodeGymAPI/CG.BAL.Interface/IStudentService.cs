using CG.Domain.Response.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentView>> GetStudents();
    }
}
