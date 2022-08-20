using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffListPosition_Divisions_DivisionId",
                table: "StaffListPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffListPosition_Post_PostId",
                table: "StaffListPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffListPosition_StaffList_StaffListId",
                table: "StaffListPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffListPosition",
                table: "StaffListPosition");

            migrationBuilder.RenameTable(
                name: "StaffListPosition",
                newName: "StaffListPositions");

            migrationBuilder.RenameIndex(
                name: "IX_StaffListPosition_StaffListId",
                table: "StaffListPositions",
                newName: "IX_StaffListPositions_StaffListId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffListPosition_PostId",
                table: "StaffListPositions",
                newName: "IX_StaffListPositions_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffListPosition_DivisionId",
                table: "StaffListPositions",
                newName: "IX_StaffListPositions_DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffListPositions",
                table: "StaffListPositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffListPositions_Divisions_DivisionId",
                table: "StaffListPositions",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffListPositions_Post_PostId",
                table: "StaffListPositions",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffListPositions_StaffList_StaffListId",
                table: "StaffListPositions",
                column: "StaffListId",
                principalTable: "StaffList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffListPositions_Divisions_DivisionId",
                table: "StaffListPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffListPositions_Post_PostId",
                table: "StaffListPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffListPositions_StaffList_StaffListId",
                table: "StaffListPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StaffListPositions",
                table: "StaffListPositions");

            migrationBuilder.RenameTable(
                name: "StaffListPositions",
                newName: "StaffListPosition");

            migrationBuilder.RenameIndex(
                name: "IX_StaffListPositions_StaffListId",
                table: "StaffListPosition",
                newName: "IX_StaffListPosition_StaffListId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffListPositions_PostId",
                table: "StaffListPosition",
                newName: "IX_StaffListPosition_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffListPositions_DivisionId",
                table: "StaffListPosition",
                newName: "IX_StaffListPosition_DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StaffListPosition",
                table: "StaffListPosition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffListPosition_Divisions_DivisionId",
                table: "StaffListPosition",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffListPosition_Post_PostId",
                table: "StaffListPosition",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffListPosition_StaffList_StaffListId",
                table: "StaffListPosition",
                column: "StaffListId",
                principalTable: "StaffList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
