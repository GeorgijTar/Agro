using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.MySql.Migrations
{
    public partial class InitChecUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_Founders_FounderId",
                table: "DataUl");

            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_UnscrupulousSupplierRecord_UnscrupulousSupplierRecord~",
                table: "DataUl");

            migrationBuilder.DropIndex(
                name: "IX_DataUl_UnscrupulousSupplierRecordId",
                table: "DataUl");

            migrationBuilder.DropColumn(
                name: "UnscrupulousSupplierRecordId",
                table: "DataUl");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseNumber",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseDescription",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Kpp",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "UnscrupulousSupplierRecord",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateApproval",
                table: "UnscrupulousSupplierRecord",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "DataUlId",
                table: "UnscrupulousSupplierRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FounderId",
                table: "DataUl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UnscrupulousSupplierRecord_DataUlId",
                table: "UnscrupulousSupplierRecord",
                column: "DataUlId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_Founders_FounderId",
                table: "DataUl",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnscrupulousSupplierRecord_DataUl_DataUlId",
                table: "UnscrupulousSupplierRecord",
                column: "DataUlId",
                principalTable: "DataUl",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataUl_Founders_FounderId",
                table: "DataUl");

            migrationBuilder.DropForeignKey(
                name: "FK_UnscrupulousSupplierRecord_DataUl_DataUlId",
                table: "UnscrupulousSupplierRecord");

            migrationBuilder.DropIndex(
                name: "IX_UnscrupulousSupplierRecord_DataUlId",
                table: "UnscrupulousSupplierRecord");

            migrationBuilder.DropColumn(
                name: "DataUlId",
                table: "UnscrupulousSupplierRecord");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "ShortName",
                keyValue: null,
                column: "ShortName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "RegistrationNumber",
                keyValue: null,
                column: "RegistrationNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "PurchaseNumber",
                keyValue: null,
                column: "PurchaseNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseNumber",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "PurchaseDescription",
                keyValue: null,
                column: "PurchaseDescription",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseDescription",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "Kpp",
                keyValue: null,
                column: "Kpp",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kpp",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "Inn",
                keyValue: null,
                column: "Inn",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Inn",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UnscrupulousSupplierRecord",
                keyColumn: "FullName",
                keyValue: null,
                column: "FullName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "UnscrupulousSupplierRecord",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePublication",
                table: "UnscrupulousSupplierRecord",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateApproval",
                table: "UnscrupulousSupplierRecord",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FounderId",
                table: "DataUl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnscrupulousSupplierRecordId",
                table: "DataUl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataUl_UnscrupulousSupplierRecordId",
                table: "DataUl",
                column: "UnscrupulousSupplierRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_Founders_FounderId",
                table: "DataUl",
                column: "FounderId",
                principalTable: "Founders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataUl_UnscrupulousSupplierRecord_UnscrupulousSupplierRecord~",
                table: "DataUl",
                column: "UnscrupulousSupplierRecordId",
                principalTable: "UnscrupulousSupplierRecord",
                principalColumn: "Id");
        }
    }
}
