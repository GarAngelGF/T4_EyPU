using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace T3_P_ORM_SQL.Modelos
{
    public class Contextobd : DbContext
    {
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }

        
        public DbSet<Inter_Doc_Cita> DoctorCitas { get; set; }
        public DbSet<Inter_Paciente_Cita> PacienteCitas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=citas_medicas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Inter_Doc_Cita>()
                .HasKey(dc => new { dc.DoctorId, dc.CitaId });

          
            modelBuilder.Entity<Inter_Doc_Cita>()
                .HasOne(dc => dc.Doctor)
                .WithMany(d => d.DoctorCitas)
                .HasForeignKey(dc => dc.DoctorId);

            modelBuilder.Entity<Inter_Doc_Cita>()
                .HasOne(dc => dc.Cita)
                .WithMany(c => c.DoctorCitas)
                .HasForeignKey(dc => dc.CitaId);


            modelBuilder.Entity<Inter_Paciente_Cita>()
                .HasKey(pc => new { pc.PacienteId, pc.CitaId });

         
            modelBuilder.Entity<Inter_Paciente_Cita>()
                .HasOne(pc => pc.Paciente)
                .WithMany(p => p.PacienteCitas)
                .HasForeignKey(pc => pc.PacienteId);

            modelBuilder.Entity<Inter_Paciente_Cita>()
                .HasOne(pc => pc.Cita)
                .WithMany(c => c.PacienteCitas)
                .HasForeignKey(pc => pc.CitaId);
        }
    }
}
