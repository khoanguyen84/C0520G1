using CG.Domain.Request.Teacher;
using CG.Domain.Response.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ITeacherRepository
    {
        Task<TeacherResult> GetStatusTeacherById(int Id, int Status);
        Task<TeacherSaveResult> Save(Teacher teacher);
        Task<Teacher> TeacherById(int id);
        Task<Teacher> Get();
    }
}
