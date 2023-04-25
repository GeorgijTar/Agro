using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitWriteOffObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupObjectId",
                table: "WriteOffObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "WriteOffObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeObjectId",
                table: "WriteOffObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupObjects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypesObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesObject", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_GroupObjectId",
                table: "WriteOffObjects",
                column: "GroupObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_StatusId",
                table: "WriteOffObjects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_TypeObjectId",
                table: "WriteOffObjects",
                column: "TypeObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_GroupObjects_GroupObjectId",
                table: "WriteOffObjects",
                column: "GroupObjectId",
                principalTable: "GroupObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_Statuses_StatusId",
                table: "WriteOffObjects",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_TypesObject_TypeObjectId",
                table: "WriteOffObjects",
                column: "TypeObjectId",
                principalTable: "TypesObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_GroupObjects_GroupObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_Statuses_StatusId",
                table: "WriteOffObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_TypesObject_TypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropTable(
                name: "GroupObjects");

            migrationBuilder.DropTable(
                name: "TypesObject");

            migrationBuilder.DropIndex(
                name: "IX_WriteOffObjects_GroupObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropIndex(
                name: "IX_WriteOffObjects_StatusId",
                table: "WriteOffObjects");

            migrationBuilder.DropIndex(
                name: "IX_WriteOffObjects_TypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropColumn(
                name: "GroupObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "WriteOffObjects");

            migrationBuilder.DropColumn(
                name: "TypeObjectId",
                table: "WriteOffObjects");
        }
    }
}
