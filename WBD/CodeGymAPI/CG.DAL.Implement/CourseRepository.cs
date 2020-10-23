using CG.DAL.Interface;
using CG.Domain.Request;
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
        public int ChangeStatus(UpdateCourse request)
        {
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", request.courseId);                  
                    parameters.Add("@Status", request.Status);                 
                    var id = SqlMapper.ExecuteScalar<int>(connection, "ChangeStatus", param: parameters, commandType: CommandType.StoredProcedure);
                    return id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
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
    }
}
