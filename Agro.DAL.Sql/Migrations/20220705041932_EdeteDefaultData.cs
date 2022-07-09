using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class EdeteDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsSelect",
                value: true);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsSelect",
                value: true);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsSelect",
                value: true);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsSelect",
                value: true);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsSelect",
                value: true);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsSelect",
                value: true);

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 10, "02-3", true, "Амортизация арендованных основных средств", 7, 5 },
                    { 11, "03", true, "Доходные вложения в материальные ценности", 1, 5 },
                    { 12, "04", true, "Нематериальные активы", 1, 5 },
                    { 13, "05", true, "Амортизация нематериальных активов", 1, 5 },
                    { 14, "07", true, "Оборудование к установке", 1, 5 },
                    { 15, "08", false, "Вложения во внеоборотные активы", 1, 5 },
                    { 24, "09", true, "Отложенные налоговые активы", 1, 5 },
                    { 25, "10", false, "Материалы", 1, 5 },
                    { 37, "14", false, "Резервы под снижение стоимости материальных ценностей", 1, 5 },
                    { 41, "19", false, "НДС по приобретенным ценностям", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 16, "08-1", true, "Приобретение земельных участков", 15, 5 },
                    { 17, "08-2", true, "Приобретение объектов природопользования", 15, 5 },
                    { 18, "08-3", true, "Строительство объектов основных средств", 15, 5 },
                    { 20, "08-4", true, "Приобретение объектов основных средств", 15, 5 },
                    { 21, "08-5", true, "Приобретение нематериальных активов", 15, 5 },
                    { 22, "08-6", true, "Закладка и выращивание многолетних насаждений", 15, 5 },
                    { 23, "08-7", true, "Выполнение научно-исследовательских, опытно-конструкторских и технологических работ", 15, 5 },
                    { 26, "10-1", true, "Сырье и материалы", 25, 5 },
                    { 27, "10-2", true, "Семена и посадочный материал", 25, 5 },
                    { 28, "10-3", true, "Топливо (ГСМ)", 25, 5 },
                    { 29, "10-4", true, "Покупные полуфабрикаты и комплектующие изделия, конструкции и детали", 25, 5 },
                    { 30, "10-5", true, "Запасные части", 25, 5 },
                    { 31, "10-6", true, "Удобрения, средства защиты растений", 25, 5 },
                    { 32, "10-8", true, "Тара и тарные материалы", 25, 5 },
                    { 33, "10-9", true, "Инвентарь и хозяйственные принадлежности", 25, 5 },
                    { 34, "10-10", true, "Специальная одежда, средства индивидуальной защиты", 25, 5 },
                    { 35, "10-11", true, "Материалы и сырье, переданные в переработку на сторону", 25, 5 },
                    { 36, "10-12", true, "Прочие материалы", 25, 5 },
                    { 38, "14-1", true, "Резервы под снижение стоимости материалов", 37, 5 },
                    { 39, "14-2", true, "Резервы под снижение стоимости товаров", 37, 5 },
                    { 40, "14-3", true, "Резервы под снижение стоимости готовой продукции", 37, 5 },
                    { 42, "19-1", true, "НДС по приобретенным товарно-материальным ценностям, работам, услугам", 41, 5 },
                    { 43, "19-2", true, "НДС по приобретённым продуктам питания", 41, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 19, "08-3-1", true, "Строительство объектов основных средств (Ангар)", 18, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsSelect",
                value: false);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsSelect",
                value: false);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsSelect",
                value: false);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsSelect",
                value: false);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsSelect",
                value: false);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsSelect",
                value: false);
        }
    }
}
