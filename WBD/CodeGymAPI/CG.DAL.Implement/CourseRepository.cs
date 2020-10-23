using CG.DAL.Interface;
using CG.Domain.Request.Course;
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
        public async Task<CourseView> Get(int courseId)
        {
            return await SqlMapper.QueryFirstAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCoursesById",
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await SqlMapper.QueryAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourses",
                                                        commandType: CommandType.StoredProcedure);

            //var query = "SELECT [CourseId],[CourseName],[Status],[StartDate],[EndDate] FROM[dbo].[Course] WHERE[Status] = 1";
            //var result = await SqlMapper.QueryAsync<CourseView>(cnn: connection,
            //                                                    sql: query,
            //                                                    commandType: CommandType.Text);
            //return result;
        }

        public int Update(UpdateCourse request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.CourseId);
                parameters.Add("@CourseName", request.CourseName);
                parameters.Add("@Status", request.Status);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                var id =SqlMapper.ExecuteScalar<int>(connection, "UpdateCourse", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
