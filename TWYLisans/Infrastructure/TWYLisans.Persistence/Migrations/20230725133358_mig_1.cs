using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TWYLisans.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityId = table.Column<int>(type: "int", nullable: false),
                    townname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Towns_Citys_cityId",
                        column: x => x.cityId,
                        principalTable: "Citys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ePosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    townId = table.Column<int>(type: "int", nullable: false),
                    mailaddress = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Towns_townId",
                        column: x => x.townId,
                        principalTable: "Towns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    licencekey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Licences_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licences_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "categoryName" },
                values: new object[,]
                {
                    { 1, "A kategorisi" },
                    { 2, "B kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "ID", "cityname" },
                values: new object[,]
                {
                    { 1, "Ankara" },
                    { 2, "Bursa" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "active", "categoryId", "productDescription", "productName" },
                values: new object[,]
                {
                    { 1, true, 1, "A açıklaması", "A Ürünü" },
                    { 2, true, 2, "B açıklaması", "B Ürünü" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "ID", "cityId", "townname" },
                values: new object[,]
                {
                    { 1, 1, "Çankaya" },
                    { 2, 1, "Haymana" },
                    { 3, 2, "Nilüfer" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "active", "companyName", "ePosta", "mailaddress", "phoneNumber", "townId" },
                values: new object[,]
                {
                    { 1, true, "A şirketi", "aaa@aaa.aaa", new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 49 }, "00220202101", 1 },
                    { 2, true, "B şirketi", "bbb@bbb.bbb", new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 50 }, "22202020202", 2 },
                    { 3, true, "C şirketi", "ccc@ccc.ccc", new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 51 }, "30303030303", 3 }
                });

            migrationBuilder.InsertData(
                table: "Licences",
                columns: new[] { "ID", "active", "creationDate", "customerId", "endingDate", "licencekey", "productId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3316), 1, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3328), new Guid("8b6797d6-dddf-4acc-8478-f6078996cb6d"), 1 },
                    { 2, true, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3331), 2, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3332), new Guid("378ccfc5-a090-4fb1-b74d-6dbeb9446ab4"), 2 },
                    { 3, true, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3333), 2, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3334), new Guid("31686c71-dc82-4361-8c2e-ce5a3afe7206"), 1 },
                    { 4, true, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3335), 3, new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3335), new Guid("484feabb-6c8c-424c-a2c3-8a3162fce583"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_townId",
                table: "Customers",
                column: "townId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_customerId",
                table: "Licences",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_productId",
                table: "Licences",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_cityId",
                table: "Towns",
                column: "cityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Citys");
        }
    }
}
