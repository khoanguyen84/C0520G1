using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;

        public ModuleController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpGet("api/module/gets")]
        public async Task<OkObjectResult> GetModules()
        {
            var modules = await moduleService.Gets();
            return Ok(modules);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{

    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;

        public ModuleController(IModuleService moduleService )
        {
            this.moduleService = moduleService;
        }


        [HttpGet("api/module/get")]
        public async Task<OkObjectResult> Get(int moduleId)
        {
            var module = await moduleService.GetModuleByModuleId(moduleId);
            return Ok(module);
        }
        [HttpPut("api/module/change")]
        public async Task<OkObjectResult> ChangeStatus(ModuleChangeStatusRequest request)
        {
            var module = await moduleService.ChangeStatusModuleByModuleId(request);
            return Ok(module);
        }
        [HttpPost("api/module/save")]
        public async Task<OkObjectResult> Save(ModuleSaveRequest request)
        {
            var module = await moduleService.SaveModule(request);
            return Ok(module);
        }
    }
}
