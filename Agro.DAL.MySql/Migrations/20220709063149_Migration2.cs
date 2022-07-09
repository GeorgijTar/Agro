using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Основное производство - Растениеводство");

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23-4", "Водоснаюжение" });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 54, "23-5", true, "Автотранспорт", 50, 5 },
                    { 55, "23-6", true, "Газоснабжение", 50, 5 },
                    { 56, "25", false, "Общепроизводственные расходы", 45, 5 },
                    { 58, "26", true, "Общехозяйственные расходы", 45, 5 },
                    { 59, "Раздел IV", false, "Готовая продукция и товары", null, 5 },
                    { 66, "Раздел V", false, "Денежные средства", null, 5 },
                    { 77, "Раздел VI", false, "Расчеты", null, 5 },
                    { 106, "Раздел VII", false, "Капитал", null, 5 },
                    { 111, "Раздел VIII", false, "Финансовые результаты", null, 5 },
                    { 124, "Раздел IX", false, "Забалансовые счета", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 57, "25-1", true, "Общепроизводственные расходы - Растениеводства", 56, 5 },
                    { 60, "40", true, "Выпуск продукции (Продукция с поля)", 59, 5 },
                    { 61, "41", false, "Товары", 59, 5 },
                    { 64, "43", false, "Готовая продукция", 59, 5 },
                    { 67, "50", true, "Касса", 66, 5 },
                    { 68, "51", false, "Расчетные счета", 66, 5 },
                    { 72, "52", false, "Валютные счета", 66, 5 },
                    { 74, "55", false, "Специальные счета в банках", 66, 5 },
                    { 76, "57", true, "Переводы в пути", 66, 5 },
                    { 78, "60", false, "Расчеты с поставщиками и подрядчиками", 77, 5 },
                    { 81, "62", false, "Расчеты с покупателями, заказчиками", 77, 5 },
                    { 83, "66", false, "Расчеты по краткосрочным кредитам и займам", 77, 5 },
                    { 84, "67", false, "Расчеты по долгосрочным кредитам и займам", 77, 5 },
                    { 85, "68", false, "Расчеты по налогам и сборам", 77, 5 },
                    { 93, "69", false, "Расчеты по социальному страхованию и обеспечению", 77, 5 },
                    { 99, "70", true, "Расчеты с персоналом по оплате труда", 77, 5 },
                    { 100, "71", true, "Расчеты с подотчетными лицами", 77, 5 },
                    { 101, "73", true, "Расчеты с персоналом по прочим операциям", 77, 5 },
                    { 102, "75", true, "Расчеты с учредителями", 77, 5 },
                    { 103, "76", true, "Расчеты с разными дебиторами и кредиторами", 77, 5 },
                    { 107, "80", true, "Уставный капитал", 106, 5 },
                    { 108, "83", true, "Нераспределенная прибыль (непокрытый убыток)", 106, 5 },
                    { 109, "84", true, "Добавочный капитал", 106, 5 },
                    { 110, "86", true, "Целевое финансирование", 106, 5 },
                    { 112, "90", false, "Продажи", 111, 5 },
                    { 115, "91", false, "Прочие доходы и расходы", 111, 5 },
                    { 119, "94", true, "Недостачи и потери от порчи ценностей", 111, 5 },
                    { 120, "96", false, "Резервы предстоящих расходов", 111, 5 },
                    { 122, "97", true, "Расходы будущих периодов", 111, 5 },
                    { 123, "99", true, "Прибыли и убытки", 111, 5 },
                    { 125, "001", true, "Арендованные основные средства", 124, 5 },
                    { 126, "002", true, "Товарно-материальные ценности, принятые на ответственное хранение", 124, 5 },
                    { 127, "003", true, "Материалы, принятые в переработку", 124, 5 },
                    { 128, "004", true, "Товары, принятые на комиссию", 124, 5 },
                    { 129, "005", true, "Оборудование, принятое для монтажа", 124, 5 },
                    { 130, "006", true, "Бланки строгой отчетности", 124, 5 },
                    { 131, "007", true, "Списанная в убыток задолженность неплатежеспособных дебиторов", 124, 5 },
                    { 132, "008", true, "Обеспечение обязательств и платежей (полученные)", 124, 5 },
                    { 133, "009", true, "Обеспечение обязательств и платежей (выданные)", 124, 5 },
                    { 134, "010", true, "Износ основных средств", 124, 5 },
                    { 135, "011", true, "Основные средства, сданные в аренду", 124, 5 },
                    { 136, "012", true, "Земельные угодья", 124, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 62, "41-1", true, "Товары на складах", 61, 5 },
                    { 63, "41-2", true, "Товары к продаже", 61, 5 },
                    { 65, "43-1", true, "Готовая продукция - Растениеводства", 64, 5 },
                    { 69, "51-1", true, "Расчетный счет в Россельхозбанке", 68, 5 },
                    { 70, "51-2", true, "Расчетный счет в ОТП", 68, 5 },
                    { 71, "51-3", true, "Расчетный счет в Сбербанке", 68, 5 },
                    { 73, "52-1", true, "Валютные счета внутри страны", 72, 5 },
                    { 75, "55-3", true, "Депозитные счета", 74, 5 },
                    { 79, "60-1", true, "Расчеты с поставщиками и подрядчиками", 78, 5 },
                    { 80, "60-2", true, "Расчеты с поставщиками и подрядчиками по авансам выданным", 78, 5 },
                    { 82, "62-1", true, "Расчеты с покупателями, заказчиками", 81, 5 },
                    { 86, "68-1", true, "НДС с реализованной продукции", 85, 5 },
                    { 87, "68-3", true, "Налог на доходы физических лиц", 85, 5 },
                    { 88, "68-3Д", true, "Налог на доходы физических лиц с дивидендов", 85, 5 },
                    { 89, "68-4", true, "Налог на прибыль организаций", 85, 5 },
                    { 90, "68-5", true, "Транспортный налог с организаций", 85, 5 },
                    { 91, "68-6", true, "Налог на имущество организаций", 85, 5 },
                    { 92, "68-7", true, "Земельный налог с организаций", 85, 5 },
                    { 94, "69-1", false, "Расчеты по социальному страхованию", 93, 5 },
                    { 97, "69-2", true, "Расчеты по пенсионному обеспечению", 93, 5 },
                    { 98, "69-3", true, "Расчеты по обязательному медицинскому страхованию", 93, 5 },
                    { 104, "76АВ", true, "Расчеты с разными дебиторами и кредиторами по авансам полученным", 103, 5 },
                    { 105, "76ВА", true, "Расчеты с разными дебиторами и кредиторами по авансам выданным", 103, 5 },
                    { 113, "90-1", true, "Реализацйия продукции растениеводства", 112, 5 },
                    { 114, "90-3", true, "Реализацйия прочей продукции и ТМЦ", 112, 5 },
                    { 116, "91-1", true, "Прочие доходы", 115, 5 },
                    { 117, "91-2", true, "Прочие расходы", 115, 5 },
                    { 118, "91-9", true, "Сальдо прочих доходов и расходов", 115, 5 },
                    { 121, "96-1", true, "Резерв на оплату отпусков", 120, 5 },
                    { 137, "62-2", true, "Расчеты с покупателями, заказчиками по авансам полученным", 81, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 95, "69-1-1", true, "Расчеты по обязательному социальному страхованию", 94, 5 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 96, "69-1-2", true, "Расчеты по обязательному социальному страхованию от несчастных случаев", 94, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Основное производство-Растениеводства");

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Code", "Name" },
                values: new object[] { "23-3", "Электроснабжение" });
        }
    }
}
