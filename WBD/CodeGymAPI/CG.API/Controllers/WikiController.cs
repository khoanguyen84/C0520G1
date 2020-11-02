using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CG.API.Controllers
{
    [ApiController]
    public class WikiController : ControllerBase
    {
        private readonly IWikiService wikiService;

        public WikiController(IWikiService wikiService)
        {
            this.wikiService = wikiService;
        }

        [HttpGet("api/wiki/status/{id},{isUpdate}")]
        public async Task<OkObjectResult> GetStatus(int id, bool isUpdate)
        {
            return Ok(await wikiService.GetStatus(id, isUpdate));
        }
    }
}
