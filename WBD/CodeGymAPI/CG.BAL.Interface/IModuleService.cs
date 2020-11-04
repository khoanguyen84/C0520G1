using CG.Domain.Request.Course;
using CG.Domain.Request.Module;
using CG.Domain.Response;
using CG.Domain.Response.Course;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleView>> Gets();
        Task<ChangeStatusRes> ChangeStatusModule(int moduleId, int status, int modifiedBy = 1); 
        Task<ResResult> Save(SaveModuleReq request);
    }

}
