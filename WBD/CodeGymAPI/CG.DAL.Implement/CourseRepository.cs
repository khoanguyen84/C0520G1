using CG.DAL.Interface;
using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using CG.Domain.Response.Module;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public async Task<CourseNotFound> Actived(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            var data = await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(connection, "Active_Course", parameters, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<CourseNotFound> Completed(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            var data = await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(connection, "Complete_Course", parameters, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<CourseNotFound> Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            var data = await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(connection, "Delete_Course", parameters, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<CourseView> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(cnn: connection, sql: "Course_GetByCourseId", param: parameters, commandType: CommandType.StoredProcedure);
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


        public async Task<CourseView> Get(int courseId)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", courseId);
            return await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourse",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }


        public async Task<SaveCourseRes> Save(SaveCourseReq request)
        {
            var result = new SaveCourseRes()
            {
                CourseId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CourseId", request.CourseId);
                parameters.Add("@CourseName", request.CourseName);
                parameters.Add("@Status", request.Status);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);

                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveCourseRes>(cnn: connection,
                                                                    sql: "sp_SaveCourse",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
    }
}
