using CG.DAL.Interface;
using CG.Domain.Response.Module;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace CG.DAL.Implement
{
    public class ModuleRepository : BaseRepository, IModuleRepository
    {
        public async Task<ModuleView> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ModuleId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<ModuleView>(cnn: connection, sql: "Module_GetByModuleId", param: parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await SqlMapper.QueryAsync<ModuleView>(cnn: connection,
                                                        sql: "sp_GetModules",
                                                        commandType: CommandType.StoredProcedure);

            //var query = "SELECT [CourseId],[CourseName],[Status],[StartDate],[EndDate] FROM[dbo].[Course] WHERE[Status] = 1";
            //var result = await SqlMapper.QueryAsync<CourseView>(cnn: connection,
            //                                                    sql: query,
            //                                                    commandType: CommandType.Text);
            //return result;
        }
    }
}
