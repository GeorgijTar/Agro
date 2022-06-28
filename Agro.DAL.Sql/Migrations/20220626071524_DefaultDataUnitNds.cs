using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class DefaultDataUnitNds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[,]
                {
                    { 3, "Зерновые", "Готовая продукция" },
                    { 4, "Масляничные", "Готовая продукция" },
                    { 5, "Технические", "Готовая продукция" },
                    { 6, "Отходы", "Готовая продукция" },
                    { 7, "Средства защиты растений", "Материальные запасы" },
                    { 8, "Удобрения", "Материальные запасы" },
                    { 9, "Семена", "Материальные запасы" },
                    { 10, "Запасные части", "Материальные запасы" },
                    { 11, "Материалы", "Материальные запасы" },
                    { 12, "Малоценные товары, инвентарь", "Материальные запасы" },
                    { 13, "ГСМ", "Материальные запасы" }
                });

            migrationBuilder.InsertData(
                table: "Ndses",
                columns: new[] { "Id", "Name", "Percent" },
                values: new object[,]
                {
                    { 1, "Без НДС", 0 },
                    { 2, "0%", 0 },
                    { 3, "10%", 10 },
                    { 4, "20%", 20 }
                });

            migrationBuilder.InsertData(
                table: "UnitsOkei",
                columns: new[] { "Id", "Abbreviation", "Name", "OkeiCode", "StatusId" },
                values: new object[,]
                {
                    { 1, "ч", "Час", "356", 5 },
                    { 2, "мм", "Миллиметр", "003", 5 },
                    { 3, "см", "Сантиметр", "004", 5 },
                    { 4, "м", "Метр", "006", 5 },
                    { 5, "г", "Грамм", "163", 5 },
                    { 6, "кг", "Килограмм", "166", 5 },
                    { 7, "т", "Тонна; метрическая тонна (1000 кг)", "168", 5 },
                    { 8, "м3", "Кубический метр", "113", 5 },
                    { 9, "м2", "Квадратный метр", "055", 5 },
                    { 10, "га", "Гектар", "059", 5 },
                    { 11, "кВт.ч", "Киловатт-час", "245", 5 },
                    { 12, "л.", "Лист", "625", 5 },
                    { 13, "пар", "Пара (2 шт.)", "715", 5 },
                    { 14, "упак", "Упаковка", "778", 5 },
                    { 15, "шт", "Штука", "796", 5 },
                    { 16, "ц", "Центнер (метрический) (100 кг)", "206", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ndses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ndses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ndses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ndses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UnitsOkei",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
