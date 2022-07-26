using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Ndses_NdsId",
                table: "ProductInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInvoice_Products_ProductId",
                table: "ProductInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInvoice",
                table: "ProductInvoice");

            migrationBuilder.RenameTable(
                name: "ProductInvoice",
                newName: "ProductsInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInvoice_ProductId",
                table: "ProductsInvoice",
                newName: "IX_ProductsInvoice_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInvoice_NdsId",
                table: "ProductsInvoice",
                newName: "IX_ProductsInvoice_NdsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInvoice_InvoiceId",
                table: "ProductsInvoice",
                newName: "IX_ProductsInvoice_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInvoice",
                table: "ProductsInvoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInvoice_Invoices_InvoiceId",
                table: "ProductsInvoice",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInvoice_Ndses_NdsId",
                table: "ProductsInvoice",
                column: "NdsId",
                principalTable: "Ndses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInvoice_Products_ProductId",
                table: "ProductsInvoice",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInvoice_Invoices_InvoiceId",
                table: "ProductsInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInvoice_Ndses_NdsId",
                table: "ProductsInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInvoice_Products_ProductId",
                table: "ProductsInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInvoice",
                table: "ProductsInvoice");

            migrationBuilder.RenameTable(
                name: "ProductsInvoice",
                newName: "ProductInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInvoice_ProductId",
                table: "ProductInvoice",
                newName: "IX_ProductInvoice_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInvoice_NdsId",
                table: "ProductInvoice",
                newName: "IX_ProductInvoice_NdsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInvoice_InvoiceId",
                table: "ProductInvoice",
                newName: "IX_ProductInvoice_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInvoice",
                table: "ProductInvoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Invoices_InvoiceId",
                table: "ProductInvoice",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Ndses_NdsId",
                table: "ProductInvoice",
                column: "NdsId",
                principalTable: "Ndses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInvoice_Products_ProductId",
                table: "ProductInvoice",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
