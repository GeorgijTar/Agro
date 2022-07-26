using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOkei_Statuses_StatusId",
                table: "UnitsOkei");

            migrationBuilder.DropIndex(
                name: "IX_UnitsOkei_StatusId",
                table: "UnitsOkei");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "UnitsOkei");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "UnitsOkei",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 6,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 7,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 8,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 9,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 10,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 11,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 12,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 13,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 14,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 15,
                column: "StatusId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 16,
                column: "StatusId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOkei_StatusId",
                table: "UnitsOkei",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOkei_Statuses_StatusId",
                table: "UnitsOkei",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
