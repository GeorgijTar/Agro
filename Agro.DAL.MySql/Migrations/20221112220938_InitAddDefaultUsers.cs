using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitAddDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "Login", "Password" },
                values: new object[] { 1, null, "admin", "2CSU8F1pF7oC96qilonMtES7c/IDgIdssF0fN1N7eJI=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "Login", "Password" },
                values: new object[] { 2, null, "я", "byBvg1FJF6iqL6hrtGFWu8oHl/ugFZUo0/LMnPuj6S8=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
