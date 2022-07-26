using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReestrInvoiceId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReestrInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReestr = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateValidation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AmountReestr = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Принят к оплате" },
                    { 9, "Готов к оплате" },
                    { 10, "Оплачен" },
                    { 11, "Выставлен" },
                    { 12, "Отправлен" },
                    { 13, "Ошибка отправки" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReestrInvoiceId",
                table: "Invoices",
                column: "ReestrInvoiceId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ReestrInvoice_ReestrInvoiceId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "ReestrInvoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ReestrInvoiceId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "ReestrInvoiceId",
                table: "Invoices");
        }
    }
}
