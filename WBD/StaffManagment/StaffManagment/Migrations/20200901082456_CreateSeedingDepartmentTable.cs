using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffManagment.Migrations
{
    public partial class CreateSeedingDepartmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "IT@codegym.vn", "IT", "02343123456" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Email", "Name", "PhoneNumber" },
                values: new object[] { 2, "hr@codegym.vn", "HR", "02343123457" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);
        }
    }
}
