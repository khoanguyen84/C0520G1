using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request;
using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using CG.Domain.Response.Module;
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

        public async Task<CourseView> GetCourseById(int courseId)
        {
            return await courseRepository.GetCourseById(courseId);
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await courseRepository.Gets();
        }

        public async Task<SaveCourseRes> Save(SaveCourseReq request)
        {
            return await courseRepository.Save(request);
        }

        public async Task<SaveCourseRes> SaveCourse(SaveCourseReq request)
        {
            return await courseRepository.SaveCourse(request);
        }
        public async Task<SaveCourseRes> ChangeStatusCourse(int courseId, int status, int modifiedBy = 1)
        {
            return await courseRepository.ChangeStatusCourse(courseId, status);
        }
    }
}
