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
        public async Task<NotFound> ChangeCompleted(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", Id);
            var result = await SqlMapper.QueryFirstOrDefaultAsync<NotFound>(cnn: connection,
                                                                            sql: "sp_CompleteCourse",
                                                                            parameters,
                                                                            commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<NotFound> ChangeDeleted(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", Id);
            var result = await SqlMapper.QueryFirstOrDefaultAsync<NotFound>(cnn: connection,
                                                                            sql: "sp_CourseDelete",
                                                                            parameters,
                                                                            commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<NotFound> ChangeInprocess(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", Id);
            var result = await SqlMapper.QueryFirstOrDefaultAsync<NotFound>(cnn: connection,
                                                                            sql: "sp_InprocessCourse",
                                                                            parameters,
                                                                            commandType: CommandType.StoredProcedure);
            return result;
        }

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
