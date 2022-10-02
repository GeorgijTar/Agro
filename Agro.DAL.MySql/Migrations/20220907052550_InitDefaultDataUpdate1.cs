using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitDefaultDataUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeApplication",
                value: "МПЗ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8,
                column: "TypeApplication",
                value: "МПЗ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9,
                column: "TypeApplication",
                value: "МПЗ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10,
                column: "TypeApplication",
                value: "МПЗ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11,
                column: "TypeApplication",
                value: "МПЗ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeApplication",
                value: "МПЗ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13,
                column: "TypeApplication",
                value: "МПЗ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeApplication",
                value: "Материальные запасы");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8,
                column: "TypeApplication",
                value: "Материальные запасы");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9,
                column: "TypeApplication",
                value: "Материальные запасы");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10,
                column: "TypeApplication",
                value: "Материальные запасы");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11,
                column: "TypeApplication",
                value: "Материальные запасы");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeApplication",
                value: "Материальные запасы");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13,
                column: "TypeApplication",
                value: "Материальные запасы");
        }
    }
}
