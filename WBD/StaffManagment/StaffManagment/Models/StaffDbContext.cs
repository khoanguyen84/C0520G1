using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffManagment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = StaffManagment.Models.Entities.Task;

namespace StaffManagment.Models
{
    public class StaffDbContext : IdentityDbContext<ExtendIdentityUser>
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {

        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<Province>();
            //modelBuilder.Ignore<District>();
            //modelBuilder.Ignore<Ward>();

            modelBuilder.Entity<Employee>().HasOne(s => s.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(s => s.DepartmentId);

            modelBuilder.Entity<EmployeeTask>().HasKey(et => new { et.EmployeeId, et.TaskId });
            modelBuilder.Entity<EmployeeTask>().HasOne<Employee>(et => et.Employee)
                .WithMany(e => e.EmployeeTasks)
                .HasForeignKey(et => et.EmployeeId);

            modelBuilder.Entity<EmployeeTask>().HasOne<Task>(et => et.Task)
                .WithMany(t => t.TaskEmployees)
                .HasForeignKey(et => et.TaskId);


            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    DepartmentId = 1,
                    Email = "IT@codegym.vn",
                    Name = "IT",
                    PhoneNumber = "02343123456"
                },
                new Department()
                {
                    DepartmentId = 2,
                    Email = "hr@codegym.vn",
                    Name = "HR",
                    PhoneNumber = "02343123457"
                }
            );

            modelBuilder.Entity<Task>().HasData(
                new Task()
                {
                    TaskId = 1,
                    TaskName = "Create plan for event on 05/09/2020",
                    Deadline = DateTime.Parse("2020/09/03")
                },
                new Task()
                {
                    TaskId = 2,
                    TaskName = "Contact to confirm with MC",
                    Deadline = DateTime.Parse("2020/09/03")
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    EmployeeId = 1,
                    DepartmentId = 2,
                    Dob = DateTime.Parse("2000/01/01"),
                    Gender = true,
                    Fullname = "Nhan Nguyen"
                },
                new Employee()
                {
                    EmployeeId = 2,
                    DepartmentId = 1,
                    Dob = DateTime.Parse("1999/01/01"),
                    Gender = true,
                    Fullname = "Tung Nguyen"
                },
                new Employee()
                {
                    EmployeeId = 3,
                    DepartmentId = 1,
                    Dob = DateTime.Parse("1999/10/10"),
                    Gender = true,
                    Fullname = "Son Nguyen"
                }
            );

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask()
                {
                    EmployeeId = 1,
                    TaskId = 1
                },
                new EmployeeTask()
                {
                    EmployeeId = 2,
                    TaskId = 1
                },
                new EmployeeTask()
                {
                    EmployeeId = 3,
                    TaskId = 2
                }
            );
        }
    }
}
