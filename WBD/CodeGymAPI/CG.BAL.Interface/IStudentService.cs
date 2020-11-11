using CG.Domain.Response.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IStudentService
    {
        Task<Students> GetStudentByCourseId(int courseId);
    }
}
