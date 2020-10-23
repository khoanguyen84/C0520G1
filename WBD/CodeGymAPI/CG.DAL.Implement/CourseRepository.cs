﻿using CG.DAL.Interface;
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
        public async Task<IEnumerable<CourseView>> Gets()
        {
            return await SqlMapper.QueryAsync<CourseView>(cnn: conn,
                                                        sql: "sp_GetCourses",
                                                        commandType: CommandType.StoredProcedure);

           
        }

        public async Task<SaveCourseResult> Save(SaveCourseRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CourseName", request.CourseName);
                parameters.Add("@Status", request.Status);
                parameters.Add("@StartDate", request.StartDate);
                parameters.Add("@EndDate", request.EndDate);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveCourseResult>(cnn: conn, 
                                            sql: "CourseCreate",
                                            param: parameters, 
                                            commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                return new SaveCourseResult()
                {
                    CourseId = 0,
                    Message = "Something went wrong, please try again"
                };
            }
        }
    }
}
