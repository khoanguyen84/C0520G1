using CG.DAL.Interface;
using CG.Domain.Request.Course;
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
        public async Task<CourseView> GetCourseById(int courseId)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@courseId", courseId);
             
                var result = (await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(cnn: connection,
                                 param: parameters,
                                sql: "sp_GetCourseByCourseId",
                                commandType: CommandType.StoredProcedure));
                return result;
                       
        }

        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await SqlMapper.QueryAsync<CourseView>(cnn: connection,
                                                        sql: "sp_GetCourses",
                                                        commandType: CommandType.StoredProcedure);
            
        }

        public async Task<CourseNotFound> SaveCourse(CourseSaveRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@courseId", request.CourseId);
            parameters.Add("@courseName", request.CourseName);
            parameters.Add("@status", request.Status);
            parameters.Add("@startDate", request.StartDate);
            parameters.Add("@endDate", request.EndDate);

            return (await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(cnn: connection,
                             param: parameters,
                            sql: "sp_SaveCourse",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<SaveCourseRes> Save(Domain.Request.Course.SaveCourseReq request)
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
        public async Task<CourseNotFound> ChangeStatusCourse(int courseId, int status, int modifiedBy = 1)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@courseId", courseId);
            parameters.Add("@status", status);
            parameters.Add("@modifiedBy", modifiedBy);
            return (await SqlMapper.QueryFirstOrDefaultAsync<CourseNotFound>(cnn: connection,
                             param: parameters,
                            sql: "sp_ChangeStatusCourseByCourseId",
                            commandType: CommandType.StoredProcedure));
        }
    }
}
