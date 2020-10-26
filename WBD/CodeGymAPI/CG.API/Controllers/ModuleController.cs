using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Response.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;

        public ModuleController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }
        [HttpGet]
        [Route("api/module/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var status = await moduleService.Get(id);
            if(status.ModuleName!=null)
                return Ok(status);

            return Ok(new NotFound()
            {
                ID= id,
                Message="Not Found !"
            });
        }
    }
}
