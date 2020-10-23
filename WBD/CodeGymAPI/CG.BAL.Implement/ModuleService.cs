using CG.BAL.Interface;
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


        public Task<ModuleChangeStatusRespone> ChangeStatusModuleByModuleId(int moduleId, int status)
        {
            return moduleRepository.ChangeStatusModuleByModuleId(moduleId, status);
        }

       public Task<ModuleChangeStatusRespone> GetModuleByModuleId(int moduleId)
        {
            return moduleRepository.GetModuleByModuleId(moduleId);
        }
    }
}
