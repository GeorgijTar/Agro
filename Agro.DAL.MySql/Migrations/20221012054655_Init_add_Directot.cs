using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init_add_Directot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReg",
                table: "RegFns");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Okveds",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OgrDostup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Inn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypePosition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NamePosition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unreliability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MassManager = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisqualifiedPerson = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisqualifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DisqualifiedOff = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ogrn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOgrn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    DirectorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrn_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ogrn_Directors_DirectorId1",
                        column: x => x.DirectorId1,
                        principalTable: "Directors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_DirectorId",
                table: "Ogrn",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrn_DirectorId1",
                table: "Ogrn",
                column: "DirectorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogrn");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Okveds");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReg",
                table: "RegFns",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
