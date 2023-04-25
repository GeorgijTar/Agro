using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitWriteOffObjectSubTypeAddDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTypeObject_Statuses_StatusId",
                table: "SubTypeObject");

            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTypeObject",
                table: "SubTypeObject");

            migrationBuilder.RenameTable(
                name: "SubTypeObject",
                newName: "SubTypeObjects");

            migrationBuilder.RenameIndex(
                name: "IX_SubTypeObject_StatusId",
                table: "SubTypeObjects",
                newName: "IX_SubTypeObjects_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTypeObjects",
                table: "SubTypeObjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypeObjects_Statuses_StatusId",
                table: "SubTypeObjects",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_SubTypeObjects_SubTypeObjectId",
                table: "WriteOffObjects",
                column: "SubTypeObjectId",
                principalTable: "SubTypeObjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTypeObjects_Statuses_StatusId",
                table: "SubTypeObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_SubTypeObjects_SubTypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTypeObjects",
                table: "SubTypeObjects");

            migrationBuilder.RenameTable(
                name: "SubTypeObjects",
                newName: "SubTypeObject");

            migrationBuilder.RenameIndex(
                name: "IX_SubTypeObjects_StatusId",
                table: "SubTypeObject",
                newName: "IX_SubTypeObject_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTypeObject",
                table: "SubTypeObject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypeObject_Statuses_StatusId",
                table: "SubTypeObject",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects",
                column: "SubTypeObjectId",
                principalTable: "SubTypeObject",
                principalColumn: "Id");
        }
    }
}
