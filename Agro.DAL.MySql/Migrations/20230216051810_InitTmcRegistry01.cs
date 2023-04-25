using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitTmcRegistry01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TmcRegisters_ComingTmc_ComingTmcId",
                table: "TmcRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "ComingTmcId",
                table: "TmcRegisters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TmcRegisters_ComingTmc_ComingTmcId",
                table: "TmcRegisters",
                column: "ComingTmcId",
                principalTable: "ComingTmc",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TmcRegisters_ComingTmc_ComingTmcId",
                table: "TmcRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "ComingTmcId",
                table: "TmcRegisters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TmcRegisters_ComingTmc_ComingTmcId",
                table: "TmcRegisters",
                column: "ComingTmcId",
                principalTable: "ComingTmc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
