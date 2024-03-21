using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zadanie8.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hospital");

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "hospital",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_pk", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Mediament",
                schema: "hospital",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Mediament_pk", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "hospital",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_pk", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                schema: "hospital",
                columns: table => new
                {
                    IdPresscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_pk", x => x.IdPresscription);
                    table.ForeignKey(
                        name: "Doctor_Prescription",
                        column: x => x.IdDoctor,
                        principalSchema: "hospital",
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Patient_Prescription",
                        column: x => x.IdPatient,
                        principalSchema: "hospital",
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                schema: "hospital",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_Medicament_pk", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Prescription_Medicament_Medicament",
                        column: x => x.IdMedicament,
                        principalSchema: "hospital",
                        principalTable: "Mediament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Prescription_Medicament_Prescription",
                        column: x => x.IdPrescription,
                        principalSchema: "hospital",
                        principalTable: "Prescription",
                        principalColumn: "IdPresscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "hospital",
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Doc1@email.com", "Doc1", "Doc1" },
                    { 2, "Doc2@email.com", "Doc2", "Doc2" }
                });

            migrationBuilder.InsertData(
                schema: "hospital",
                table: "Mediament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "abc", "abc", "abc" },
                    { 2, "bcd", "bcd", "bcd" }
                });

            migrationBuilder.InsertData(
                schema: "hospital",
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "Lastname" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "P1", "P1" },
                    { 2, new DateTime(1994, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "P2", "P2" }
                });

            migrationBuilder.InsertData(
                schema: "hospital",
                table: "Prescription",
                columns: new[] { "IdPresscription", "Date", "DateDue", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 17, 21, 14, 23, 994, DateTimeKind.Local).AddTicks(4921), new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2023, 5, 17, 21, 14, 23, 994, DateTimeKind.Local).AddTicks(4994), new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "hospital",
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "aa", 2 },
                    { 1, 2, "cc", 1 },
                    { 2, 1, "bb", 4 },
                    { 2, 2, "dd", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                schema: "hospital",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                schema: "hospital",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                schema: "hospital",
                table: "Prescription_Medicament",
                column: "IdPrescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament",
                schema: "hospital");

            migrationBuilder.DropTable(
                name: "Mediament",
                schema: "hospital");

            migrationBuilder.DropTable(
                name: "Prescription",
                schema: "hospital");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "hospital");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "hospital");
        }
    }
}
