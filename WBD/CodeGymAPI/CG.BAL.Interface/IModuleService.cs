using CG.Domain.Request;
using CG.Domain.Request.Module;
using CG.Domain.Response.Module;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<ModuleView> GetModuleByModuleId(int moduleId);

        Task<SaveModuleRes> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request);

        Task<SaveModuleRes> SaveModule(SaveModuleReq request);
        Task<IEnumerable<ModuleView>> Gets();
        Task<SaveModuleRes> Save(SaveModuleReq request);
    }
}

