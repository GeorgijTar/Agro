using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CashierId",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HrId",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CashierId",
                table: "Organizations",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_HrId",
                table: "Organizations",
                column: "HrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Employee_CashierId",
                table: "Organizations",
                column: "CashierId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Employee_HrId",
                table: "Organizations",
                column: "HrId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Employee_CashierId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Employee_HrId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_CashierId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_HrId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CashierId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "HrId",
                table: "Organizations");
        }
    }
}
