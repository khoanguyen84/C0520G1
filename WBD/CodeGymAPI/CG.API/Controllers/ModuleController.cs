using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request.Module;
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

        [HttpPost, HttpPatch]
        [Route("api/module/save")]
        public async Task<OkObjectResult> SaveModule(SaveModuleReq request)
        {
            var result = await moduleService.Save(request);
            return Ok(result);
        }

        [HttpPost,HttpPatch] 
        [Route("api/module/ChangeModuleStatus/{id}/{status}")]
        public async Task<OkObjectResult> changeModuleStatus(int id, int status)
        {
            var result = await moduleService.ChangeStatus(id, status);
            return Ok(result);
        }
    }
}
