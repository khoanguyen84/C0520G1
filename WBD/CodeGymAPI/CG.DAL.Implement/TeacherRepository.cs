using CG.DAL.Interface;
using CG.Domain.Request;
using CG.Domain.Response.Teacher;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public async Task<DeleteTeacher> CreateTeacher(CreateTeacher request)
        {
            try
            {
                //var sqlQuery = "SELECT count(Email) FROM [dbo].[Teacher] WHERE Email = @Email";
                //var conn = new SqlConnection(@"Data Source=hoang\sqlexpress;Initial Catalog=CodeGymDb;Integrated Security=True");

                //SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                //cmd.Parameters.AddWithValue("@Email", request.Email.Trim());
                //conn.Open();
                //int count = Convert.ToInt32(cmd.ExecuteScalar());
                //if (count == 0)
                //{
                //    var sql = "SELECT count(PhoneNumber) FROM [dbo].[Teacher] WHERE PhoneNumber = @PhoneNumber";
                //    SqlCommand cmd1 = new SqlCommand(sql, conn);
                //    cmd1.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber.Trim());
                //    int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                //    if (count1 == 0)
                //    {
                //        DynamicParameters parameters = new DynamicParameters();
                //        parameters.Add("@Fullname", request.FullName);
                //        parameters.Add("@Gender", request.Gender);
                //        parameters.Add("@Dob", request.Dob);
                //        parameters.Add("@Status", request.Status);
                //        parameters.Add("@Email", request.Email);
                //        parameters.Add("@PhoneNumber", request.PhoneNumber);
                //        parameters.Add("@Level", request.Level);
                //        parameters.Add("@Address", request.Address);
                //        parameters.Add("@Avatar", request.Avatar);
                //        var id = SqlMapper.ExecuteScalar<int>(connection, "CreateTeacher", param: parameters, commandType: CommandType.StoredProcedure);
                //        return id;
                //    }
                //    return -1;
                //}

                //return -2;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Fullname", request.FullName);
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@Dob", request.Dob);
                parameters.Add("@Status", request.Status);
                parameters.Add("@Email", request.Email);
                parameters.Add("@PhoneNumber", request.PhoneNumber);
                parameters.Add("@Level", request.Level);
                parameters.Add("@Address", request.Address);
                parameters.Add("@Avatar", request.Avatar);
                var teacher = await SqlMapper.QueryFirstOrDefaultAsync<DeleteTeacher>(connection, "CreateTeacher", param: parameters, commandType: CommandType.StoredProcedure);
                return teacher;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteTeacher> DeleteTeacher(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TeacherId", id);
            var teacher = await SqlMapper.QueryFirstOrDefaultAsync<DeleteTeacher>(connection, "DeleteTeacher", param: parameters, commandType: CommandType.StoredProcedure);
            return teacher;
        }

        public async Task<DeleteTeacher> EditTeacher(EditTeacher request)
        {
            try
            {
                //var sqlQuery = "SELECT count(Email) FROM [dbo].[Teacher] WHERE Email = @Email";
                //var conn = new SqlConnection(@"Data Source=hoang\sqlexpress;Initial Catalog=CodeGymDb;Integrated Security=True");

                //SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                //cmd.Parameters.AddWithValue("@Email", request.Email.Trim());
                //conn.Open();
                //int count = Convert.ToInt32(cmd.ExecuteScalar());
                //if (count == 0)
                //{
                //    var sql = "SELECT count(PhoneNumber) FROM [dbo].[Teacher] WHERE PhoneNumber = @PhoneNumber";
                //    SqlCommand cmd1 = new SqlCommand(sql, conn);
                //    cmd1.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber.Trim());
                //    int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                //    if (count1 == 0)
                //    {
                //        DynamicParameters parameters = new DynamicParameters();
                //        parameters.Add("@TeacherId", request.TeacherId);
                //        parameters.Add("@Fullname", request.FullName);
                //        parameters.Add("@Gender", request.Gender);
                //        parameters.Add("@Dob", request.Dob);
                //        parameters.Add("@Status", request.Status);
                //        parameters.Add("@Email", request.Email);
                //        parameters.Add("@PhoneNumber", request.PhoneNumber);
                //        parameters.Add("@Level", request.Level);
                //        parameters.Add("@Address", request.Address);
                //        parameters.Add("@Avatar", request.Avatar);
                //        var id = SqlMapper.ExecuteScalar<int>(connection, "UpdateTeacher", param: parameters, commandType: CommandType.StoredProcedure);
                //        return id;
                //    }
                //    return -1;
                //}

                //return -2;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TeacherId", request.TeacherId);
                parameters.Add("@Fullname", request.FullName);
                parameters.Add("@Gender", request.Gender);
                parameters.Add("@Dob", request.Dob);
                parameters.Add("@Status", request.Status);
                parameters.Add("@Email", request.Email);
                parameters.Add("@PhoneNumber", request.PhoneNumber);
                parameters.Add("@Level", request.Level);
                parameters.Add("@Address", request.Address);
                parameters.Add("@Avatar", request.Avatar);
                parameters.Add("@ModifiedBy", request.ModifiedBy);
                var teacher = await SqlMapper.QueryFirstOrDefaultAsync<DeleteTeacher>(connection, "UpdateTeacher", param: parameters, commandType: CommandType.StoredProcedure);
                return teacher;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TeacherView>> Gets()
        {
            var TeacherList = await SqlMapper.QueryAsync<TeacherView>(connection, "GetsListTeacher", commandType: CommandType.StoredProcedure);

            return TeacherList;
        }

        public async Task<TeacherView> GetTeacher(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TeacherId", id);
            var teacher = await SqlMapper.QueryFirstAsync<TeacherView>(connection,"GetTeacher",parameters, commandType: CommandType.StoredProcedure);
            return teacher;
        }
    }
}
