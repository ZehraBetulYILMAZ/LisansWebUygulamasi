using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TWYLisans.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mailaddress",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3971), new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3983), new Guid("5c8ad19b-e355-49f5-bfa8-e215ced42baa") });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3985), new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3986), new Guid("21f4935e-8ffa-47dd-8ed8-45d19c746456") });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3987), new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3988), new Guid("ffe1b770-2303-4bc2-b233-3cea214024b5") });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3989), new DateTime(2023, 7, 25, 17, 31, 36, 685, DateTimeKind.Local).AddTicks(3990), new Guid("60b88584-a01f-4c65-a327-c8fd259b0e60") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "mailaddress",
                table: "Customers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                column: "mailaddress",
                value: new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 49 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                column: "mailaddress",
                value: new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 50 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3,
                column: "mailaddress",
                value: new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 51 });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3316), new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3328), new Guid("8b6797d6-dddf-4acc-8478-f6078996cb6d") });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3331), new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3332), new Guid("378ccfc5-a090-4fb1-b74d-6dbeb9446ab4") });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3333), new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3334), new Guid("31686c71-dc82-4361-8c2e-ce5a3afe7206") });

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "creationDate", "endingDate", "licencekey" },
                values: new object[] { new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3335), new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3335), new Guid("484feabb-6c8c-424c-a2c3-8a3162fce583") });
        }
    }
}
