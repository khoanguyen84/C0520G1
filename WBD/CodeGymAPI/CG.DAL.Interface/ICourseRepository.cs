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
        //Task<CourseView> Get(int courseId);
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<CourseView> GetCourseById(int Id);
        Task<NotFound> ChangeInprocess(int Id);
        Task<NotFound> ChangeCompleted(int Id);
        Task<NotFound> ChangeDeleted(int Id);
    }
}
