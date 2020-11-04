using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Module;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        public async Task<DeleteModuleResult> Delete(int moduleId)
        {
            return await moduleRepository.Delete(moduleId);
        }

        public async Task<ModuleView> Get(int moduleId)
        {
            return await moduleRepository.Get(moduleId);
        }

        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await moduleRepository.Gets();
        }

        public async Task<SaveModuleRes> Save(SaveModuleReq request)
        {
            return await moduleRepository.Save(request);
        }
    }
}
