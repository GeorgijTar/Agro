using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitWriteOffObjectSubTypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.AlterColumn<int>(
                name: "SubTypeObjectId",
                table: "WriteOffObjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects",
                column: "SubTypeObjectId",
                principalTable: "SubTypeObject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.AlterColumn<int>(
                name: "SubTypeObjectId",
                table: "WriteOffObjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects",
                column: "SubTypeObjectId",
                principalTable: "SubTypeObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
