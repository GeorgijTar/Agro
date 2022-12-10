using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class initUpdateExpend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ExpenditureItems");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ExpenditureItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureItems_StatusId",
                table: "ExpenditureItems",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureItems_Statuses_StatusId",
                table: "ExpenditureItems",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureItems_Statuses_StatusId",
                table: "ExpenditureItems");

            migrationBuilder.DropIndex(
                name: "IX_ExpenditureItems_StatusId",
                table: "ExpenditureItems");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ExpenditureItems");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ExpenditureItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
