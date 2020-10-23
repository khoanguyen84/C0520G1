using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
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

        [HttpGet("api/module/gets")]
        public async Task<OkObjectResult> GetCourses()
        {
            var modules = await moduleService.Gets();
            return Ok(modules);
        }

        [HttpGet("api/module/get")]
        public async Task<OkObjectResult> GetModuleById(int id)
        {
            var modules = await moduleService.GetModuleById(id);

            return Ok(modules);
        }
    }
}
