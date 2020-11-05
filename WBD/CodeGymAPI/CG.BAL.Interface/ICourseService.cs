using CG.Domain.Request;
using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<CourseView> GetCourseById(int courseId);
        Task<CourseNotFound> SaveCourse(CourseSaveRequest request);
        Task<CourseNotFound> ChangeStatusCourse(int courseId, int status, int modifiedBy = 1);
    }
}
