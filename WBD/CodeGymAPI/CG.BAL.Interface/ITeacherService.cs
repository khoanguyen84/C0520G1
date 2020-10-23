using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CG.Domain.Response.Teacher;

namespace CG.BAL.Interface
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherView>> GetTeacher();
    }
}
