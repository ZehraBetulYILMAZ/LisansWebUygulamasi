using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWYLisans.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_customerID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "customerID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_customerID",
                table: "Products",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_customerID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "customerID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_customerID",
                table: "Products",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "ID");
        }
    }
}
