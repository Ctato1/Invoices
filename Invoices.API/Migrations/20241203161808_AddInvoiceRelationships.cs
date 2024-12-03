using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invoices.API.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentDue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentTerms = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    ClientEmail = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    SenderAddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Addresses_ClientAddressId",
                        column: x => x.ClientAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Addresses_SenderAddressId",
                        column: x => x.SenderAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    InvoiceId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "New York", "USA", "10001", "123 Main St" },
                    { 2, "Los Angeles", "USA", "90001", "456 Elm St" },
                    { 3, "Chicago", "USA", "60001", "789 Pine St" },
                    { 4, "San Francisco", "USA", "94101", "101 Maple St" },
                    { 5, "Miami", "USA", "33101", "202 Oak St" },
                    { 6, "Seattle", "USA", "98101", "303 Birch St" },
                    { 7, "Austin", "USA", "73301", "404 Cedar St" },
                    { 8, "Hawaii", "USA", "96801", "505 Pineapple St" },
                    { 9, "Dallas", "USA", "75201", "606 Magnolia St" },
                    { 10, "Atlanta", "USA", "30301", "707 Oak Tree St" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientAddressId", "ClientEmail", "ClientName", "CreatedAt", "Description", "PaymentDue", "PaymentTerms", "SenderAddressId", "Status", "Total" },
                values: new object[,]
                {
                    { "INV-005", 2, "john.doe@example.com", "John Doe", new DateTime(2024, 12, 3, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2346), "Consulting Services", new DateTime(2024, 12, 17, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2347), 14, 1, "pending", 1500.0 },
                    { "INV-006", 2, "john.doe@example.com", "John Doe", new DateTime(2024, 12, 3, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2351), "Consulting Services", new DateTime(2025, 1, 2, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2352), 30, 1, "pending", 1500.0 },
                    { "INV-007", 2, "sarah.lee@example.com", "Sarah Lee", new DateTime(2024, 12, 3, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2355), "Graphic Design", new DateTime(2024, 12, 17, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2355), 14, 1, "pending", 2000.0 },
                    { "INV-008", 2, "sarah.lopez@example.com", "Sarah Lopez", new DateTime(2024, 12, 3, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2358), "architect Design", new DateTime(2024, 12, 17, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2358), 14, 1, "pending", 2000.0 },
                    { "INV-009", 2, "sarah.lopez@example.com", "Sarah Lopez", new DateTime(2024, 12, 3, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2361), "architect Design", new DateTime(2024, 12, 17, 20, 18, 7, 800, DateTimeKind.Local).AddTicks(2362), 14, 1, "pending", 2000.0 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "InvoiceId", "Name", "Price", "Quantity", "Total" },
                values: new object[,]
                {
                    { 1, "INV-005", "Brand Guidelines", 40.25, 2, 80.5 },
                    { 2, "INV-005", "Logo Design", 20.0, 5, 100.0 },
                    { 3, "INV-006", "Website Development", 500.0, 1, 500.0 },
                    { 4, "INV-006", "Hosting and Maintenance", 150.0, 3, 450.0 },
                    { 5, "INV-007", "Business Cards", 15.5, 10, 155.0 },
                    { 6, "INV-007", "Flyer Design", 75.0, 4, 300.0 },
                    { 7, "INV-008", "Social Media Posts", 25.0, 6, 150.0 },
                    { 8, "INV-009", "Marketing Campaign", 1000.0, 1, 1000.0 },
                    { 9, "INV-009", "SEO Optimization", 120.5, 2, 241.0 },
                    { 10, "INV-009", "Product Descriptions", 12.0, 8, 96.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientAddressId",
                table: "Invoices",
                column: "ClientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SenderAddressId",
                table: "Invoices",
                column: "SenderAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
