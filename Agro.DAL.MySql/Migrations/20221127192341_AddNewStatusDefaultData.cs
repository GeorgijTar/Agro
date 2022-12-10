using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class AddNewStatusDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Statuses_StatusId",
                table: "LandPlots");

            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Types_TypeId",
                table: "LandPlots");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "LandPlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "LandPlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Одобрен" });

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Statuses_StatusId",
                table: "LandPlots",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Types_TypeId",
                table: "LandPlots",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Statuses_StatusId",
                table: "LandPlots");

            migrationBuilder.DropForeignKey(
                name: "FK_LandPlots_Types_TypeId",
                table: "LandPlots");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "LandPlots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "LandPlots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Statuses_StatusId",
                table: "LandPlots",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandPlots_Types_TypeId",
                table: "LandPlots",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
