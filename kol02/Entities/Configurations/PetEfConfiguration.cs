using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kol2.Entities.Configurations;

public class PetEfConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(pet => pet.IdPet).HasName("Pet_PK");
        builder.Property(pet => pet.IdBreedType).IsRequired(); //uwaga tu musi byc ID
        builder.Property(pet => pet.Name).IsRequired().HasMaxLength(80);
        builder.Property(pet => pet.IsMale).IsRequired();
        builder.Property(pet => pet.DateRegistered).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(pet => pet.ApproximatedDateOfBirth).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(pet => pet.DateAdopted);

        builder
            .HasOne(pet => pet.BreedType)
            .WithMany(type => type.Pets)
            .HasForeignKey(pet => pet.IdBreedType)
            .HasConstraintName("Pet_BreedType")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("Pet");
    }
}