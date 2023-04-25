using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitPurposeExpenditureUpdateAccountingPlane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurposeExpenditures_RulesAccounting_RulesAccountingId",
                table: "PurposeExpenditures");

            migrationBuilder.RenameColumn(
                name: "RulesAccountingId",
                table: "PurposeExpenditures",
                newName: "AccountingPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PurposeExpenditures_RulesAccountingId",
                table: "PurposeExpenditures",
                newName: "IX_PurposeExpenditures_AccountingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurposeExpenditures_AccountingPlans_AccountingPlanId",
                table: "PurposeExpenditures",
                column: "AccountingPlanId",
                principalTable: "AccountingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurposeExpenditures_AccountingPlans_AccountingPlanId",
                table: "PurposeExpenditures");

            migrationBuilder.RenameColumn(
                name: "AccountingPlanId",
                table: "PurposeExpenditures",
                newName: "RulesAccountingId");

            migrationBuilder.RenameIndex(
                name: "IX_PurposeExpenditures_AccountingPlanId",
                table: "PurposeExpenditures",
                newName: "IX_PurposeExpenditures_RulesAccountingId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurposeExpenditures_RulesAccounting_RulesAccountingId",
                table: "PurposeExpenditures",
                column: "RulesAccountingId",
                principalTable: "RulesAccounting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
