using CapaEntidad;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapaDatos
{
    public class PacientesDAL
    {
        private readonly HospitalDBContext _context;

        // Inyección del DbContext mediante constructor
        public PacientesDAL(HospitalDBContext context)
        {
            _context = context;
        }

        // Método para guardar un nuevo paciente
        public int GuardarPacientes(PacientesCLS oPacientesCLS)
        {
            try
            {
                _context.Pacientes.Add(oPacientesCLS);
                // SaveChanges devuelve el número de registros afectados
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                // Puedes registrar el error si lo deseas
                throw;
            }
        }

        // Método para listar todos los pacientes
        public List<PacientesCLS> listarPacientes()
        {
            try
            {
                return _context.Pacientes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método para filtrar pacientes según algunos criterios (nombre, apellido y teléfono)
        public List<PacientesCLS> filtrarPacientes(PacientesCLS obj)
        {
            try
            {
                var query = _context.Pacientes.AsQueryable();

                if (!string.IsNullOrEmpty(obj.Nombre))
                    query = query.Where(x => x.Nombre.Contains(obj.Nombre));

                if (!string.IsNullOrEmpty(obj.Apellido))
                    query = query.Where(x => x.Apellido.Contains(obj.Apellido));

                if (!string.IsNullOrEmpty(obj.Telefono))
                    query = query.Where(x => x.Telefono.Contains(obj.Telefono));

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
