using CG.Domain.Response.Module;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface IModuleRepository
    {
        Task<ModuleView> Get(int id);
    }
}
