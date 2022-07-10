using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class UpdateProductInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "ProductInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "ProductInvoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }
    }
}
