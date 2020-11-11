using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Student;
using CG.Domain.Response.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;

        public StudentService(IStudentRepository studentRepository,
                                ICourseRepository courseRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<StudentOfCourseId> Get(int studentId)
        {
            return await studentRepository.Get(studentId);
        }

        public async Task<Students> GetStudentByCourseId(int courseId)
        {
            var students = new Students();
            students.StudentList = await studentRepository.GetStudentByCourseId(courseId);
            var course = await courseRepository.Get(courseId);
            students.CourseName = course.CourseName;
            return students;
        }

        public async Task<SaveStudentRes> Save(SaveStudentReq request)
        {
            return await studentRepository.Save(request);
        }

    }
}
