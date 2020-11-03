using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<CourseView> GetCourse(int id);
        Task<CourseNotFound> CreateCourse(CreateCourse request);
        Task<CourseNotFound> DeleteCourse(int id);
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<CourseNotFound> ActiveCourse(int id);
        Task<CourseNotFound> CompleteCourse(int id);
    }
}
