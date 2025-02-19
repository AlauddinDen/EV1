using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EV3.Models;

public partial class Core1234Context : DbContext
{
    public Core1234Context()
    {
    }

    public Core1234Context(DbContextOptions<Core1234Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseModule> CourseModules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB; database=Core1234; trusted_connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A736932F5F");

            entity.ToTable("Course");

            entity.Property(e => e.CourseN)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourseModule>(entity =>
        {
            entity.HasKey(e => e.CourseModuleId).HasName("PK__CourseMo__544F34430B25F524");

            entity.ToTable("CourseModule");

            entity.Property(e => e.ModuleN)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.CourseModules)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__CourseMod__Stude__29572725");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99458573FE");

            entity.ToTable("Student");

            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Imgurl).IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentN)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Student__CourseI__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
