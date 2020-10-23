using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<ModuleViewModel> GetModuleById(int id) => moduleRepository.GetModuleViewModelById(id);

        public Task<IEnumerable<ModuleViewModel>> Gets() => moduleRepository.Gets();
    }
}
