using CG.Domain.Request.Module;
using CG.Domain.Response.Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleView>> Gets();
        Task<ModuleView> Get(int moduleId);
        Task<SaveModuleRes> Save(SaveModuleReq request);
        Task<DeleteModuleResult> Delete(int moduleId);
    }
}
