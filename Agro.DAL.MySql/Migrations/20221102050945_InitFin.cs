using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitFin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialStatements_DataUl_DataUlId",
                table: "FinancialStatements");

            migrationBuilder.DropIndex(
                name: "IX_FinancialStatements_DataUlId",
                table: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "DataUlId",
                table: "FinancialStatements");

            migrationBuilder.AddColumn<int>(
                name: "FinancialStatementsId",
                table: "DataUl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountPrecedingPreviousYear",
                table: "Balanceline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountPreviousYear",
                table: "Balanceline",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_FinancialStatementsId",
                table: "DataUl",
                column: "FinancialStatementsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_FinancialStatements_FinancialStatementsId",
                table: "DataUl",
                column: "FinancialStatementsId",
                principalTable: "FinancialStatements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_FinancialStatements_FinancialStatementsId",
                table: "DataUl");

            migrationBuilder.DropIndex(
                name: "IX_DataUl_FinancialStatementsId",
                table: "DataUl");

            migrationBuilder.DropColumn(
                name: "FinancialStatementsId",
                table: "DataUl");

            migrationBuilder.DropColumn(
                name: "AmountPrecedingPreviousYear",
                table: "Balanceline");

            migrationBuilder.DropColumn(
                name: "AmountPreviousYear",
                table: "Balanceline");

            migrationBuilder.AddColumn<int>(
                name: "DataUlId",
                table: "FinancialStatements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_DataUlId",
                table: "FinancialStatements",
                column: "DataUlId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialStatements_DataUl_DataUlId",
                table: "FinancialStatements",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");
        }
    }
}
