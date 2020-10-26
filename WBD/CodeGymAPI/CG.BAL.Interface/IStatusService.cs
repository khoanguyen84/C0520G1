using CG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IStatusService
    {
        Task<GetStatusName> GetStatus(int Id);
    }
}
