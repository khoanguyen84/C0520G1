using CG.DAL.Interface;
using CG.Domain;
using CG.Domain.Response.Module;
using Dapper;
using System;
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

        public int CreateModule(InputCreateModuleView inputCreateModule)
        {
            CreateModuleView createModuleView = new CreateModuleView()
            {
                Name= inputCreateModule.Name,
                Duration=inputCreateModule.Duration,
                Status=1,
                CreateDate=DateTimeOffset.Now,
                CreateBy=1,
                ModifiedDate= DateTimeOffset.Now,
                ModifiedBy=1
            };
            DynamicParameters param = new DynamicParameters();
            param.Add("@ModuleNameParm", createModuleView.Name);
            param.Add("@DurationParm", createModuleView.Duration);
            param.Add("@@StatusParm", createModuleView.Status);
            param.Add("@CreatedDateParm", createModuleView.CreateDate);
            param.Add("@ModifiedDateParm", createModuleView.ModifiedDate);
            param.Add("@CreatedByParm", createModuleView.CreateBy);
            param.Add("@ModifiedByParm", createModuleView.ModifiedBy);

            int result = SqlMapper.ExecuteScalar<int>(connection, "sp_CreateModule", param, commandType: CommandType.StoredProcedure);
            return result;
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
