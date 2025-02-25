using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class HospitalDBContext : DbContext
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options)
            : base(options)
        {
        }

        // DbSets que representan las tablas de la base de datos
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Facturacion> Facturaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Especialidad
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("Especialidades");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();
            });

            // Configuración de la entidad Medico
            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("Medicos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.Apellido)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.Telefono)
                      .HasMaxLength(16)
                      .IsRequired();
                entity.Property(e => e.Email)
                      .HasMaxLength(100)
                      .IsRequired();

                // Índice único para Email
                entity.HasIndex(e => e.Email).IsUnique();

                // Relación con Especialidad
                entity.HasOne(e => e.Especialidad)
                      .WithMany(es => es.Medicos)
                      .HasForeignKey(e => e.EspecialidadId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la entidad Paciente
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Pacientes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.Apellido)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.FechaNacimiento)
                      .IsRequired();
                entity.Property(e => e.Telefono)
                      .HasMaxLength(16)
                      .IsRequired();
                entity.Property(e => e.Email)
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(e => e.Direccion)
                      .HasMaxLength(255)
                      .IsRequired();

                // Índice único para Email
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Configuración de la entidad Cita
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.ToTable("Citas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FechaHora)
                      .IsRequired();
                entity.Property(e => e.Estado)
                      .HasMaxLength(20)
                      .IsRequired();

                // Relación con Paciente
                entity.HasOne(e => e.Paciente)
                      .WithMany(p => p.Citas)
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con Medico
                entity.HasOne(e => e.Medico)
                      .WithMany(m => m.Citas)
                      .HasForeignKey(e => e.MedicoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la entidad Tratamiento
            modelBuilder.Entity<Tratamiento>(entity =>
            {
                entity.ToTable("Tratamientos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion)
                      .HasMaxLength(255)
                      .IsRequired();
                entity.Property(e => e.Fecha)
                      .IsRequired();
                entity.Property(e => e.Costo)
                      .HasColumnType("decimal(10,2)")
                      .IsRequired();

                // Relación con Paciente
                entity.HasOne(e => e.Paciente)
                      .WithMany(p => p.Tratamientos)
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la entidad Facturacion
            modelBuilder.Entity<Facturacion>(entity =>
            {
                entity.ToTable("Facturacion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Monto)
                      .HasColumnType("decimal(10,2)")
                      .IsRequired();
                entity.Property(e => e.MetodoPago)
                      .HasMaxLength(50)
                      .IsRequired();
                entity.Property(e => e.FechaPago)
                      .IsRequired();

                // Relación con Paciente
                entity.HasOne(e => e.Paciente)
                      .WithMany(p => p.Facturaciones)
                      .HasForeignKey(e => e.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
