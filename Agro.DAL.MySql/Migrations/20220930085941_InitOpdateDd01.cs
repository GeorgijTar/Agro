using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitOpdateDd01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counterparties_Statuses_StatusId",
                table: "Counterparties");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Counterparties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 21, "Закупка", "Контракт" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 22, "Продажа", "Контракт" });

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparties_Statuses_StatusId",
                table: "Counterparties",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counterparties_Statuses_StatusId",
                table: "Counterparties");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Counterparties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Counterparties_Statuses_StatusId",
                table: "Counterparties",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
