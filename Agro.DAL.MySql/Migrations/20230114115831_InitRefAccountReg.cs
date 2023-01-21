using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitRefAccountReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TmcRegisters",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Conta",
                table: "AccountingPlanRegisters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContaDop",
                table: "AccountingPlanRegisters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContaString",
                table: "AccountingPlanRegisters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CounterpartyId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_CounterpartyId",
                table: "AccountingPlanRegisters",
                column: "CounterpartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters",
                column: "CounterpartyId",
                principalTable: "Counterparties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropIndex(
                name: "IX_AccountingPlanRegisters_CounterpartyId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TmcRegisters");

            migrationBuilder.DropColumn(
                name: "Conta",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropColumn(
                name: "ContaDop",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropColumn(
                name: "ContaString",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropColumn(
                name: "CounterpartyId",
                table: "AccountingPlanRegisters");
        }
    }
}
