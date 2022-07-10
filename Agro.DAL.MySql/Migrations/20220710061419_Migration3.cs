using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankDetailsOrgId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 10, "Выставленный", "Счета" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 11, "Полученный", "Счета" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BankDetailsOrgId",
                table: "Invoices",
                column: "BankDetailsOrgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_BankDetails_BankDetailsOrgId",
                table: "Invoices",
                column: "BankDetailsOrgId",
                principalTable: "BankDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_BankDetails_BankDetailsOrgId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_BankDetailsOrgId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "BankDetailsOrgId",
                table: "Invoices");
        }
    }
}
