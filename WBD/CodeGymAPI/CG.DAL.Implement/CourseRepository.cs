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
        //public async Task<bool> CheckId(int id)
        //{
        //    try
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@courseId", id);
        //        var query = $"SELECT [CourseId] FROM[dbo].[Course] WHERE[CourseId] = {id}";
        //        var result = await SqlMapper.QueryFirstOrDefaultAsync(cnn: connection,
        //                                                              sql: query,
        //                                                              commandType: CommandType.Text);
        //        if (result != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<CourseView> Get(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@courseId", id);
                var result = await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(connection, "sp_GetCoursesById", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception ex)
            {

                return result;
            }
        }
        public async Task<SaveCourseRes> ChangeStatusToInProcess(int id)
        {
            var result = new SaveCourseRes()
            {
                CourseId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CourseId", id);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveCourseRes>(cnn: connection,
                                                                    sql: "sp_ChangeStatusToInProcess",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public async Task<SaveCourseRes> ChangeStatusToCompleted(int id)
        {
            var result = new SaveCourseRes()
            {
                CourseId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CourseId", id);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveCourseRes>(cnn: connection,
                                                                    sql: "sp_ChangeStatusToCompleted",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public async Task<SaveCourseRes> Delete(int id)
        {
            var result = new SaveCourseRes()
            {
                CourseId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CourseId", id);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveCourseRes>(cnn: connection,
                                                                    sql: "sp_DeleteCourse",
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
