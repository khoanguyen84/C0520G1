using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Course;
using CG.Domain.Request.Module;
using CG.Domain.Response;
using CG.Domain.Response.Course;
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

        public async Task<ChangeStatusRes> ChangeStatusModule(int moduleId, int status, int modifiedBy = 1)
        {
            return await moduleRepository.ChangeStatusModule(moduleId, status, modifiedBy) ;
        }

        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await moduleRepository.Gets();
        }
        public async Task<ResResult> Save(SaveModuleReq request)
        {
            return await moduleRepository.Save(request);
        }

    }
}
