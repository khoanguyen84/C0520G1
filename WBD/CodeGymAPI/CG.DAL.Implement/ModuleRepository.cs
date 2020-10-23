using CG.DAL.Interface;
using CG.Domain.Response.Course;
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
    }
}
