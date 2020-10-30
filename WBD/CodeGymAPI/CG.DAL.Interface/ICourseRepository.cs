using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<CourseView> GetCourse(int id);
        Task<CourseNotFound> CreateCourse(CreateCourse request);
        //Task<CourseNotFound> EditTeacher(EditTeacher request);
        Task<CourseNotFound> DeleteCourse(int id);
        Task<SaveCourseRes> Save(SaveCourseReq request);
    }
}
