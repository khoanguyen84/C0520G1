using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffManagment.Migrations
{
    public partial class CreateSeedingTaskEmployeeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "Dob", "Fullname", "Gender" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhan Nguyen", true },
                    { 2, 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tung Nguyen", true },
                    { 3, 1, new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son Nguyen", true }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "Deadline", "TaskName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create plan for event on 05/09/2020" },
                    { 2, new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact to confirm with MC" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "EmployeeId", "TaskId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "EmployeeId", "TaskId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "EmployeeId", "TaskId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeTasks",
                keyColumns: new[] { "EmployeeId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeTasks",
                keyColumns: new[] { "EmployeeId", "TaskId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeTasks",
                keyColumns: new[] { "EmployeeId", "TaskId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2);
        }
    }
}
