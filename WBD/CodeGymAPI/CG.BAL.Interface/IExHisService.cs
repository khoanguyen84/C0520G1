using CG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IExHisService
    {
        Task<IEnumerable<ExecutionHistoryView>> Gets();
        Task<IEnumerable<ExecutionHistoryView>> GetModuleExHis(int elementId, int tableId);
    }
}
