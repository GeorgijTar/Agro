using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitSittingsLimitAmountInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sittings",
                columns: new[] { "Id", "LimitAmountInvoice" },
                values: new object[] { 1, 20000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sittings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
