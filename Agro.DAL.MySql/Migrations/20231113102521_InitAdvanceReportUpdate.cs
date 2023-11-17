using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitAdvanceReportUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountOverspending",
                table: "AdvanceReport",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceAmount",
                table: "AdvanceReport",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AdvanceReportId",
                table: "AccountingPlanRegisters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPlanRegisters_AdvanceReportId",
                table: "AccountingPlanRegisters",
                column: "AdvanceReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingPlanRegisters_AdvanceReport_AdvanceReportId",
                table: "AccountingPlanRegisters",
                column: "AdvanceReportId",
                principalTable: "AdvanceReport",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingPlanRegisters_AdvanceReport_AdvanceReportId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropIndex(
                name: "IX_AccountingPlanRegisters_AdvanceReportId",
                table: "AccountingPlanRegisters");

            migrationBuilder.DropColumn(
                name: "AmountOverspending",
                table: "AdvanceReport");

            migrationBuilder.DropColumn(
                name: "BalanceAmount",
                table: "AdvanceReport");

            migrationBuilder.DropColumn(
                name: "AdvanceReportId",
                table: "AccountingPlanRegisters");
        }
    }
}
