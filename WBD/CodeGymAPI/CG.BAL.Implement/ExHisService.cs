using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class ExHisService : IExHisService
    {
        private readonly IExHisRepository exHisRepository;
        public ExHisService(IExHisRepository exHisRepository)
        {
            this.exHisRepository = exHisRepository;
        }
        public async Task<IEnumerable<ExecutionHistoryView>> Gets()
        {
            return await exHisRepository.Gets();
        }
        public async Task<IEnumerable<ExecutionHistoryView>> GetModuleExHis(int elementId, int tableId)
        {
            return await exHisRepository.GetModuleExHis(elementId, tableId);
        }
    }
}
