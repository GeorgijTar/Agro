using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitDDatUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[,]
                {
                    { 14, "Договор", "Контракт" },
                    { 15, "Контракт", "Контракт" },
                    { 16, "Солглашение", "Контракт" },
                    { 17, "Договор ГПХ", "Контракт" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 17);
        }
    }
}
