using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitAccountingPlanRegisterRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionOperation",
                table: "AccountingPlanRegisters",
                newName: "ContaParty");

            migrationBuilder.RenameColumn(
                name: "ContaString",
                table: "AccountingPlanRegisters",
                newName: "ContaObject");

            migrationBuilder.RenameColumn(
                name: "ContaDop",
                table: "AccountingPlanRegisters",
                newName: "ContaDoc");

            migrationBuilder.RenameColumn(
                name: "Conta",
                table: "AccountingPlanRegisters",
                newName: "ContaAction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContaParty",
                table: "AccountingPlanRegisters",
                newName: "DescriptionOperation");

            migrationBuilder.RenameColumn(
                name: "ContaObject",
                table: "AccountingPlanRegisters",
                newName: "ContaString");

            migrationBuilder.RenameColumn(
                name: "ContaDoc",
                table: "AccountingPlanRegisters",
                newName: "ContaDop");

            migrationBuilder.RenameColumn(
                name: "ContaAction",
                table: "AccountingPlanRegisters",
                newName: "Conta");
        }
    }
}
