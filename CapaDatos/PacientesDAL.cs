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

                throw;
            }
        }

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
        public List<PacientesCLS> filtrarPacientes(string busqueda)
        {
            var query = _context.Pacientes.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(x =>
                    x.id.ToString().Contains(busqueda) ||
                    x.nombre.Contains(busqueda) ||
                    x.apellido.Contains(busqueda) ||
                    x.telefono.Contains(busqueda) ||
                    x.email.Contains(busqueda) ||
                    x.direccion.Contains(busqueda)
                );
            }

            return query.ToList();
        }
    }
}
