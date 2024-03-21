using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadanie9.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "hospital",
                table: "Prescription",
                keyColumn: "IdPresscription",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 5, 26, 10, 50, 19, 381, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                schema: "hospital",
                table: "Prescription",
                keyColumn: "IdPresscription",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 5, 26, 10, 50, 19, 381, DateTimeKind.Local).AddTicks(1987));
        }
    }
}
