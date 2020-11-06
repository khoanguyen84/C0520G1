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
        public async Task<SaveCourseRes> ChangeStatus(int id, int status)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CourseId", id);
            parameters.Add("@Status", status);
            return await SqlMapper.QueryFirstOrDefaultAsync<SaveCourseRes>(cnn: connection,
                                                        sql: "sp_ChangeCourseStatus",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<CourseView> Get(int id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CourseIdParm", id);

            return await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourseById",
                                                        dynamicParameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await SqlMapper.QueryAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourses",
                                                        commandType: CommandType.StoredProcedure);
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
            catch (Exception)
            {
                return result;
            }
        }
    }
}
