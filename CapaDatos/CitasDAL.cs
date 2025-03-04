using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Microsoft.EntityFrameworkCore;

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
            if (oCitaCLS.Id == 0)
            {
                return _context.Database.ExecuteSqlRaw("EXEC uspInsertarCita @p0, @p1, @p2, @p3",
                    oCitaCLS.FechaHora, oCitaCLS.Estado, oCitaCLS.PacienteId, oCitaCLS.MedicoId);
            }
            else
            {
                return _context.Database.ExecuteSqlRaw("EXEC uspActualizarCita @p0, @p1, @p2, @p3, @p4",
                    oCitaCLS.Id, oCitaCLS.FechaHora, oCitaCLS.Estado, oCitaCLS.PacienteId, oCitaCLS.MedicoId);
            }
        }

        public CitasCLS RecuperarCita(int id)
        {
            return _context.Citas
                .FromSqlRaw("EXEC uspListarCitas")
                .AsEnumerable()
                .FirstOrDefault(c => c.Id == id);
        }

        public int EliminarCita(int id)
        {
            return _context.Database.ExecuteSqlRaw("EXEC uspEliminarCita @p0", id);
        }
    }
}
