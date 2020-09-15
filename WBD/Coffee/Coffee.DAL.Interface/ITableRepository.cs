using Coffee.Domain.Entities;
using Coffee.Domain.Request.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coffee.DAL.Interface
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> Gets();
        Task<Table> Get(string tableCode, int tableId = 0);
        Task<Table> Create(CreateTableReq request);
        Task<Table> Modify(Table table);
    }
}
