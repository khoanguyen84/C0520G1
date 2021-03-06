﻿using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Response.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await courseRepository.Gets();
        }
    }
}
