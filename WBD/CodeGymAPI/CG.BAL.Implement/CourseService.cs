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

        public async Task<CourseNotFound> Actived(int id)
        {
            return await courseRepository.Actived(id);
        }

        public async Task<CourseNotFound> Completed(int id)
        {
            return await courseRepository.Completed(id);
        }

        public async Task<CourseNotFound> Delete(int id)
        {
            return await courseRepository.Delete(id);
        }

        public async Task<CourseView> Get(int id)
        {
            return await courseRepository.Get(id);
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
