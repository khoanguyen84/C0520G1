using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
