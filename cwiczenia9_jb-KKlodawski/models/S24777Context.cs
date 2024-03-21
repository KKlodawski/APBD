using Microsoft.EntityFrameworkCore;

namespace Zadanie9.models;

public class S24777Context : DbContext
{
    protected S24777Context()
    {
    }

    public S24777Context(DbContextOptions options) 
        : base(options)
    {
    }
    
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
    public virtual DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prescription_Medicament>(entity =>
        {
            entity.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("Prescription_Medicament_pk");

            entity.ToTable("Prescription_Medicament", "hospital");

            entity.Property(e => e.Dose);
            entity.Property(e => e.Details).HasMaxLength(100);

            entity
                .HasOne(e => e.IdMedicamentNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Prescription_Medicament_Medicament");

            entity
                .HasOne(e => e.IdPrescriptionNavigation)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Prescription_Medicament_Prescription");
        });
        modelBuilder.Entity<Prescription_Medicament>().HasData(
            new Prescription_Medicament {IdPrescription = 1,IdMedicament = 1, Dose = 2,Details = "aa"},
            new Prescription_Medicament {IdPrescription = 1,IdMedicament = 2, Dose = 4,Details = "bb"},
            new Prescription_Medicament {IdPrescription = 2,IdMedicament = 1, Dose = 1,Details = "cc"},
            new Prescription_Medicament {IdPrescription = 2,IdMedicament = 2, Dose = 8,Details = "dd"}
            );

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => e.IdMedicament).HasName("Mediament_pk");

            entity.ToTable("Mediament", "hospital");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(100);
        });
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1,Name = "abc", Description = "abc", Type="abc" },
            new Medicament { IdMedicament = 2,Name = "bcd", Description = "bcd", Type="bcd" }
            );

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("Doctor_pk");

            entity.ToTable("Doctor", "hospital");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
        });
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Doc1", LastName = "Doc1", Email = "Doc1@email.com" },
            new Doctor { IdDoctor = 2, FirstName = "Doc2", LastName = "Doc2", Email = "Doc2@email.com" }
        );

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("Patient_pk");

            entity.ToTable("Patient", "hospital");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Lastname).HasMaxLength(100);
            entity.Property(e => e.Birthdate).HasColumnType("datetime");
        });
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "P1", Lastname = "P1", Birthdate = DateTime.Parse("10-10-2000") },
            new Patient { IdPatient = 2, FirstName = "P2", Lastname = "P2", Birthdate = DateTime.Parse("20-03-1994") }
            );

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.IdPresscription).HasName("Prescription_pk");

            entity.ToTable("Prescription", "hospital");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DateDue).HasColumnType("datetime");

            entity
                .HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Doctor_Prescription");

            entity
                .HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Prescription");
        });
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription {IdPresscription = 1,Date = DateTime.Now, DateDue = DateTime.Parse("19-05-2023"), IdDoctor = 1,IdPatient = 1},
            new Prescription {IdPresscription = 2,Date = DateTime.Now, DateDue = DateTime.Parse("21-05-2023"), IdDoctor = 2,IdPatient = 2}
            );

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pk");

            entity.ToTable("Users", "hospital");

            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.RefreshToken).HasMaxLength(120);
            entity.Property(e => e.RefreshTokenExpireTime).HasColumnType("datetime");
        });

    }
}