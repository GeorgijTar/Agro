using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "LandPlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LandPlots_StatusId",
                table: "LandPlots",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Statuses_StatusId",
                table: "LandPlots",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Statuses_StatusId",
                table: "LandPlots");

            migrationBuilder.DropIndex(
                name: "IX_LandPlots_StatusId",
                table: "LandPlots");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "LandPlots");
        }
    }
}
