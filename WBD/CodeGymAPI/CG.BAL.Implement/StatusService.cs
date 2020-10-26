using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        public Task<GetStatusName> GetStatus(int Id)
        {
            return statusRepository.Get(Id);
        }
    }
}
