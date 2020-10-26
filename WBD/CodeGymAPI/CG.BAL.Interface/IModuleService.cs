using CG.Domain;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleViewModel>> Gets();

        Task<ModuleViewModel> GetModuleById(int id);

        int CreateModule(InputCreateModuleView inputCreateModule);
    }
}
