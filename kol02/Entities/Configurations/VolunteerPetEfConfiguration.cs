using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kol2.Entities.Configurations;

public class VolunteerPetEfConfiguration : IEntityTypeConfiguration<VolunteerPet>

{
    public void Configure(EntityTypeBuilder<VolunteerPet> builder)
    {
        builder.HasKey(pet => new { pet.IdPet, pet.IdVolunteer }).HasName("VolunteerPet_PK");
        builder.Property(pet => pet.DateAccepted).IsRequired().HasDefaultValueSql("GETDATE()");

        builder.HasOne(x => x.Pet)
            .WithMany(pet => pet.VolunteerPets)
            .HasForeignKey(pet => pet.IdPet)
            .HasConstraintName("VolunteerPet_Pet")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.Volunteer)
            .WithMany(volunter => volunter.VolunteerPets)
            .HasForeignKey(pet => pet.IdVolunteer)
            .HasConstraintName("VolunteerPet_Volunteer")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("VolunteerPet");
    }
}