using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitTypeGroupObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TypesObject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "GroupObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TypesObject_StatusId",
                table: "TypesObject",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupObjects_StatusId",
                table: "GroupObjects",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupObjects_Statuses_StatusId",
                table: "GroupObjects",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypesObject_Statuses_StatusId",
                table: "TypesObject",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupObjects_Statuses_StatusId",
                table: "GroupObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TypesObject_Statuses_StatusId",
                table: "TypesObject");

            migrationBuilder.DropIndex(
                name: "IX_TypesObject_StatusId",
                table: "TypesObject");

            migrationBuilder.DropIndex(
                name: "IX_GroupObjects_StatusId",
                table: "GroupObjects");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TypesObject");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "GroupObjects");
        }
    }
}
