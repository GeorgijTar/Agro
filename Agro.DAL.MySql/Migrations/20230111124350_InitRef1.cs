using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitRef1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountingMethods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Принимать к вачету" });

            migrationBuilder.InsertData(
                table: "AccountingMethods",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Учитывается в стоимости товара" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountingMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountingMethods",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
