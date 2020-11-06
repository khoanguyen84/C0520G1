using CG.DAL.Interface;
using CG.Domain.Request.Module;
using CG.Domain.Response.Course;
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
        public async Task<SaveModuleRes> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", request.ModuleId);
                parameters.Add("@status", request.Status);
                parameters.Add("@modifiedBy", request.ModifiedBy);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveModuleRes>(cnn: connection,
                                 param: parameters,
                                sql: "sp_ChangeStatusModuleByModuleId",
                                commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                return new SaveModuleRes()
                {
                    ModuleId = 0,
                    Message = "Something went wrong, please try again"
                };
            }

        }
        public async Task<ModuleView> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ModuleId", id);
            return await SqlMapper.QueryFirstOrDefaultAsync<ModuleView>(cnn: connection, sql: "sp_GetModuleById", param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await SqlMapper.QueryAsync<ModuleView>(cnn: connection,
                                                        sql: "sp_GetModules",
                                                        commandType: CommandType.StoredProcedure);
        }
        public async Task<SaveModuleRes> Save(SaveModuleReq request)
        {
            var result = new SaveModuleRes()
            {
                ModuleId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ModuleId", request.ModuleId);
                parameters.Add("@ModuleName", request.ModuleName);
                parameters.Add("@Duration", request.Duration);
                parameters.Add("@Status", request.Status);

                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveModuleRes>(cnn: connection,
                                                                    sql: "sp_SaveModule",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
    }
}
