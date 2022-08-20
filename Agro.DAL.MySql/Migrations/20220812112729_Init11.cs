using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Documents_IdentityDocumentId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "IdentityDocumentId",
                table: "People",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_People_IdentityDocumentId",
                table: "People",
                newName: "IX_People_DocumentId");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameDocument",
                table: "Documents",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 14,
                column: "TypeApplication",
                value: "Удостоверение личности");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 15,
                column: "TypeApplication",
                value: "Удостоверение личности");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 16,
                column: "TypeApplication",
                value: "Удостоверение личности");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 17,
                column: "TypeApplication",
                value: "Удостоверение личности");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 18,
                column: "TypeApplication",
                value: "Удостоверение личности");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 19,
                column: "TypeApplication",
                value: "Удостоверение личности");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 20, "Прочий документ", "Прочие документы" });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeApplication",
                value: "Документ");

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[] { 15, "Прочие документы", "Документ" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_GroupId",
                table: "Documents",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Groups_GroupId",
                table: "Documents",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Documents_DocumentId",
                table: "People",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Groups_GroupId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Documents_DocumentId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Documents_GroupId",
                table: "Documents");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "NameDocument",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "People",
                newName: "IdentityDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_People_DocumentId",
                table: "People",
                newName: "IX_People_IdentityDocumentId");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 14,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 15,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 16,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 17,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 18,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 19,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeApplication",
                value: "УЛ");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Documents_IdentityDocumentId",
                table: "People",
                column: "IdentityDocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }
    }
}
