using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffList_Statuses_StatusId",
                table: "StaffList");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "StaffList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "StaffList",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Divisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_StatusId",
                table: "Divisions",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Statuses_StatusId",
                table: "Divisions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffList_Statuses_StatusId",
                table: "StaffList",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Statuses_StatusId",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffList_Statuses_StatusId",
                table: "StaffList");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_StatusId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "StaffList");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Divisions");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "StaffList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffList_Statuses_StatusId",
                table: "StaffList",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
