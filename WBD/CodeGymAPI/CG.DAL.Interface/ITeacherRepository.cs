using CG.Domain.Request;
using CG.Domain.Response.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CG.DAL.Interface
{
    public interface ITeacherRepository
    {
        int CreateTeacher(CreateTeacher request);
        IEnumerable<TeacherView> Gets();
    }
}
