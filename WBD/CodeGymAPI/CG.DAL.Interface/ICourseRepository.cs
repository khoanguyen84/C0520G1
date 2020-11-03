using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<SaveCourseRes> Save(SaveCourseReq request);

        Task<CourseView> GetCourseById(int courseId);
        Task<CourseNotFound> SaveCourse(CourseSaveRequest request);
    }
}
