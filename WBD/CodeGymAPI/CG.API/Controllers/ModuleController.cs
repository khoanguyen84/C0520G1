using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request;
using CG.Domain.Request.Module;
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


        [HttpGet("api/module/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var module = await moduleService.GetModuleByModuleId(id);
            return Ok(module);
        }
        [HttpPut("api/module/change")]
        public async Task<OkObjectResult> ChangeStatus(ModuleChangeStatusRequest request)
        {
            var module = await moduleService.ChangeStatusModuleByModuleId(request);
            return Ok(module);
        }
        [HttpPost("api/module/save")]
        [HttpPatch("api/module/save")]
        public async Task<OkObjectResult> Save(SaveModuleReq request)
        {
            var module = await moduleService.SaveModule(request);
            return Ok(module);
        }
        [HttpGet("api/module/gets")]
        public async Task<OkObjectResult> GetModules()
        {
            var modules = await moduleService.Gets();
            return Ok(modules);
        }      
       
    }
}
