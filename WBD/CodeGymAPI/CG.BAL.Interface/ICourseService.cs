using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<CourseView> Get(int id);
        Task<CourseNotFound> Delete(int id);
        Task<CourseNotFound> Completed(int id);
        Task<CourseNotFound> Actived(int id);
        Task<SaveCourseRes> Save(SaveCourseReq request);
    }
}
