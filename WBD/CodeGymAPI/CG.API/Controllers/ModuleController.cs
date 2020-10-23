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
        [HttpGet("api/module/changestatus")]
        public async Task<OkObjectResult> ChangeStatus(int moduleId, int status)
        {
            var module = await moduleService.ChangeStatusModuleByModuleId(moduleId,status);
            return Ok(module);
        }
    }
}
