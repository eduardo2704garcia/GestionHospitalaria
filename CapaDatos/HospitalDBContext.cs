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
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options) : base(options) { }

        public DbSet<PacientesCLS> Pacientes { get; set; }
        public DbSet<MedicosCLS> Medicos { get; set; }
        public DbSet<CitasCLS> Citas { get; set; }
        public DbSet<EspecialidadesCLS> Especialidades { get; set; }
        public DbSet<TratamientosCLS> Tratamientos { get; set; }
        public DbSet<FacturacionCLS> Facturacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacientesCLS>().ToTable("Pacientes");
            modelBuilder.Entity<MedicosCLS>().ToTable("Medicos");
            modelBuilder.Entity<CitasCLS>().ToTable("Citas");
            modelBuilder.Entity<EspecialidadesCLS>().ToTable("Especialidades");
            modelBuilder.Entity<TratamientosCLS>().ToTable("Tratamientos");
            modelBuilder.Entity<FacturacionCLS>().ToTable("Facturacion");
        }
    }
}
