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
        int CreateTeacher(CreateTeacher request);
        IEnumerable<TeacherView> Gets();
    }
}
