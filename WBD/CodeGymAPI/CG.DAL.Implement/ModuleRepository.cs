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
        private readonly IStatusRepository statusRepository;

        public ModuleRepository(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        public async Task<ModuleViewModel> GetModuleViewModelById(int id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ModuleIdParm", id);

            var resutl = await SqlMapper.QueryFirstAsync<ModuleViewModel>(cnn: connection, sql: "sp_GetModuleById", parameter,
                                                            commandType: CommandType.StoredProcedure);

            resutl.StatusName = statusRepository.Get(resutl.Status).Result.StatusName;
            return resutl;
        }


        public async Task<IEnumerable<ModuleViewModel>> Gets()
        {
            var resutl = await SqlMapper.QueryAsync<ModuleViewModel>(cnn: connection, sql: "sp_GetModules",
                                                        commandType: CommandType.StoredProcedure);
            foreach (var item in resutl)
                item.StatusName = statusRepository.Get(item.Status).Result.StatusName;

            return resutl;
        }

    }
}
