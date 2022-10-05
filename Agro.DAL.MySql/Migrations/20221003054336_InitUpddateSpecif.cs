using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitUpddateSpecif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScanFiles_Specifications_SpecificationContractId",
                table: "ScanFiles");

            migrationBuilder.DropIndex(
                name: "IX_ScanFiles_SpecificationContractId",
                table: "ScanFiles");

            migrationBuilder.DropColumn(
                name: "SpecificationContractId",
                table: "ScanFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecificationContractId",
                table: "ScanFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScanFiles_SpecificationContractId",
                table: "ScanFiles",
                column: "SpecificationContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScanFiles_Specifications_SpecificationContractId",
                table: "ScanFiles",
                column: "SpecificationContractId",
                principalTable: "Specifications",
                principalColumn: "Id");
        }
    }
}
