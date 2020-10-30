using CG.DAL.Interface;
using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using CG.Domain.Response.Wiki;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class WikiRepository : BaseRepository, IWikiRepository
    {
        public async Task<IEnumerable<Status>> GetStatus(int tableId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TableId", tableId);
            return await SqlMapper.QueryAsync<Status>(cnn: connection,
                                                        sql: "sp_GetStatus",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}
