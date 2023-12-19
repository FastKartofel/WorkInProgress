using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kol02.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedTypee",
                columns: table => new
                {
                    IdBreedType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BreedType_PK", x => x.IdBreedType);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupervisor = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Volunteer_PK", x => x.IdVolunteer);
                    table.ForeignKey(
                        name: "Volunteer_Volunteer",
                        column: x => x.IdSupervisor,
                        principalTable: "Volunteer",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    IdPet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBreedType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsMale = table.Column<int>(type: "int", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ApproximatedDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DateAdopted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pet_PK", x => x.IdPet);
                    table.ForeignKey(
                        name: "Pet_BreedType",
                        column: x => x.IdBreedType,
                        principalTable: "BreedTypee",
                        principalColumn: "IdBreedType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerPet",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(type: "int", nullable: false),
                    IdPet = table.Column<int>(type: "int", nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("VolunteerPet_PK", x => new { x.IdPet, x.IdVolunteer });
                    table.ForeignKey(
                        name: "VolunteerPet_Pet",
                        column: x => x.IdPet,
                        principalTable: "Pet",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VolunteerPet_Volunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Volunteer",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BreedTypee",
                columns: new[] { "IdBreedType", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "opis1", "Ork" },
                    { 2, "opis2", "Elf" },
                    { 3, "opis3", "Krasnolud" },
                    { 4, null, "Norbert" }
                });

            migrationBuilder.InsertData(
                table: "Volunteer",
                columns: new[] { "IdVolunteer", "Address", "Email", "IdSupervisor", "Name", "Phone", "StartingDate", "Surname" },
                values: new object[,]
                {
                    { 1, "adres1", "email1", null, "imie1", "3092385029", new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nazwisko1" },
                    { 2, "adres2", "email2", null, "imie2", "352005938209", new DateTime(2003, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nazwisko2" },
                    { 3, "adres3", "email3", null, "imie3", "984209093304", new DateTime(2002, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nazwisko3" }
                });

            migrationBuilder.InsertData(
                table: "Pet",
                columns: new[] { "IdPet", "DateAdopted", "IdBreedType", "IsMale", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, 1, "Norbi" },
                    { 2, null, 2, 1, "Rex" },
                    { 3, null, 1, 1, "Azor" },
                    { 4, null, 3, 0, "Ciapka" },
                    { 5, new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, "Latka" }
                });

            migrationBuilder.InsertData(
                table: "Volunteer",
                columns: new[] { "IdVolunteer", "Address", "Email", "IdSupervisor", "Name", "Phone", "StartingDate", "Surname" },
                values: new object[] { 4, "adres4", "email4", 1, "imie4", "7283479823", new DateTime(2004, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nazwisko4" });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdBreedType",
                table: "Pet",
                column: "IdBreedType");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_IdSupervisor",
                table: "Volunteer",
                column: "IdSupervisor");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerPet_IdVolunteer",
                table: "VolunteerPet",
                column: "IdVolunteer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerPet");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Volunteer");

            migrationBuilder.DropTable(
                name: "BreedTypee");
        }
    }
}
