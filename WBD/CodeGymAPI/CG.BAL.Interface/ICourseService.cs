using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        IEnumerable<CourseView> Gets();
    }
}
