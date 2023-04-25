using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitDecommAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountingPlanId",
                table: "DecommissioningTmc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_AccountingPlanId",
                table: "DecommissioningTmc",
                column: "AccountingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DecommissioningTmc_AccountingPlans_AccountingPlanId",
                table: "DecommissioningTmc",
                column: "AccountingPlanId",
                principalTable: "AccountingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecommissioningTmc_AccountingPlans_AccountingPlanId",
                table: "DecommissioningTmc");

            migrationBuilder.DropIndex(
                name: "IX_DecommissioningTmc_AccountingPlanId",
                table: "DecommissioningTmc");

            migrationBuilder.DropColumn(
                name: "AccountingPlanId",
                table: "DecommissioningTmc");
        }
    }
}
