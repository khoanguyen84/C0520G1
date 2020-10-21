using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;

namespace CG.DAL.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<CourseView> Gets();
    }
}
