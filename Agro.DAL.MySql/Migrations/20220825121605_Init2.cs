using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Выставленные", "Счета" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Полученные", "Счета" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Удостоверение личности", "Документ" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Собственность", "ЗУ" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Аренда", "ЗУ" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Прочие документы", "Документ" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Готовая продукция", "Товары" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Материальные запасы", "Товары" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Выставленные", "Счета" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Полученные", "Счета" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Удостоверение личности", "Документ" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Собственность", "ЗУ" });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[,]
                {
                    { 14, "Аренда", "ЗУ" },
                    { 15, "Прочие документы", "Документ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
