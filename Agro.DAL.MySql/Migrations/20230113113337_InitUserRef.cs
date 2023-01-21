using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitUserRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                table: "ComingTmcPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ComingTmcPositions_AccountingPlans_AccountingAccountNdsId",
                table: "ComingTmcPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_RulesAccounting_AccountingMethodsNds_AccountingMethodNdsId",
                table: "RulesAccounting");

            migrationBuilder.AlterColumn<int>(
                name: "AccountingMethodNdsId",
                table: "RulesAccounting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountingMethodNdsId",
                table: "ComingTmcPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountingAccountNdsId",
                table: "ComingTmcPositions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "System", "wE4CqoqhirL5Kt5lIcS5WDDfQObcNA/FGFB6B3msXyo=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "admin", "2CSU8F1pF7oC96qilonMtES7c/IDgIdssF0fN1N7eJI=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "Login", "Password" },
                values: new object[] { 3, null, "я", "byBvg1FJF6iqL6hrtGFWu8oHl/ugFZUo0/LMnPuj6S8=" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                table: "ComingTmcPositions",
                column: "AccountingMethodNdsId",
                principalTable: "AccountingMethodsNds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComingTmcPositions_AccountingPlans_AccountingAccountNdsId",
                table: "ComingTmcPositions",
                column: "AccountingAccountNdsId",
                principalTable: "AccountingPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RulesAccounting_AccountingMethodsNds_AccountingMethodNdsId",
                table: "RulesAccounting",
                column: "AccountingMethodNdsId",
                principalTable: "AccountingMethodsNds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                table: "ComingTmcPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ComingTmcPositions_AccountingPlans_AccountingAccountNdsId",
                table: "ComingTmcPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_RulesAccounting_AccountingMethodsNds_AccountingMethodNdsId",
                table: "RulesAccounting");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AccountingMethodNdsId",
                table: "RulesAccounting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountingMethodNdsId",
                table: "ComingTmcPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountingAccountNdsId",
                table: "ComingTmcPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "admin", "2CSU8F1pF7oC96qilonMtES7c/IDgIdssF0fN1N7eJI=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "я", "byBvg1FJF6iqL6hrtGFWu8oHl/ugFZUo0/LMnPuj6S8=" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComingTmcPositions_AccountingMethodsNds_AccountingMethodNdsId",
                table: "ComingTmcPositions",
                column: "AccountingMethodNdsId",
                principalTable: "AccountingMethodsNds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComingTmcPositions_AccountingPlans_AccountingAccountNdsId",
                table: "ComingTmcPositions",
                column: "AccountingAccountNdsId",
                principalTable: "AccountingPlans",
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
    }
}
