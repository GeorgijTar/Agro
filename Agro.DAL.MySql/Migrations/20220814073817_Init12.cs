using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Statuses_StatusId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Documents_DocumentId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Statuses_StatusId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DocumentId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "People",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeopleId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PeopleId",
                table: "Documents",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_People_PeopleId",
                table: "Documents",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Statuses_StatusId",
                table: "Documents",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Statuses_StatusId",
                table: "People",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_People_PeopleId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Statuses_StatusId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Statuses_StatusId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PeopleId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "Documents");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_DocumentId",
                table: "People",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Statuses_StatusId",
                table: "Documents",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Documents_DocumentId",
                table: "People",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Statuses_StatusId",
                table: "People",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
