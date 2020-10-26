using CG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IStatusRepository
    {
        Task<GetStatusName> Get(int Id);
    }
}
