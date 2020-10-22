using CG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<IEnumerable<ModuleViewModel>> Gets();
    }
}
