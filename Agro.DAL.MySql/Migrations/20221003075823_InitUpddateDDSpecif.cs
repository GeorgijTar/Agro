using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitUpddateDDSpecif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 18, "Соглашение", "Спецификация" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 19, "Спецификация", "Спецификация" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 20, "Дополнительное соглашение", "Спецификация" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
