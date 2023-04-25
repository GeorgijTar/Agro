using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitDecommissioningTmc02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurposeExpenditure",
                table: "DecommissioningTmc");

            migrationBuilder.AddColumn<int>(
                name: "PurposeExpenditureId",
                table: "DecommissioningTmc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DecommissioningTmc_PurposeExpenditureId",
                table: "DecommissioningTmc",
                column: "PurposeExpenditureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DecommissioningTmc_PurposeExpenditures_PurposeExpenditureId",
                table: "DecommissioningTmc",
                column: "PurposeExpenditureId",
                principalTable: "PurposeExpenditures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecommissioningTmc_PurposeExpenditures_PurposeExpenditureId",
                table: "DecommissioningTmc");

            migrationBuilder.DropIndex(
                name: "IX_DecommissioningTmc_PurposeExpenditureId",
                table: "DecommissioningTmc");

            migrationBuilder.DropColumn(
                name: "PurposeExpenditureId",
                table: "DecommissioningTmc");

            migrationBuilder.AddColumn<string>(
                name: "PurposeExpenditure",
                table: "DecommissioningTmc",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
