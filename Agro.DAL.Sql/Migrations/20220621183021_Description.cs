using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BankDetails",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Counterparties",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BankDetails",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Counterparties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BankDetails");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "BankDetails",
                newName: "Name");
        }
    }
}
