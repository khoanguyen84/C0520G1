using CG.DAL.Interface;
using CG.Domain.Request.Course;
using CG.Domain.Request.Student;
using CG.Domain.Response.Course;
using CG.Domain.Response.Student;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public async Task<StudentOfCourseId> Get(int studentId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentId", studentId);
            return await SqlMapper.QueryFirstOrDefaultAsync<StudentOfCourseId>(cnn: connection,
                                                                        sql: "sp_GetStudentById",
                                                                        param: parameters,
                                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<StudentView>> GetStudentByCourseId(int courseId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", courseId);
            return await SqlMapper.QueryAsync<StudentView>(cnn: connection,
                                                        sql: "sp_GetStudentsByCourseId",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);

        }

        public async Task<SaveStudentRes> Save(SaveStudentReq request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentId", request.StudentId);
            parameters.Add("@Fullname", request.Fullname);
            parameters.Add("@Gender", request.Gender);
            parameters.Add("@Dob", request.Dob);
            parameters.Add("@Email", request.Email);
            parameters.Add("@PhoneNumber", request.PhoneNumber);
            parameters.Add("@Address", request.Address);
            parameters.Add("@Avatar", request.Avatar);
            parameters.Add("@Status", request.Status);
            parameters.Add("@CourseId", request.CourseId);

            return await SqlMapper.QueryFirstOrDefaultAsync<SaveStudentRes>(cnn: connection,
                                                                           sql: "sp_SaveStudent",
                                                                           param: parameters,
                                                                           commandType: CommandType.StoredProcedure);
            
        }
    }
}
