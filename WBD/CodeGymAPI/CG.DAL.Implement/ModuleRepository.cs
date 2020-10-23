using CG.DAL.Interface;
using CG.Domain.Request;
using CG.Domain.Response.Module;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class ModuleRepository : BaseRepository, IModuleRepository
    {
        public async Task<ModuleChangeStatusRespone> ChangeStatusModuleByModuleId(int moduleId, int status)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", moduleId);
                parameters.Add("@status", status);
                return (await SqlMapper.QueryFirstOrDefaultAsync<ModuleChangeStatusRespone>(cnn: connection,
                                 param: parameters,
                                sql: "sp_ChangeStatusModuleByModuleId",
                                commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                return new ModuleChangeStatusRespone()
                {
                    ModuleId = 0
                };
            }
            
        }

   

       public async Task<ModuleChangeStatusRespone> GetModuleByModuleId(int moduleId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@moduleId", moduleId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<ModuleChangeStatusRespone>(cnn: connection,
                             param: parameters,
                            sql: "sp_GetModuleByModuleId",
                            commandType: CommandType.StoredProcedure));
        }
    }
}
