using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using CG.Domain.Response.Wiki;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IWikiRepository
    {
        Task<IEnumerable<Status>> GetStatus(int tableId, bool isUpdate);
    }
}
