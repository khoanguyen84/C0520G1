using CG.DAL.Interface;
using CG.Domain.Request.Teacher;
using CG.Domain.Response.Teacher;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public async Task<Teacher> Get()
        {
            return await SqlMapper.QueryFirstAsync<Teacher>(cnn: connection, sql: "sp_GetTeacher", commandType: CommandType.StoredProcedure);
        }

        public async Task<TeacherResult> GetStatusTeacherById(int TeacherId, int Status)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"TeacherId", TeacherId);
            parameters.Add(@"Status", Status);
            return await SqlMapper.QueryFirstOrDefaultAsync<TeacherResult>(cnn: connection,param: parameters, sql:"ChangeStatusTeacherId", commandType: CommandType.StoredProcedure);


        }

        public async Task<TeacherSaveResult> Save(Teacher teacher)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(@"TeacherId", teacher.TeacherId);
                parameters.Add(@"Fullname", teacher.Fullname);
                parameters.Add(@"Gender", teacher.Gender);
                parameters.Add(@"Dob", teacher.Dob);
                parameters.Add(@"Email", teacher.Email);
                parameters.Add(@"PhoneNumber", teacher.PhoneNumber);
                parameters.Add(@"Level", teacher.Level);
                parameters.Add(@"Address", teacher.Address);
                parameters.Add(@"Avatar", teacher.Avatar);
                parameters.Add(@"Status", teacher.Status);
                parameters.Add(@"CreatedDate", teacher.ModifiedDate);
                parameters.Add(@"CreatedBy", teacher.CreatedBy);
                parameters.Add(@"ModifiedDate", teacher.ModifiedDate);
                parameters.Add(@"ModifiedBy", teacher.ModifiedBy);
                return await SqlMapper.QueryFirstOrDefaultAsync<TeacherSaveResult>(cnn: connection, param: parameters, sql: "dbo.SaveTeacher", commandType: CommandType.StoredProcedure);
            }catch(Exception e)
            {
                throw e;
                //return new TeacherSaveResult()
                //{
                //    TeacherId = 0,
                //    Message = "Something went wrong, please try again!"
                //};
            }


        }

        public async Task<Teacher> TeacherById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(@"TeacherId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<Teacher>(cnn: connection, param: parameters, sql: "sp_GetTeacherById", commandType: CommandType.StoredProcedure);
        }
    }
}
