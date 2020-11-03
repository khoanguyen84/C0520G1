using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService moduleService;

        public ModuleController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }
        [HttpPut("api/module/update")]

        public int UpdateModule([FromBody] UpdateModule request)
        {
            return moduleService.UpdatesModule(request);
        }

        [HttpGet("api/Module/gets")]
        public async Task<OkObjectResult> GetCourses()
        {
            var courses = await moduleService.Gets();
            return Ok(courses);
        }
    }
}
