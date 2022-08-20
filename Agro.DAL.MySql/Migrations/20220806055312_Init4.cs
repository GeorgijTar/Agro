using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlot_Fields_FieldId",
                table: "LandPlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LandPlot",
                table: "LandPlot");

            migrationBuilder.RenameTable(
                name: "LandPlot",
                newName: "LandPlots");

            migrationBuilder.RenameIndex(
                name: "IX_LandPlot_FieldId",
                table: "LandPlots",
                newName: "IX_LandPlots_FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LandPlots",
                table: "LandPlots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Fields_FieldId",
                table: "LandPlots",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Fields_FieldId",
                table: "LandPlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LandPlots",
                table: "LandPlots");

            migrationBuilder.RenameTable(
                name: "LandPlots",
                newName: "LandPlot");

            migrationBuilder.RenameIndex(
                name: "IX_LandPlots_FieldId",
                table: "LandPlot",
                newName: "IX_LandPlot_FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LandPlot",
                table: "LandPlot",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlot_Fields_FieldId",
                table: "LandPlot",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
