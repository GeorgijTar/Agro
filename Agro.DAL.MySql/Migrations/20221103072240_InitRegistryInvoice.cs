using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitRegistryInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ReestrInvoice_ReestrInvoiceId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "ReestrInvoice");

            migrationBuilder.RenameColumn(
                name: "ReestrInvoiceId",
                table: "Invoices",
                newName: "RegistryInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ReestrInvoiceId",
                table: "Invoices",
                newName: "IX_Invoices_RegistryInvoiceId");

            migrationBuilder.CreateTable(
                name: "RegistryInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDispatch = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistryInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistryInvoices_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistryInvoices_StatusId",
                table: "RegistryInvoices",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_RegistryInvoices_RegistryInvoiceId",
                table: "Invoices",
                column: "RegistryInvoiceId",
                principalTable: "RegistryInvoices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_RegistryInvoices_RegistryInvoiceId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "RegistryInvoices");

            migrationBuilder.RenameColumn(
                name: "RegistryInvoiceId",
                table: "Invoices",
                newName: "ReestrInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_RegistryInvoiceId",
                table: "Invoices",
                newName: "IX_Invoices_ReestrInvoiceId");

            migrationBuilder.CreateTable(
                name: "ReestrInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AmountReestr = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateReestr = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReestrInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReestrInvoice_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReestrInvoice_StatusId",
                table: "ReestrInvoice",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ReestrInvoice_ReestrInvoiceId",
                table: "Invoices",
                column: "ReestrInvoiceId",
                principalTable: "ReestrInvoice",
                principalColumn: "Id");
        }
    }
}
