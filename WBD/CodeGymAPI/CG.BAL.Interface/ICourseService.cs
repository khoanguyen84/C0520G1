using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<CourseView> GetCourseById(int Id);
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<NotFound> ChangeInprocess(int Id);
        Task<NotFound> ChangeCompleted(int Id);
        Task<NotFound> ChangeDeleted(int Id);
    }
}
