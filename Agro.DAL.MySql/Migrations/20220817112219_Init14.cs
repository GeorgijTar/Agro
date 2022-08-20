using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Statuses_StatusId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffList_Post_PostId",
                table: "StaffList");

            migrationBuilder.DropIndex(
                name: "IX_StaffList_PostId",
                table: "StaffList");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "StaffList");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StaffList");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Post",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffListPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffListId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffListPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffListPosition_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffListPosition_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffListPosition_StaffList_StaffListId",
                        column: x => x.StaffListId,
                        principalTable: "StaffList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StaffListPosition_DivisionId",
                table: "StaffListPosition",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffListPosition_PostId",
                table: "StaffListPosition",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffListPosition_StaffListId",
                table: "StaffListPosition",
                column: "StaffListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Statuses_StatusId",
                table: "Post",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Statuses_StatusId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "StaffListPosition");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "StaffList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "StaffList",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffList_PostId",
                table: "StaffList",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Statuses_StatusId",
                table: "Post",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffList_Post_PostId",
                table: "StaffList",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
