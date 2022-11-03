using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitFinancialStatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckBalances_DataUl_DataUlId",
                table: "CheckBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckCounterparty_Statuses_ResultStatusId",
                table: "CheckCounterparty");

            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_AuthorizedCapitals_AuthorizedCapitalId",
                table: "DataUl");

            migrationBuilder.DropIndex(
                name: "IX_CheckCounterparty_ResultStatusId",
                table: "CheckCounterparty");

            migrationBuilder.DropIndex(
                name: "IX_CheckBalances_DataUlId",
                table: "CheckBalances");

            migrationBuilder.DropColumn(
                name: "ResultStatusId",
                table: "CheckCounterparty");

            migrationBuilder.DropColumn(
                name: "DataUlId",
                table: "CheckBalances");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorizedCapitalId",
                table: "DataUl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ResultStatus",
                table: "CheckCounterparty",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UlId = table.Column<int>(type: "int", nullable: false),
                    CheckBalanceId = table.Column<int>(type: "int", nullable: false),
                    DataUlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialStatements_CheckBalances_CheckBalanceId",
                        column: x => x.CheckBalanceId,
                        principalTable: "CheckBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialStatements_DataUl_DataUlId",
                        column: x => x.DataUlId,
                        principalTable: "DataUl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialStatements_Ul_UlId",
                        column: x => x.UlId,
                        principalTable: "Ul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_CheckBalanceId",
                table: "FinancialStatements",
                column: "CheckBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_DataUlId",
                table: "FinancialStatements",
                column: "DataUlId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialStatements_UlId",
                table: "FinancialStatements",
                column: "UlId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_AuthorizedCapitals_AuthorizedCapitalId",
                table: "DataUl",
                column: "AuthorizedCapitalId",
                principalTable: "AuthorizedCapitals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_AuthorizedCapitals_AuthorizedCapitalId",
                table: "DataUl");

            migrationBuilder.DropTable(
                name: "FinancialStatements");

            migrationBuilder.DropColumn(
                name: "ResultStatus",
                table: "CheckCounterparty");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorizedCapitalId",
                table: "DataUl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultStatusId",
                table: "CheckCounterparty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataUlId",
                table: "CheckBalances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckCounterparty_ResultStatusId",
                table: "CheckCounterparty",
                column: "ResultStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBalances_DataUlId",
                table: "CheckBalances",
                column: "DataUlId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckBalances_DataUl_DataUlId",
                table: "CheckBalances",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckCounterparty_Statuses_ResultStatusId",
                table: "CheckCounterparty",
                column: "ResultStatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_AuthorizedCapitals_AuthorizedCapitalId",
                table: "DataUl",
                column: "AuthorizedCapitalId",
                principalTable: "AuthorizedCapitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
