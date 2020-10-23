using CG.DAL.Interface;
using CG.Domain;
using CG.Domain.Request;
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

      
        /*public async Task<ModuleViewModel> GetsModule(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ModuleId", Id);
            return (await SqlMapper.QueryFirstOrDefaultAsync<ModuleViewModel>(cnn: connection,
                                                        sql: "sp_GetCourses",
                                                        commandType: CommandType.StoredProcedure));
        }*/

      

        public int UpdateModule(UpdateModule updateModule)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ModuleId", updateModule.ModuleId);
                parameters.Add("@ModuleName", updateModule.ModuleName);
                parameters.Add("@Duration", updateModule.Duration);
                parameters.Add("@Status", updateModule.Status);
                parameters.Add("@CreatedBy", updateModule.CreatedBy); 
                parameters.Add("@ModifiedDate", updateModule.ModifiedDate);
                parameters.Add("@ModifiedBy", updateModule.ModifiedBy);
                var id = SqlMapper.ExecuteScalar<int>(connection,"UpdateModule",param:parameters, commandType:CommandType.StoredProcedure);
                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
            throw new NotImplementedException();
        }
    }
}
