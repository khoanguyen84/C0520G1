using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Course;
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

        public async Task<NotFound> ChangeCompleted(int Id)
        {
            return await courseRepository.ChangeCompleted(Id);
        }

        public async Task<NotFound> ChangeDeleted(int Id)
        {
            return await courseRepository.ChangeDeleted(Id);
        }

        public async Task<NotFound> ChangeInprocess(int Id)
        {
            return await courseRepository.ChangeInprocess(Id);
        }

        public async Task<CourseView> GetCourseById(int Id)
        {
            return await courseRepository.GetCourseById(Id);
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await courseRepository.Gets();
        }

        public async Task<SaveCourseRes> Save(SaveCourseReq request)
        {
            return await courseRepository.Save(request);
        }
    }
}
