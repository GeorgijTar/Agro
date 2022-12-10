using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitTypeOperationPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeOperationsPay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOperationsPay", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TypeOperationsPay",
                columns: new[] { "Id", "IsEnabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Расчеты с поставщиками" },
                    { 2, true, "Единый налоговый платеж" },
                    { 3, true, "Платежи в ФСС" },
                    { 4, true, "Оплата штрафов ГИБДД" },
                    { 5, true, "Перевод на другой счет организации" },
                    { 6, true, "Перечисление заработной платы работнику" },
                    { 7, true, "Перечисление подотчетному лицу" },
                    { 8, true, "Перечисление сотруднику по договору подряда" },
                    { 9, true, "Возврат покупателю" },
                    { 10, true, "Выдача займа работнику" },
                    { 11, true, "Уплата налогов за сотрудника" },
                    { 12, true, "Прочее платежи" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOperationsPay");
        }
    }
}
