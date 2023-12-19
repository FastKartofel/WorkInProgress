using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kol2.Entities.Configurations;

public class VolunteerEfConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.HasKey(volunteer => volunteer.IdVolunteer).HasName("Volunteer_PK");
        builder.Property(volunteer => volunteer.IdSupervisor);
        builder.Property(volunteer => volunteer.Name).IsRequired().HasMaxLength(100);
        builder.Property(volunteer => volunteer.Surname).IsRequired().HasMaxLength(100);
        builder.Property(volunteer => volunteer.Phone).IsRequired().HasMaxLength(100);
        builder.Property(volunteer => volunteer.Address).IsRequired().HasMaxLength(100);
        builder.Property(volunteer => volunteer.Email).IsRequired().HasMaxLength(100);
        builder.Property(volunteer => volunteer.StartingDate).IsRequired().HasDefaultValueSql("GETDATE()");

        builder
            .HasOne(x => x.Supervisor)
            .WithMany(volunteer => volunteer.Volunteers)
            .HasForeignKey(volunteer => volunteer.IdSupervisor)
            .HasConstraintName("Volunteer_Volunteer")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Volunteer");
    }
}