using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class EdeteDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentId",
                value: null);
        }
    }
}
