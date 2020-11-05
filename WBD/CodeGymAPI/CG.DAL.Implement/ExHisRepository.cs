using CG.DAL.Interface;
using CG.Domain.Response;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class ExHisRepository : BaseRepository, IExHisRepository
    {
        public async Task<IEnumerable<ExecutionHistoryView>> Gets()
        {
            return await SqlMapper.QueryAsync<ExecutionHistoryView>(cnn: connection,
                                                        sql: "sp_GetsExHis",
                                                        commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ExecutionHistoryView>> GetModuleExHis(int elementId, int tableId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ElementId", elementId);
                parameters.Add("@TableId", tableId);
                var result = await SqlMapper.QueryAsync<ExecutionHistoryView>(connection, "sp_GetModuleExHis", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
