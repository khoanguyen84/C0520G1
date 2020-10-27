﻿using CG.Domain.Response.Course;
using System;
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
    }
}
