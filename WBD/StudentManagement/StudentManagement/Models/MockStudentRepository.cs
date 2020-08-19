using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> Students;
        public MockStudentRepository()
        {
            Students = new List<Student>()
            {                
                new Student()
                {
                    DoB = "10/10/2000",
                    Fullname = "Khoa Nguyen",
                    ID  = 1,
                    Aavatar = "noavatar.png"
                },
                new Student()
                {
                    DoB = "10/10/2000",
                    Fullname = "Nhan Nguyen",
                    ID  = 2,
                    Aavatar = "avatar10.jpg"
                }
            };
        }

        public Student Create(StudentCreateModel model)
        {
            var student = new Student()
            {
                DoB = model.DoB,
                Fullname = model.Fullname,
                Aavatar = @"noavatar.png",
                ID = (Students.Max(e => e.ID) + 1)
            };
            Students.Add(student);
            return student;
        }

        public Student Get(int studentId)
        {
            //foreach(var std in Students) 
            //{ 
            //    if(std.ID == studentId)
            //    {
            //        return std;
            //    }
            //}
            //return null;
            return Students.FirstOrDefault(s => s.ID == studentId);
        }

        public IEnumerable<Student> Gets()
        {
            return Students;
        }
    }
}
