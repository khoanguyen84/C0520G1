using CG.DAL.Interface;
using CG.Domain.Request;
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
        public int CreateTeacher(CreateTeacher request)
        {
            try
            {
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
                parameters.Add("@CreateDate", request.CreateDate);
                parameters.Add("@CreateBy", request.CreateBy);
                parameters.Add("@ModifiedDate", request.ModifiedDate);
                parameters.Add("@ModifiedBy", request.ModifiedBy);

                var id = SqlMapper.ExecuteScalar<int>(connection, "CreateTeacher", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TeacherView> Gets()
        {
            IEnumerable<TeacherView> TeacherList = SqlMapper.Query<TeacherView>(connection, "TeacherList", commandType: CommandType.StoredProcedure);

            return TeacherList;
        }
    }
}
