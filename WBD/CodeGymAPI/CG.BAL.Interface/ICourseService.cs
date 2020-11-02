using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<CourseView> Get(int id);
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<SaveCourseRes> ChangeStatusToInProcess(int id);
        Task<SaveCourseRes> ChangeStatusToCompleted(int id);
        Task<SaveCourseRes> Delete(int id);
    }
}
