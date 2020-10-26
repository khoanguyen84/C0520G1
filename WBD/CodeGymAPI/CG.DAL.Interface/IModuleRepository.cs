using CG.Domain;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<IEnumerable<ModuleViewModel>> Gets();

        Task<ModuleViewModel> GetModuleViewModelById(int id);

        int CreateModule(InputCreateModuleView inputCreateModule);
    }
}
