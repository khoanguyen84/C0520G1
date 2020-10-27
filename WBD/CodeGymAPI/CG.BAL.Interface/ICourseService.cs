using CG.Domain.Request;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<SaveCourseResult> Save(SaveCourseRequest request);
        Task<CourseView> Get(int id);
    }
}
