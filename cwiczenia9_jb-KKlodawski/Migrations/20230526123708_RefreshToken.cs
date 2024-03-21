using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadanie9.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "hospital",
                table: "Users",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireTime",
                schema: "hospital",
                table: "Users",
                type: "datetime",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "hospital",
                table: "Prescription",
                keyColumn: "IdPresscription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 26, 14, 37, 8, 708, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                schema: "hospital",
                table: "Prescription",
                keyColumn: "IdPresscription",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 5, 26, 14, 37, 8, 708, DateTimeKind.Local).AddTicks(4713));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "hospital",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireTime",
                schema: "hospital",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "hospital",
                table: "Prescription",
                keyColumn: "IdPresscription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 26, 10, 51, 40, 373, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                schema: "hospital",
                table: "Prescription",
                keyColumn: "IdPresscription",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 5, 26, 10, 51, 40, 373, DateTimeKind.Local).AddTicks(3667));
        }
    }
}
