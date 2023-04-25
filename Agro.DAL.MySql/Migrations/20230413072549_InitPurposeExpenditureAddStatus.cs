using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitPurposeExpenditureAddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PurposeExpenditures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurposeExpenditures_StatusId",
                table: "PurposeExpenditures",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurposeExpenditures_Statuses_StatusId",
                table: "PurposeExpenditures",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurposeExpenditures_Statuses_StatusId",
                table: "PurposeExpenditures");

            migrationBuilder.DropIndex(
                name: "IX_PurposeExpenditures_StatusId",
                table: "PurposeExpenditures");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PurposeExpenditures");
        }
    }
}
