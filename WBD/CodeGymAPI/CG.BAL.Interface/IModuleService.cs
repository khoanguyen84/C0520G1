using CG.Domain.Request;
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
        int UpdatesModule(UpdateModule request);
        Task<ModuleView> Get(int id);
        Task<SaveModuleRes> Delete(int id);

    }
}
