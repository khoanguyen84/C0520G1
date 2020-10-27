using CG.Domain.Response.Module;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<ModuleView> Get(int id);
        Task<IEnumerable<ModuleView>> Gets();

    }
}
