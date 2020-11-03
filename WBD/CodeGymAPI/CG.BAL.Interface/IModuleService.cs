using CG.Domain.Request;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<ModuleView> GetModuleByModuleId(int moduleId);

        Task<ModuleChangeStatusRespone> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request);

        Task<ModuleChangeStatusRespone> SaveModule(ModuleSaveRequest request);
        Task<IEnumerable<ModuleView>> Gets();
    }
}

