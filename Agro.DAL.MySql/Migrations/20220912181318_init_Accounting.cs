using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class init_Accounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RulesAccounting_Statuses_StatusId",
                table: "RulesAccounting");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "RulesAccounting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RulesAccounting_Statuses_StatusId",
                table: "RulesAccounting",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RulesAccounting_Statuses_StatusId",
                table: "RulesAccounting");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "RulesAccounting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RulesAccounting_Statuses_StatusId",
                table: "RulesAccounting",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
