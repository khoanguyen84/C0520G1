using CG.Domain.Request.Course;
using CG.Domain.Request.Module;
using CG.Domain.Response.Course;
using CG.Domain.Request;
using CG.Domain.Response.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<ModuleView> GetModuleByModuleId(int moduleId);

        Task<ModuleChangeStatusRespone> ChangeStatusModuleByModuleId(ModuleChangeStatusRequest request);
        Task<ModuleChangeStatusRespone> SaveModule(ModuleSaveRequest request);
        Task<IEnumerable<ModuleView>> Gets();
        Task<SaveModuleRes> Save(SaveModuleReq request);
    }
}
