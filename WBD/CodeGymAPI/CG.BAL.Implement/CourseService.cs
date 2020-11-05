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

        public  async Task<SaveCourseRes> ChangeStatus(int id)
        {
            return await courseRepository.ChangeStatus(id);
        }

        public async Task<SaveCourseRes> DeleteCourse(int id)
        {
            return await courseRepository.DeleteCourse(id);
        }

        public async Task<CourseView> Get(int id)
        {
            return await courseRepository.Get(id);
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await courseRepository.Gets();
        }

        public async Task<SaveCourseRes> IsCompleted(int id)
        {
            return await courseRepository.IsCompleted(id);
        }

        public async Task<SaveCourseRes> Save(SaveCourseReq request)
        {
            return await courseRepository.Save(request);
        }
    }
}
