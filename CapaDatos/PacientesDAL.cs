using CapaEntidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class PacientesDAL
    {
        private readonly HospitalDBContext _context;

        public PacientesDAL(HospitalDBContext context)
        {
            _context = context;
        }

        public List<PacientesCLS> listarPacientes()
        {
            return _context.Pacientes
                .FromSqlRaw("EXEC usp_ListarPacientes")
                .ToList();
        }

        public List<PacientesCLS> filtrarPacientes(string busqueda)
        {
            return _context.Pacientes
                .FromSqlRaw("EXEC uspFiltrarPacientes @p0", busqueda ?? "")
                .ToList();
        }
        public int GuardarPacientes(PacientesCLS oPacientesCLS)
        {
            try
            {
                if (oPacientesCLS.id == 0)
                {
                    return _context.Database.ExecuteSqlRaw(
                        "EXEC usp_InsertarPaciente @p0, @p1, @p2, @p3, @p4, @p5",
                        oPacientesCLS.nombre,
                        oPacientesCLS.apellido,
                        oPacientesCLS.fechaNacimiento,
                        oPacientesCLS.telefono,
                        oPacientesCLS.email,
                        oPacientesCLS.direccion
                    );
                }
                else
                {
                    return _context.Database.ExecuteSqlRaw(
                        "EXEC usp_ActualizarPaciente @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                        oPacientesCLS.id,
                        oPacientesCLS.nombre,
                        oPacientesCLS.apellido,
                        oPacientesCLS.fechaNacimiento,
                        oPacientesCLS.telefono,
                        oPacientesCLS.email,
                        oPacientesCLS.direccion
                    );
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PacientesCLS RecuperarPaciente(int idPaciente)
        {
            return _context.Pacientes
                .FromSqlRaw("EXEC usp_RecuperarPaciente @p0", idPaciente)
                .AsEnumerable()
                .FirstOrDefault();
        }

        public int EliminarPaciente(int idPaciente)
        {
            try
            {
                return _context.Database.ExecuteSqlRaw("EXEC usp_EliminarPaciente @p0", idPaciente);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar paciente: {ex.Message}");
                return 0;
            }
        }

    }
}
