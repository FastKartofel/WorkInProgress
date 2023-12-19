using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test2Proba.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BreedType",
                columns: new[] { "IdBreedType", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This is Breed 1", "Breed1" },
                    { 2, "This is Breed 2", "Breed2" }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "IdVolunteer", "Address", "Email", "IdSupervisor", "Name", "Phone", "StartingDate", "Surname" },
                values: new object[,]
                {
                    { 1, "Address 1", "john@example.com", null, "John", "+1234567890", new DateTime(2023, 5, 28, 15, 34, 30, 777, DateTimeKind.Local).AddTicks(4481), "Doe" },
                    { 2, "Address 2", "jane@example.com", 1, "Jane", "+0987654321", new DateTime(2023, 5, 28, 15, 34, 30, 777, DateTimeKind.Local).AddTicks(4517), "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BreedType",
                keyColumn: "IdBreedType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BreedType",
                keyColumn: "IdBreedType",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "IdVolunteer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "IdVolunteer",
                keyValue: 1);
        }
    }
}
