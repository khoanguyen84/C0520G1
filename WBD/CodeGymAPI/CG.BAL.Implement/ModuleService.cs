using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain;
using CG.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleIRepository iRepository;

        public ModuleService(IModuleIRepository  iRepository)
        {
            this.iRepository = iRepository;
        }
        public int UpdatesModule(UpdateModule request)
        {
            return iRepository.UpdateModule(request);
        }

        public async Task<IEnumerable<ModuleViewModel>> Gets()
        {
            return await iRepository.Gets();
        }

    }
}
