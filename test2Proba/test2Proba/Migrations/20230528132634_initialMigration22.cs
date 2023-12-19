using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2Proba.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedType",
                columns: table => new
                {
                    IdBreedType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedType", x => x.IdBreedType);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupervisor = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.IdVolunteer);
                    table.ForeignKey(
                        name: "FK_Volunteers_Volunteers_IdSupervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "Volunteers",
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
                    BreedTypeIdBreedType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproximateDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAdopted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pet_BreedType_BreedTypeIdBreedType",
                        column: x => x.BreedTypeIdBreedType,
                        principalTable: "BreedType",
                        principalColumn: "IdBreedType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerPets",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerIdVolunteer = table.Column<int>(type: "int", nullable: false),
                    IdPet = table.Column<int>(type: "int", nullable: false),
                    PetIdPet = table.Column<int>(type: "int", nullable: false),
                    DateAccepted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerPets", x => x.IdVolunteer);
                    table.ForeignKey(
                        name: "FK_VolunteerPets_Pet_PetIdPet",
                        column: x => x.PetIdPet,
                        principalTable: "Pet",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerPets_Volunteers_VolunteerIdVolunteer",
                        column: x => x.VolunteerIdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_BreedTypeIdBreedType",
                table: "Pet",
                column: "BreedTypeIdBreedType");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerPets_PetIdPet",
                table: "VolunteerPets",
                column: "PetIdPet");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerPets_VolunteerIdVolunteer",
                table: "VolunteerPets",
                column: "VolunteerIdVolunteer");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdSupervisor",
                table: "Volunteers",
                column: "IdSupervisor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerPets");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "BreedType");
        }
    }
}
