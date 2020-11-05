using CG.Domain.Request.Module;
using CG.Domain.Request;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<ModuleView> GetModuleByModuleId(int moduleId);

        Task<SaveModuleRes> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request);
        Task<SaveModuleRes> SaveModule(SaveModuleReq request);
        Task<IEnumerable<ModuleView>> Gets();
        Task<SaveModuleRes> Save(SaveModuleReq request);
    }
}
