using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request.Module;
using CG.Domain.Response.Module;
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
        [HttpGet]
        [Route("api/module/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var status = await moduleService.Get(id);
            if (status.ModuleName != null)
                return Ok(status);

            return Ok(new NotFound()
            {
                ID = id,
                ErrorMessage = "Not Found !"
            });
        }
        [HttpPut("api/module/change")]
        public async Task<OkObjectResult> ChangeStatus(ModuleChangeStatusRequest request)
        {
            var module = await moduleService.ChangeStatusModuleByModuleId(request);
            return Ok(module);
        }
    }
}
