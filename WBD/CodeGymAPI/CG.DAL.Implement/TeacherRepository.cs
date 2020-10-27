using CG.DAL.Interface;
using CG.Domain.Response.Teacher;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class TeacherRepository : BaseRepository,ITeacherRepository
    {
        public async Task<IEnumerable<TeacherView>> GetTeacher()
        {
            return await SqlMapper.QueryAsync<TeacherView>(cnn: connection,
                                                        sql: "sp_GetTeachers",
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}
