using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWYLisans.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Products_productID",
                table: "Licences");

            migrationBuilder.AlterColumn<int>(
                name: "productID",
                table: "Licences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Products_productID",
                table: "Licences",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licences_Products_productID",
                table: "Licences");

            migrationBuilder.AlterColumn<int>(
                name: "productID",
                table: "Licences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Licences_Products_productID",
                table: "Licences",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}
