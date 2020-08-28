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
                    DoB = DateTime.Parse("2000-10-10"),
                    Fullname = "Khoa Nguyen",
                    ID  = 1,
                    Aavatar = "noavatar.png",
                    Email = "khoa.nguyen@codegym.vn",
                    Classes = Classes.NetCore
                },
                new Student()
                {
                    DoB = DateTime.Parse("2000-10-10"),
                    Fullname = "Nhan Nguyen",
                    ID  = 2,
                    Aavatar = "avatar10.jpg",
                    Email = "nhan.nguyen@codegym.vn",
                    Classes = Classes.Java
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
                ID = (Students.Max(e => e.ID) + 1),
                Email = model.Email,
                Classes = model.Classes
            };
            Students.Add(student);
            return student;
        }

        public Student Delete(int studentId)
        {
            var delStudent = Get(studentId);
            if(delStudent != null)
            {
                Students.RemoveAt(studentId);
                return delStudent;
            }
            return null;
        }

        public Student Edit(StudentEditModel model)
        {
            var student = Get(model.ID);
            if(student != null)
            {
                student.Classes = model.Classes;
                student.Fullname = model.Fullname;
                student.DoB = model.DoB;
                student.Aavatar = @"noavatar.png";
                student.Email = model.Email;

                return student;
            }
            return null;
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
