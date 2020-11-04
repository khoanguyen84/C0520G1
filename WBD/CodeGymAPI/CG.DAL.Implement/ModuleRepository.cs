

using CG.DAL.Interface;
using CG.Domain.Request.Course;
using CG.Domain.Request.Module;
using CG.Domain.Response;
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
        public async Task<ChangeStatusRes> ChangeStatusModule(int moduleId, int status, int modifiedBy = 1)
        {
            var result = new ChangeStatusRes()
            {
                CourseId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", moduleId);
                parameters.Add("@status", status);
                parameters.Add("@modifiedBy", modifiedBy);
                return (await SqlMapper.QueryFirstOrDefaultAsync<ChangeStatusRes>(cnn: connection,
                                 param: parameters,
                                sql: "sp_ChangeStatusModule",
                                commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await SqlMapper.QueryAsync<ModuleView>(cnn: connection,
                                                        sql: "sp_GetModules",
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<ResResult> Save(SaveModuleReq request)
        {
            var result = new ResResult()
            {
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ModuleId", request.ModuleId);
                parameters.Add("@ModuleName", request.ModuleName);
                parameters.Add("@Status", request.Status);
                parameters.Add("@Duration", request.Duration);
                

                result = await SqlMapper.QueryFirstOrDefaultAsync<ResResult>(cnn: connection,
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
