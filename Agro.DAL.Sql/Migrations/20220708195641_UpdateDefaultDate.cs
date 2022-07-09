using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class UpdateDefaultDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 44, "Раздел II", false, "Производственные запасы", null, 5 });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[] { 45, "Раздел III", false, "Затраты на производство", null, 5 });

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 25,
                column: "ParentPlanId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 37,
                column: "ParentPlanId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 41,
                column: "ParentPlanId",
                value: 44);

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 46, "20", false, "Основное производство", 45, 5 },
                    { 49, "21", true, "Полуфабрикаты собственного производства", 45, 5 },
                    { 50, "23", false, "Вспомогательные производства", 45, 5 }
                });

            migrationBuilder.InsertData(
                table: "AccountingPlans",
                columns: new[] { "Id", "Code", "IsSelect", "Name", "ParentPlanId", "StatusId" },
                values: new object[,]
                {
                    { 47, "20-1", true, "Основное производство-Растениеводства", 46, 5 },
                    { 48, "20-3", true, "Сортировка сельхоз продукции", 46, 5 },
                    { 51, "23-2", true, "Ремонт зданий, сооружений и сельхоз техники", 50, 5 },
                    { 52, "23-3", true, "Электроснабжение", 50, 5 },
                    { 53, "23-3", true, "Электроснабжение", 50, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 25,
                column: "ParentPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 37,
                column: "ParentPlanId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountingPlans",
                keyColumn: "Id",
                keyValue: 41,
                column: "ParentPlanId",
                value: 1);
        }
    }
}
