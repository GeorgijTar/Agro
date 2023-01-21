using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitRef2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethods_AccountingMethodNdsId",
                table: "ComingTmcPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountingMethods",
                table: "AccountingMethods");

            migrationBuilder.RenameTable(
                name: "AccountingMethods",
                newName: "AccountingMethodsNds");

            migrationBuilder.AddColumn<int>(
                name: "AccountingMethodNdsId",
                table: "RulesAccounting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountingMethodsNds",
                table: "AccountingMethodsNds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RulesAccounting_AccountingMethodNdsId",
                table: "RulesAccounting",
                column: "AccountingMethodNdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                table: "ComingTmcPositions",
                column: "AccountingMethodNdsId",
                principalTable: "AccountingMethodsNds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RulesAccounting_AccountingMethodsNds_AccountingMethodNdsId",
                table: "RulesAccounting",
                column: "AccountingMethodNdsId",
                principalTable: "AccountingMethodsNds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                table: "ComingTmcPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_RulesAccounting_AccountingMethodsNds_AccountingMethodNdsId",
                table: "RulesAccounting");

            migrationBuilder.DropIndex(
                name: "IX_RulesAccounting_AccountingMethodNdsId",
                table: "RulesAccounting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountingMethodsNds",
                table: "AccountingMethodsNds");

            migrationBuilder.DropColumn(
                name: "AccountingMethodNdsId",
                table: "RulesAccounting");

            migrationBuilder.RenameTable(
                name: "AccountingMethodsNds",
                newName: "AccountingMethods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountingMethods",
                table: "AccountingMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethods_AccountingMethodNdsId",
                table: "ComingTmcPositions",
                column: "AccountingMethodNdsId",
                principalTable: "AccountingMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
