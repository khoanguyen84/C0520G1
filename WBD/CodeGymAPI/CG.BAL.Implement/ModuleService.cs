using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain;
using CG.Domain.Request;
using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
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
        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await moduleRepository.Gets();
        }

        public int UpdatesModule(UpdateModule request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ModuleViewModel>> IModuleService.Gets()
        {
            throw new NotImplementedException();
        }
    }
}
