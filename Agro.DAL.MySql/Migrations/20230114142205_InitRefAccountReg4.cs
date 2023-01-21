using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitRefAccountReg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropIndex(
                name: "IX_AccountingPlanRegisters_CounterpartyId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropColumn(
                name: "CounterpartyId",
                table: "AccountingPlanRegisters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounterpartyId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_CounterpartyId",
                table: "AccountingPlanRegisters",
                column: "CounterpartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters",
                column: "CounterpartyId",
                principalTable: "Counterparties",
                principalColumn: "Id");
        }
    }
}
