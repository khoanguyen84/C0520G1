using CG.DAL.Interface;
using CG.Domain.Response.Course;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public async Task<CourseView> GetCourseById(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", Id);
            var result = await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourseById",
                                                        parameters,
                                                        commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            var result =  await SqlMapper.QueryAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourses",
                                                        commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
