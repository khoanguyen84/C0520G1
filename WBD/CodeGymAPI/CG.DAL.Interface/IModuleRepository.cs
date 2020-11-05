using CG.Domain.Request.Course;
using CG.Domain.Request.Module;
using CG.Domain.Response.Course;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<IEnumerable<ModuleView>> Gets();
        Task<SaveModuleRes> Save(SaveModuleReq request);
        Task<SaveModuleRes> Deleted(int id, int status);
    }
}
