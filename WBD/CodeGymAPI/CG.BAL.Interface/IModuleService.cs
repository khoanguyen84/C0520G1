using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleView>> GetModules();
    }
}
