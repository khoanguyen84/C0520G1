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

        public async Task<SaveModuleRes> ChangeModuleStatus(int id, int status)
        {
            return await moduleRepository.ChangeModuleStatus(id, status);
        }

        public async Task<ModuleView> Get(int id)
        {
            return await moduleRepository.Get(id);
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

