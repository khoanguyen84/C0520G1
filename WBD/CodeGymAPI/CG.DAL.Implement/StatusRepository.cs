using CG.DAL.Interface;
using CG.Domain.Response;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    public class StatusRepository : BaseRepository,IStatusRepository
    {
        async Task<GetStatusName> IStatusRepository.Get(int Id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@StatusIdParm", Id);

            return await SqlMapper.QueryFirstAsync<GetStatusName>(cnn: connection, sql: "sp_GetStatus", parameter,
                                                            commandType: CommandType.StoredProcedure);
        }
    }
}
