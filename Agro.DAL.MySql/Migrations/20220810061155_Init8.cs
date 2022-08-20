using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Fields_FieldId",
                table: "LandPlots");

            migrationBuilder.DropIndex(
                name: "IX_LandPlots_FieldId",
                table: "LandPlots");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "LandPlots");

            migrationBuilder.CreateTable(
                name: "FieldLandPlot",
                columns: table => new
                {
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    LandPlotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldLandPlot", x => new { x.FieldsId, x.LandPlotsId });
                    table.ForeignKey(
                        name: "FK_FieldLandPlot_Fields_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldLandPlot_LandPlots_LandPlotsId",
                        column: x => x.LandPlotsId,
                        principalTable: "LandPlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FieldLandPlot_LandPlotsId",
                table: "FieldLandPlot",
                column: "LandPlotsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldLandPlot");

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "LandPlots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LandPlots_FieldId",
                table: "LandPlots",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Fields_FieldId",
                table: "LandPlots",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
