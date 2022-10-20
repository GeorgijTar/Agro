using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitUpdateInvoce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecificationId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SpecificationId",
                table: "Invoices",
                column: "SpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Specifications_SpecificationId",
                table: "Invoices",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Specifications_SpecificationId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_SpecificationId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SpecificationId",
                table: "Invoices");
        }
    }
}
