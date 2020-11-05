using CG.DAL.Interface;
using CG.Domain.Response.Student;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public async Task<IEnumerable<StudentView>> GetStudentByCourseId(int courseId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", courseId);
            return await SqlMapper.QueryAsync<StudentView>(cnn: connection,
                                                        sql: "sp_GetStudentsByCourseId",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);

        }
    }
}
