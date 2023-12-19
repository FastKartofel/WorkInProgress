using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kol2.Entities.Configurations;

public class BreedTypeEfConfiguration : IEntityTypeConfiguration<BreedType>
{

    public void Configure(EntityTypeBuilder<BreedType> builder)
    {
        builder.HasKey(type => type.IdBreedType).HasName("BreedType_PK");
        builder.Property(type => type.Name).IsRequired().HasMaxLength(50);
        builder.Property(type => type.Description).HasMaxLength(500);
        
        builder.ToTable("BreedTypee");
    }
}