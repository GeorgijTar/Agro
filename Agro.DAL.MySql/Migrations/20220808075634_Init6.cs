using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceValue",
                table: "LandPlots",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "LandPlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 13, "Собственность", "ЗУ" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 14, "Аренда", "ЗУ" });

            migrationBuilder.CreateIndex(
                name: "IX_LandPlots_TypeId",
                table: "LandPlots",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Types_TypeId",
                table: "LandPlots",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Types_TypeId",
                table: "LandPlots");

            migrationBuilder.DropIndex(
                name: "IX_LandPlots_TypeId",
                table: "LandPlots");

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "BalanceValue",
                table: "LandPlots");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "LandPlots");
        }
    }
}
