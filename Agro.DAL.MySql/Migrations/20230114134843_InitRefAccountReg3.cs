using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitRefAccountReg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "CounterpartyId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters",
                column: "CounterpartyId",
                principalTable: "Counterparties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "CounterpartyId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_Counterparties_CounterpartyId",
                table: "AccountingPlanRegisters",
                column: "CounterpartyId",
                principalTable: "Counterparties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
