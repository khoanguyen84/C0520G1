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
        public async Task<ModuleViewModel> GetModuleViewModelById(int id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ModuleIdParm", id);

            return await SqlMapper.QueryFirstAsync<ModuleViewModel>(cnn: connection, sql: "sp_GetModuleById", parameter,
                                                            commandType: CommandType.StoredProcedure);
        }
           

        public async Task<IEnumerable<ModuleViewModel>> Gets() =>
             await SqlMapper.QueryAsync<ModuleViewModel>(cnn: connection, sql: "sp_GetModules", commandType: CommandType.StoredProcedure);
    }
}
