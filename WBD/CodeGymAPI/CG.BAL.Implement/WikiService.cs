using CG.BAL.Interface;
using CG.DAL.Interface;
using CG.Domain.Request.Course;
using CG.Domain.Response.Course;
using CG.Domain.Response.Wiki;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Implement
{
    public class WikiService : IWikiService
    {
        private readonly IWikiRepository wikiRepository;

        public WikiService(IWikiRepository wikiRepository)
        {
            this.wikiRepository = wikiRepository;
        }
        public async Task<IEnumerable<Status>> GetStatus(int tableId)
        {
            return await wikiRepository.GetStatus(tableId);
        }
    }
}
