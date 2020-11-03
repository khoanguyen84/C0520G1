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
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<ChangeStatusRes> ChangeStatusCourse(int courseId, int status, int modifiedBy = 1);
    }
}
