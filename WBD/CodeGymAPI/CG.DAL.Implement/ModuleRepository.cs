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
        public async Task<ModuleChangeStatusRespone> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", request.ModuleId);
                parameters.Add("@status", request.Status);
                parameters.Add("@modifiedBy", request.ModifiedBy);
                return (await SqlMapper.QueryFirstOrDefaultAsync<ModuleChangeStatusRespone>(cnn: connection,
                                 param: parameters,
                                sql: "sp_ChangeStatusModuleByModuleId",
                                commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                return new ModuleChangeStatusRespone()
                {
                    ModuleId = 0,
                    Message = "Something went wrong, please try again"
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

        public async Task<ModuleChangeStatusRespone> SaveModule(ModuleSaveRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", request.ModuleId);
                parameters.Add("@moduleName", request.ModuleName);
                parameters.Add("@duration", request.Duration);
                parameters.Add("@status", request.Status);
                
                parameters.Add("@createBy", request.CreateBy);
                parameters.Add("@modidiedBy", request.ModifiedBy);
                return (await SqlMapper.QueryFirstOrDefaultAsync<ModuleChangeStatusRespone>(cnn: connection,
                                 param: parameters,
                                sql: "sp_SaveModule",
                                commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {

                return new ModuleChangeStatusRespone()
                {
                    ModuleId = 0,
                    Message = "Something went wrong, please try again"
                };
            }
        }
    }
}
