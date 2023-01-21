using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitUnitOkeisRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Abbreviation", "Name", "OkeiCode" },
                values: new object[] { "л", "Литр", "112" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Abbreviation", "Name", "OkeiCode" },
                values: new object[] { "л.", "Лист", "625" });
        }
    }
}
