using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class TypeAppl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_ParentId",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Groups",
                newName: "GroupDocId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ParentId",
                table: "Groups",
                newName: "IX_Groups_GroupDocId");

            migrationBuilder.AddColumn<string>(
                name: "TypeApplication",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "TypeApplication" },
                values: new object[] { "Покупатели", "Контрагенты" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GroupDocId", "Name", "TypeApplication" },
                values: new object[] { null, "Поставщики", "Контрагенты" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeApplication",
                value: "Контрагенты");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeApplication",
                value: "Контрагенты");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeApplication",
                value: "Контрагенты");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeApplication",
                value: "Контрагенты");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeApplication",
                value: "Адреса");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeApplication",
                value: "Адреса");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeApplication",
                value: "Адреса");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_GroupDocId",
                table: "Groups",
                column: "GroupDocId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_GroupDocId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TypeApplication",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "GroupDocId",
                table: "Groups",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_GroupDocId",
                table: "Groups",
                newName: "IX_Groups_ParentId");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Контрагенты");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Покупатели", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 3, "Поставщики", 1 });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeApplication",
                value: "Counterparty");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeApplication",
                value: "Counterparty");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeApplication",
                value: "Counterparty");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeApplication",
                value: "Counterparty");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeApplication",
                value: "Address");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeApplication",
                value: "Address");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeApplication",
                value: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_ParentId",
                table: "Groups",
                column: "ParentId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
