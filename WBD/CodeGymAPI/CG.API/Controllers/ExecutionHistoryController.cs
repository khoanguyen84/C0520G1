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
    public class ExecutionHistoryController : ControllerBase
    {
        private readonly IExHisService exHisService;

        public ExecutionHistoryController(IExHisService exHisService)
        {
            this.exHisService = exHisService;
        }
        [HttpGet("api/executionHistory/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var exhises = await exHisService.Gets();
            return Ok(exhises);
        }
        [HttpGet("api/executionHistory/getModuleExHis")]
        public async Task<OkObjectResult> GetModuleExHis(int elementId, int tableId)
        {
            var exhises = await exHisService.GetModuleExHis(elementId, tableId);
            return Ok(exhises);
        }
    }
}
