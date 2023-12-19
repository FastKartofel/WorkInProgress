using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrzygotowaniaDoTestu2.DAL;

public partial class Kolos2Context : DbContext
{
    public Kolos2Context()
    {
    }

    public Kolos2Context(DbContextOptions<Kolos2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<Study> Studies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=kolos2;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudent).HasName("PK__Student__61B35104D68F6656");

            entity.ToTable("Student");

            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.IndexNumber).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.Studies).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdStudies)
                .HasConstraintName("FK__Student__IdStudi__4316F928");

            entity.HasMany(d => d.StudentGroup).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentStudentGroup",
                    r => r.HasOne<StudentGroup>().WithMany()
                        .HasForeignKey("IdStudentGroup")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_S__IdStu__48CFD27E"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_S__IdStu__47DBAE45"),
                    j =>
                    {
                        j.HasKey("IdStudent", "IdStudentGroup").HasName("PK__Student___5879A76B9B0D9C13");
                        j.ToTable("Student_StudentGroup");
                    });
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.IdStudentGroup).HasName("PK__StudentG__9CAF66F268F54B5B");

            entity.ToTable("StudentGroup");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Study>(entity =>
        {
            entity.HasKey(e => e.IdStudies).HasName("PK__Studies__6C5D10CC8FF538B8");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
