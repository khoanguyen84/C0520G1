using CG.Domain;
using CG.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        int UpdatesModule(UpdateModule request);
        Task<IEnumerable<ModuleViewModel>> Gets();
    }
}
