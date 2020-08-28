using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Gets();
        Student Get(int studentId);
        Student Create(StudentCreateModel model);
        Student Edit(StudentEditModel model);
        Student Delete(int studentId);
    }
}
