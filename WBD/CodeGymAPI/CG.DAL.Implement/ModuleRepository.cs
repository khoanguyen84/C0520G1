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
        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await SqlMapper.QueryAsync<ModuleView>(cnn: connection,
                                                        sql: "sp_GetModules",
                                                        commandType: CommandType.StoredProcedure);
        }
        public async Task<ModuleView> Get(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@moduleId", id);
                var result = await SqlMapper.QueryFirstOrDefaultAsync<ModuleView>(connection, "sp_GetModuleById", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<SaveModuleRes> Save(SaveModuleReq request)
        {
            //if (request.ModuleId > 0){
            //    var oldData = await Get(request.ModuleId);
            //    if (oldData.ModuleName != request.ModuleName)
            //    {
            //         ExHisModule(request.ModuleId, "ModuleName", oldData.ModuleName, request.ModuleName);
            //    }
            //    if (oldData.Status != request.Status)
            //    {
            //        ExHisModule(request.ModuleId, "Status", oldData.Status.ToString(), request.Status.ToString());
            //    }
            //    if (oldData.Duration != request.Duration)
            //    {
            //        ExHisModule(request.ModuleId, "Duration", oldData.Duration.ToString(), request.Duration.ToString());
            //    }
            //}
           
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
                parameters.Add("@SavedBy", 1);

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
        public async Task<SaveModuleRes> Delete(int id)
        {
            var result = new SaveModuleRes()
            {
                ModuleId = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ModuleId", id);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveModuleRes>(cnn: connection,
                                                                    sql: "sp_DeleteModule",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public async void ExHisModule(int elementId, string columnName, string oldValue, string newValue)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ElementId", elementId);
            parameters.Add("@ColumnName", columnName);
            parameters.Add("@OldValue", oldValue);
            parameters.Add("@NewValue", newValue);
            parameters.Add("@ModifiedBy", 1);
            await SqlMapper.QueryAsync(cnn: connection,
                                       sql: "sp_ExHisModule",
                                       param: parameters,
                                       commandType: CommandType.StoredProcedure);
        }
    }
}
