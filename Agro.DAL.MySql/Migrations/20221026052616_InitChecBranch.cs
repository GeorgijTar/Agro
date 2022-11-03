using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitChecBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_LegalAddress_InAddressId",
                table: "Branchs");

            migrationBuilder.DropForeignKey(
                name: "FK_Branchs_LegalAddress_LegalAddressId",
                table: "Branchs");

            migrationBuilder.DropIndex(
                name: "IX_Branchs_InAddressId",
                table: "Branchs");

            migrationBuilder.DropIndex(
                name: "IX_Branchs_LegalAddressId",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "InAddressId",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "LegalAddressId",
                table: "Branchs");

            migrationBuilder.AddColumn<string>(
                name: "InAddress",
                table: "Branchs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "Branchs",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InAddress",
                table: "Branchs");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "Branchs");

            migrationBuilder.AddColumn<int>(
                name: "InAddressId",
                table: "Branchs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LegalAddressId",
                table: "Branchs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_InAddressId",
                table: "Branchs",
                column: "InAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_LegalAddressId",
                table: "Branchs",
                column: "LegalAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_LegalAddress_InAddressId",
                table: "Branchs",
                column: "InAddressId",
                principalTable: "LegalAddress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branchs_LegalAddress_LegalAddressId",
                table: "Branchs",
                column: "LegalAddressId",
                principalTable: "LegalAddress",
                principalColumn: "Id");
        }
    }
}
