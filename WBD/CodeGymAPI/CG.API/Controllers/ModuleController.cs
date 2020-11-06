using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using CG.Domain.Request;
using CG.Domain.Request.Module;
using Microsoft.AspNetCore.Http;
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

        [HttpPost, HttpPatch]
        [Route("api/module/save")]
        public async Task<OkObjectResult> SaveModule([FromBody] SaveModuleReq request)
        {
            var result = await moduleService.Save(request);
            return Ok(result);
        }

        [HttpGet("api/module/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var course = await moduleService.Get(id);
            return Ok(course);
        }


        [HttpPatch]
        [Route("api/module/delete/{id}")]
        public async Task<OkObjectResult> Delete(int id)
        {
            var result = await moduleService.Delete(id);
            return Ok(result);
        }
    }
}
