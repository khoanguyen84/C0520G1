using CG.DAL.Interface;
using CG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Implement
{
    class ModuleRepository : IModuleRepository
    {
        public Task<IEnumerable<ModuleViewModel>> Gets()
        {
            throw new NotImplementedException();
        }
    }
}
