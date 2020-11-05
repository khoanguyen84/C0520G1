using CG.DAL.Interface;
using CG.Domain.Request;
using CG.Domain.Request.Module;
using CG.Domain.Response.Course;
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

   

       public async Task<ModuleView> GetModuleByModuleId(int moduleId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@moduleId", moduleId);
            return (await SqlMapper.QueryFirstOrDefaultAsync<ModuleView>(cnn: connection,
                             param: parameters,
                            sql: "sp_GetModuleByModuleId",
                            commandType: CommandType.StoredProcedure));
        }

        public async Task<SaveModuleRes> SaveModule(SaveModuleReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", request.ModuleId);
                parameters.Add("@moduleName", request.ModuleName);
                parameters.Add("@duration", request.Duration);
                parameters.Add("@status", request.Status);
                
                //parameters.Add("@createBy", request.CreateBy);
                //parameters.Add("@modidiedBy", request.ModifiedBy);
                return (await SqlMapper.QueryFirstOrDefaultAsync<SaveModuleRes>(cnn: connection,
                                 param: parameters,
                                sql: "sp_SaveModule",
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
                parameters.Add("@Status", request.Status);
                parameters.Add("@Duration", request.Duration);

                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveModuleRes>(cnn: connection,
                                                                    sql: "sp_SaveModule",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }
    }
}
