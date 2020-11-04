using CG.DAL.Interface;
using CG.Domain.Request.Course;
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
    }
}
