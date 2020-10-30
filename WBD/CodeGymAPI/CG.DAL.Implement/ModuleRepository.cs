using CG.DAL.Interface;
using CG.Domain;
using CG.Domain.Request;
using CG.Domain.Response.Course;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class ModuleRepository : BaseRepository, IModuleIRepository
    {
        public async Task<IEnumerable<ModuleViewModel>> Gets()
        {
            return await SqlMapper.QueryAsync<ModuleViewModel>(cnn: connection,
                                                        sql: "sp_GetModule",
                                                        commandType: CommandType.StoredProcedure);
        }

        public int UpdateModule(UpdateModule updateModule)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ModuleId", updateModule.ModuleId);
                parameters.Add("@ModuleName", updateModule.ModuleName);
                parameters.Add("@Duration", updateModule.Duration);
                parameters.Add("@Status", updateModule.Status);
                var id = SqlMapper.ExecuteScalar<int>(connection,"UpdateModule",param:parameters, commandType:CommandType.StoredProcedure);
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
