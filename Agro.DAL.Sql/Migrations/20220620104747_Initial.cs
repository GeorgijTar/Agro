using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeApplication = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counterparties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TypeDocId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    PayName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Inn = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Kpp = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Ogrn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Okpo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counterparties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Counterparties_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Counterparties_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Counterparties_Types_TypeDocId",
                        column: x => x.TypeDocId,
                        principalTable: "Types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: false),
                    NameBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bs = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bik = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Ks = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_Counterparties_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "Counterparties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankDetails_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentGroupId" },
                values: new object[,]
                {
                    { 1, "Контрагенты", null },
                    { 2, "Покупатели", null },
                    { 3, "Поставщики", null }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Черновик" },
                    { 2, "Новый" },
                    { 3, "Действующий" },
                    { 4, "Заблокировано" },
                    { 5, "Актуально" },
                    { 6, "Удален" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "TypeApplication" },
                values: new object[,]
                {
                    { 1, "Юридическое лицо", "Counterparty" },
                    { 2, "Индивидуальный предприниматель", "Counterparty" },
                    { 3, "Государственный орган", "Counterparty" },
                    { 4, "Физическое лицо", "Counterparty" },
                    { 5, "Юридический адрес", "Address" },
                    { 6, "Фактический адрес", "Address" },
                    { 7, "Почтовый адрес", "Address" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_CounterpartyId",
                table: "BankDetails",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_StatusId",
                table: "BankDetails",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_GroupId",
                table: "Counterparties",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_StatusId",
                table: "Counterparties",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Counterparties_TypeDocId",
                table: "Counterparties",
                column: "TypeDocId");

            migrationBuilder.CreateIndex(
                name: "NameIndex",
                table: "Counterparties",
                column: "Inn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentGroupId",
                table: "Groups",
                column: "ParentGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Counterparties");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
