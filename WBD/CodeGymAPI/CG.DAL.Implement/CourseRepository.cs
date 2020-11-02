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
        public async Task<CourseView> GetCourseById(int courseId)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@courseId", courseId);
             
                return (await SqlMapper.QueryFirstOrDefaultAsync<CourseView>(cnn: connection,
                                 param: parameters,
                                sql: "sp_GetCourseByCourseId",
                                commandType: CommandType.StoredProcedure));
                       
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
    }
}
