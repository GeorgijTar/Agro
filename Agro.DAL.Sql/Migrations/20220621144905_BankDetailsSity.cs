using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class BankDetailsSity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BankDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "BankDetails");
        }
    }
}
