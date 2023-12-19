using Microsoft.EntityFrameworkCore;

namespace test2Proba.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected MainDbContext() 
        {
        }

        public DbSet<BreedType> BreedType { get; set; }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<VolunteerPet> VolunteerPets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=test2;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer>()
                .HasMany(v => v.Subordinates)
                .WithOne(v => v.Supervisor)
                .HasForeignKey(v => v.IdSupervisor)
                .OnDelete(DeleteBehavior.Restrict);  // Restrict cascading delete

            modelBuilder.Entity<VolunteerPet>()
                .HasOne(vp => vp.Volunteer)
                .WithMany(v => v.VolunteerPets)
                .OnDelete(DeleteBehavior.Restrict);  // Restrict cascading delete

            modelBuilder.Entity<BreedType>().HasData(
            new BreedType { IdBreedType = 1, Name = "Breed1", Description = "This is Breed 1" },
            new BreedType { IdBreedType = 2, Name = "Breed2", Description = "This is Breed 2" }
        );

            modelBuilder.Entity<Volunteer>().HasData(
                new Volunteer { IdVolunteer = 1, Name = "John", Surname = "Doe", Phone = "+1234567890", Address = "Address 1", Email = "john@example.com", StartingDate = DateTime.Now },
                new Volunteer { IdVolunteer = 2, IdSupervisor = 1, Name = "Jane", Surname = "Doe", Phone = "+0987654321", Address = "Address 2", Email = "jane@example.com", StartingDate = DateTime.Now }
            );

            
        }

    }
}
