using CG.Domain.Request.Module;
using CG.Domain.Response.Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleView>> Gets();
        Task<SaveModuleRes> Save(SaveModuleReq request);
        Task<ModuleView> Get(int id);
        Task<SaveModuleRes> DeleteModule(int id);
    }
}
