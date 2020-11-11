using CG.Domain.Request.Student;
using CG.Domain.Response.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IStudentService
    {
        Task<Students> GetStudentByCourseId(int courseId);
        Task<SaveStudentRes> Save(SaveStudentReq request);
        Task<StudentOfCourseId> Get(int studentId);
    }
}
