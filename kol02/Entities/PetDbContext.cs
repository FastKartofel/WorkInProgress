using kol2.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace kol2.Entities;

public class PetDbContext : DbContext
{
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<BreedType> BreedTypes { get; set; }
    public DbSet<VolunteerPet> VolunteerPets { get; set; }

    protected PetDbContext()
    {
    }

    public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreedTypeEfConfiguration).Assembly);
        
        seed(modelBuilder);
    }

    public void seed(ModelBuilder modelBuilder)
    {
        BreedType[] breedTypes =
        {
            new BreedType() { Description = "opis1", IdBreedType = 1, Name = "Ork" },
            new BreedType() { Description = "opis2", IdBreedType = 2, Name = "Elf" },
            new BreedType() { Description = "opis3", IdBreedType = 3, Name = "Krasnolud" },
            new BreedType() { IdBreedType = 4, Name = "Norbert" }

        };
        modelBuilder.Entity<BreedType>().HasData(breedTypes);
        
        Pet[] pets =
        {
            new Pet(){IdPet = 1,IdBreedType = 1,Name = "Norbi",IsMale = 1},
            new Pet(){IdPet = 2,IdBreedType = 2,Name = "Rex",IsMale = 1},
            new Pet(){IdPet = 3,IdBreedType = 1,Name = "Azor",IsMale = 1},
            new Pet(){IdPet = 4,IdBreedType = 3,Name = "Ciapka",IsMale = 0},
            new Pet(){IdPet = 5,IdBreedType = 4,Name = "Latka",IsMale = 0,DateAdopted = new DateTime(2020,11,20)}
        };
        modelBuilder.Entity<Pet>().HasData(pets);

        Volunteer[] volunteers =
        {
            new Volunteer()
            {
                IdVolunteer = 1, Name = "imie1", Surname = "nazwisko1", Phone = "3092385029", Address = "adres1",
                Email = "email1", StartingDate = new DateTime(2000, 2, 12)
            },
            new Volunteer()
            {
                IdVolunteer = 2, Name = "imie2", Surname = "nazwisko2", Phone = "352005938209", Address = "adres2",
                Email = "email2", StartingDate = new DateTime(2003, 3, 12)
            },
            new Volunteer()
            {
                IdVolunteer = 3, Name = "imie3", Surname = "nazwisko3", Phone = "984209093304", Address = "adres3",
                Email = "email3", StartingDate = new DateTime(2002, 4, 12)
            },
            new Volunteer()
            {
                IdVolunteer = 4, Name = "imie4", Surname = "nazwisko4", Phone = "7283479823", Address = "adres4",
                Email = "email4", StartingDate = new DateTime(2004, 5, 12), IdSupervisor = 1
            }
        };
        modelBuilder.Entity<Volunteer>().HasData(volunteers);

        VolunteerPet[] volunteerPets =
        {

        };
        modelBuilder.Entity<VolunteerPet>().HasData(volunteerPets);




    }   

}