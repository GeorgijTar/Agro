using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitAccountingPlanRegisterUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_ComingTmc_ComingTmcId",
                table: "AccountingPlanRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "ComingTmcId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_ComingTmc_ComingTmcId",
                table: "AccountingPlanRegisters",
                column: "ComingTmcId",
                principalTable: "ComingTmc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_ComingTmc_ComingTmcId",
                table: "AccountingPlanRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "ComingTmcId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_ComingTmc_ComingTmcId",
                table: "AccountingPlanRegisters",
                column: "ComingTmcId",
                principalTable: "ComingTmc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
