using CG.DAL.Interface;
using CG.Domain;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class ModuleRepository : BaseRepository, IModuleRepository
    {
        public async Task<IEnumerable<ModuleViewModel>> Gets() =>
             await SqlMapper.QueryAsync<ModuleViewModel>(cnn: connection, sql: "sp_GetModules", commandType: CommandType.StoredProcedure);
    }
}
