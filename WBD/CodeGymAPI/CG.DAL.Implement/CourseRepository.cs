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
        public async Task<CourseNotFound> CreateCourse(CreateCourse request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CourseName", request.CourseName);
                parameters.Add("@Status", request.Status);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                var data = await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(connection, "Create_Course", parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CourseNotFound> DeleteCourse(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            var data = await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(connection, "Delete_Course", parameters, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<CourseView> GetCourse(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            var data = await SqlMapper.QueryFirstAsync<CourseView>(connection, "sp_GetCourseById", parameters, commandType: CommandType.StoredProcedure);
            return data;
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
                throw ex;
                //return result;
            }
        }
    }
}
