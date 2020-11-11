using CG.Domain.Request.Course;
using CG.Domain.Request.Module;
using CG.Domain.Request.Student;
using CG.Domain.Response.Course;
using CG.Domain.Response.Module;
using CG.Domain.Response.Student;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentView>> GetStudentByCourseId(int courseId);
        Task<SaveStudentRes> Save(SaveStudentReq request);
        Task<StudentOfCourseId> Get(int studentId);
    }
}
