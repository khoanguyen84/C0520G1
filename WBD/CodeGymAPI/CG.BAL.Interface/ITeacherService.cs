using CG.Domain.Request;
using CG.Domain.Response.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.BAL.Interface
{
    public interface ITeacherService
    {
        Task<DeleteTeacher> CreateTeacher(CreateTeacher request);
        Task<IEnumerable<TeacherView>> Gets();
        Task<TeacherView> GetTeacher(int id);
        Task<DeleteTeacher> EditTeacher(EditTeacher request);
        Task<DeleteTeacher> DeleteTeacher(int id);
    }
}
