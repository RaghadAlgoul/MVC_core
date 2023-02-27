using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace coreTask3.Models;

public partial class CoreTaskContext : DbContext
{
    public CoreTaskContext()
    {
    }

    public CoreTaskContext(DbContextOptions<CoreTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=CoreTask;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.ClinicId).HasName("PK__Clinic__3347C2FD7C9D68B4");

            entity.ToTable("Clinic");

            entity.Property(e => e.ClinicId).HasColumnName("ClinicID");
            entity.Property(e => e.ClinicDis)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClinicImg)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClinicName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EDFB4D56B2C");

            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.ClinicId).HasColumnName("ClinicID");
            entity.Property(e => e.DoctorEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DoctorImg)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DoctorName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Clinic).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK__Doctor__ClinicID__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
