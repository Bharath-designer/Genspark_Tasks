using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApp.Models
{
    public class DoctorClinicContext: DbContext
    {
        public DoctorClinicContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.DoctorId);
            modelBuilder.Entity<Patient>()  
                .HasKey(d => d.PatientId);
            modelBuilder.Entity<Appointment>()
                .HasKey(d => d.AppointmentId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(a => a.DoctorId)
                .IsRequired();

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(d => d.Appointments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(a => a.PatientId)
                .IsRequired();

        }
    }
}
