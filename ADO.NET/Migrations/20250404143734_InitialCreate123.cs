using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ADO.NET.Migrations
{
    public partial class InitialCreate123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Cashier",
                columns: table => new
                {
                    CashierId = table.Column<Guid>(type: "uuid", nullable: false),
                    CashierName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CashierPhoneNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashier", x => x.CashierId);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicineName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Barcode = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CashierId = table.Column<Guid>(type: "uuid", nullable: true),
                    MedicineId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.MedicineId);
                    table.ForeignKey(
                        name: "FK_Medicine_Cashier_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashier",
                        principalColumn: "CashierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicine_Medicine_MedicineId1",
                        column: x => x.MedicineId1,
                        principalTable: "Medicine",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashierMedicine",
                columns: table => new
                {
                    CashierMedicineId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: false),
                    CashierId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashierMedicine", x => x.CashierMedicineId);
                    table.ForeignKey(
                        name: "FK_CashierMedicine_Cashier_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashier",
                        principalColumn: "CashierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashierMedicine_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashierMedicine_CashierId",
                table: "CashierMedicine",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_CashierMedicine_MedicineId",
                table: "CashierMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_CashierId",
                table: "Medicine",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_MedicineId1",
                table: "Medicine",
                column: "MedicineId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashierMedicine");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Cashier");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }
    }
}
