using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitWriteOffObjectSubType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubTypeObjectId",
                table: "WriteOffObjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubTypeObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTypeObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTypeObject_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffObjects_SubTypeObjectId",
                table: "WriteOffObjects",
                column: "SubTypeObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTypeObject_StatusId",
                table: "SubTypeObject",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects",
                column: "SubTypeObjectId",
                principalTable: "SubTypeObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriteOffObjects_SubTypeObject_SubTypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropTable(
                name: "SubTypeObject");

            migrationBuilder.DropIndex(
                name: "IX_WriteOffObjects_SubTypeObjectId",
                table: "WriteOffObjects");

            migrationBuilder.DropColumn(
                name: "SubTypeObjectId",
                table: "WriteOffObjects");
        }
    }
}
