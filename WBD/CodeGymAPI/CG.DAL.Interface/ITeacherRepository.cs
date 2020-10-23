using System;
using CG.Domain.Response.Teacher;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<TeacherView>> GetTeacher();
    }
}
