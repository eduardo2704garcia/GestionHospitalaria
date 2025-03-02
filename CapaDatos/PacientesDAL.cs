using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class PacientesDAL
    {
        private readonly HospitalDBContext _context;

        public PacientesDAL(HospitalDBContext context)
        {
            _context = context;
        }

        // Listar todos los pacientes
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

        // Filtrar pacientes por un texto de búsqueda (aplica a varios campos)
        public List<PacientesCLS> filtrarPacientes(string busqueda)
        {
            try
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
                        x.direccion.Contains(busqueda));
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Guardar o actualizar un paciente.
        // Si el id es 0, se asume inserción; si es distinto, se actualiza el registro existente.
        public int GuardarPacientes(PacientesCLS oPacientesCLS)
        {
            try
            {
                if (oPacientesCLS.id == 0)
                {
                    _context.Pacientes.Add(oPacientesCLS);
                }
                else
                {
                    // Actualización: se recupera el paciente existente y se actualizan sus propiedades.
                    var pacienteDB = _context.Pacientes.FirstOrDefault(p => p.id == oPacientesCLS.id);
                    if (pacienteDB != null)
                    {
                        pacienteDB.nombre = oPacientesCLS.nombre;
                        pacienteDB.apellido = oPacientesCLS.apellido;
                        pacienteDB.fechaNacimiento = oPacientesCLS.fechaNacimiento;
                        pacienteDB.telefono = oPacientesCLS.telefono;
                        pacienteDB.email = oPacientesCLS.email;
                        pacienteDB.direccion = oPacientesCLS.direccion;
                        // Los cambios son rastreados automáticamente por EF.
                    }
                }

                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Recuperar un paciente por su id
        public PacientesCLS RecuperarPaciente(int idPaciente)
        {
            try
            {
                return _context.Pacientes.FirstOrDefault(p => p.id == idPaciente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Eliminar un paciente (eliminación física)
        public int EliminarPaciente(int idPaciente)
        {
            try
            {
                var paciente = _context.Pacientes.FirstOrDefault(p => p.id == idPaciente);
                if (paciente != null)
                {
                    _context.Pacientes.Remove(paciente);
                    return _context.SaveChanges();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
