﻿using CG.Domain.Request;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<SaveCourseResult> Save(SaveCourseRequest request);
        Task<SaveCourseResult> Update(SaveCourseRequest request);
        Task<CourseView> Get(int id);
    }
}
