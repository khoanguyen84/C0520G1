using CG.DAL.Interface;
using CG.Domain.Response.Module;
using CG.Domain.Response.Student;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public async Task<IEnumerable<StudentView>> GetStudents()
        {
            return await SqlMapper.QueryAsync<StudentView>(cnn: connection,
                                                        sql: "sp_GetStudent",
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}
