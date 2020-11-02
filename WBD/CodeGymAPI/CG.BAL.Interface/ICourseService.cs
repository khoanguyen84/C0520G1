using CG.Domain.Request;
﻿using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseView>> Gets();
        Task <SaveCourseRes> ChangeStatus(int id) ;
        Task<CourseView> Get(int id);
        Task<SaveCourseRes> Save(SaveCourseReq request);
        Task<SaveCourseRes> DeleteCourse(int id);
        Task<SaveCourseRes> IsCompleted(int id);
    }
}
