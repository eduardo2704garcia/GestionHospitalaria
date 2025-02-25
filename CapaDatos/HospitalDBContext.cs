using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapaEntidad;

namespace CapaDatos
{
    public class HospitalDBContext : DbContext
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options)
            : base(options)
        {
        }

        // DbSets que representan las tablas de la base de datos
        public DbSet<EspecialidadesCLS> Especialidades { get; set; }
        public DbSet<MedicosCLS> Medicos { get; set; }
        public DbSet<PacientesCLS> Pacientes { get; set; }
        public DbSet<CitasCLS> Citas { get; set; }
        public DbSet<TratamientosCLS> Tratamientos { get; set; }
        public DbSet<FacturacionCLS> Facturaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Especialidad
            modelBuilder.Entity<EspecialidadesCLS>(entity =>
            {
                entity.ToTable("Especialidades");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();
            });

            // Configuración de la entidad Medico
            modelBuilder.Entity<MedicosCLS>(entity =>
            {
                entity.ToTable("Medicos");
                entity.HasKey(e => e.id);
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
                entity.HasOne(e => e.Especialidades)
                      .WithMany(es => es.Medicos)
                      .HasForeignKey(e => e.EspecialidadId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la entidad Paciente
            modelBuilder.Entity<PacientesCLS>(entity =>
            {
                entity.ToTable("Pacientes");
                entity.HasKey(e => e.id);
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
            modelBuilder.Entity<CitasCLS>(entity =>
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
            modelBuilder.Entity<TratamientosCLS>(entity =>
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
            modelBuilder.Entity<FacturacionCLS>(entity =>
            {
                entity.ToTable("Facturacion");
                entity.HasKey(e => e.id);
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
