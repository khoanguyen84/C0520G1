using Coffee.DAL.Interface;
using Coffee.Domain.Entities;
using Coffee.Domain.Request.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coffee.DAL
{
    public class TableRepository : ITableRepository
    {
        private readonly CoffeeDbContext context;

        public TableRepository()
        {
            this.context = new CoffeeDbContext();
        }
        public TableRepository(CoffeeDbContext context)
        {
            this.context = context;
        }

        public async Task<Table> Create(CreateTableReq request)
        {
            Table tableCreated = new Table();
            try
            {
                var foundTable = await Get(request.TableCode);
                if(foundTable == null)
                {
                    var table = new Table()
                    {
                        IsDelete = false,
                        TableCode = request.TableCode
                    };

                    await context.Tables.AddAsync(table);
                    var tableId = await context.SaveChangesAsync();
                    tableCreated = await context.Tables.FindAsync(tableId);
                    return tableCreated;
                }
                return tableCreated;
            }
            catch (Exception e)
            {
                return tableCreated;
            }
        }

        public async Task<Table> Get(string tableCode, int tableId = 0)
        {
            Table foundTable = new Table();
            if (tableId == 0)
            {
                foundTable = await context.Tables.FirstOrDefaultAsync(e => e.TableCode == tableCode);
            }
            else
            {
                foundTable = await context.Tables.FindAsync(tableId);
            }
            return foundTable;
        }

        public Task<IEnumerable<Table>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<Table> Modify(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
