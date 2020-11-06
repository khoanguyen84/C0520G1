﻿using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseView>> Gets();
        Task<CourseView> Get(int courseId);
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<CourseView> Get(int id);
        Task<CourseNotFound> Delete(int id);
        Task<CourseNotFound> Completed(int id);
        Task<CourseNotFound> Actived(int id);
    }
}
