﻿using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class ModuleService: IModuleService
    {
        private readonly IModuleRepository moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }


        public Task<ModuleChangeStatusRespone> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request)
        {
            return moduleRepository.ChangeStatusModuleByModuleId(request);
        }

       public Task<ModuleChangeStatusRespone> GetModuleByModuleId(int moduleId)
        {
            return moduleRepository.GetModuleByModuleId(moduleId);
        }

        public Task<ModuleChangeStatusRespone> SaveModule(ModuleSaveRequest request)
        {
            return moduleRepository.SaveModule(request);
        }
    }
}
using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Course;
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
        public async Task<IEnumerable<ModuleView>> Gets()
        {
            return await moduleRepository.Gets();
        }

    }
}
