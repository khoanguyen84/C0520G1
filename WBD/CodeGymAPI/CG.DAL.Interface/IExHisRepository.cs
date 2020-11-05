using CG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IExHisRepository
    {
        Task<IEnumerable<ExecutionHistoryView>> Gets();
        Task<IEnumerable<ExecutionHistoryView>> GetModuleExHis(int elementId, int tableId);
    }
}
