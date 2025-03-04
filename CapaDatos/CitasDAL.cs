using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CitasDAL
    {
        private readonly HospitalDBContext _context;

        public CitasDAL(HospitalDBContext context)
        {
            _context = context;
        }

        public List<CitasCLS> ListarCitas()
        {
            try
            {
                var lista = (from c in _context.Citas
                             join p in _context.Pacientes on c.PacienteId equals p.id
                             join m in _context.Medicos on c.MedicoId equals m.Id
                             select new CitasCLS
                             {
                                 Id = c.Id,
                                 FechaHora = c.FechaHora,
                                 Estado = c.Estado,
                                 PacienteId = c.PacienteId,
                                 NombrePaciente = p.nombre,
                                 MedicoId = c.MedicoId,
                                 NombreMedico = m.Nombre
                             }).ToList();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GuardarCita(CitasCLS oCitaCLS)
        {
            try
            {
                if (oCitaCLS.Id == 0)
                {
                    _context.Citas.Add(oCitaCLS);
                }
                else
                {
                    var citaDB = _context.Citas.FirstOrDefault(c => c.Id == oCitaCLS.Id);
                    if (citaDB != null)
                    {
                        citaDB.FechaHora = oCitaCLS.FechaHora;
                        citaDB.Estado = oCitaCLS.Estado;
                        citaDB.PacienteId = oCitaCLS.PacienteId;
                        citaDB.MedicoId = oCitaCLS.MedicoId;
                    }
                }
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GuardarCita: " + ex.Message);
                throw;
            }
        }


        public CitasCLS RecuperarCita(int id)
        {
            try
            {
                var cita = (from c in _context.Citas
                                   join p in _context.Pacientes on c.PacienteId equals p.id
                                   join m in _context.Medicos on c.MedicoId equals m.Id
                                   where c.Id == id
                                   select new CitasCLS
                                   {
                                       Id = c.Id,
                                       FechaHora = c.FechaHora,
                                       Estado = c.Estado,
                                       PacienteId = c.PacienteId,
                                       NombrePaciente = p.nombre,
                                       MedicoId = c.MedicoId,
                                       NombreMedico = m.Nombre
                                   }).FirstOrDefault();
                return cita;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EliminarCita(int id)
        {
            try
            {
                var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
                if (cita != null)
                {
                    _context.Citas.Remove(cita);
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
