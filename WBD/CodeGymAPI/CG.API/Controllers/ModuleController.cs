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

        public ModuleController(IModuleService moduleService) => this.moduleService = moduleService;

        [HttpGet("api/module/gets")]
        public async Task<OkObjectResult> GetModules()
        {
            var modules = await moduleService.Gets();
            return Ok(modules);
        }

        [HttpGet("api/module/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var course = await moduleService.Get(id);
            return Ok(course);
        }

        [HttpPost, HttpPatch]
        [Route("api/module/save")]
        public async Task<OkObjectResult> SaveModule(SaveModuleReq request)
        {
            var result = await moduleService.Save(request);
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/module/changeModuleStatus/{id}/{status}")]
        public async Task<OkObjectResult> ChangeModuleStatus(int id, int status)
        {
            var result = await moduleService.ChangeModuleStatus(id, status);
            return Ok(result);
        }
    }
}

