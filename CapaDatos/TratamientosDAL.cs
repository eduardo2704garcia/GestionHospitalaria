using CapaEntidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class TratamientosDAL
    {
        private readonly HospitalDBContext _context;

        public TratamientosDAL(HospitalDBContext context)
        {
            _context = context;
        }

        public List<TratamientosCLS> ListarTratamientos()
        {
            try
            {
                var lista = (from t in _context.Tratamientos
                             join p in _context.Pacientes on t.PacienteId equals p.id
                             select new TratamientosCLS
                             {
                                 Id = t.Id,
                                 Descripcion = t.Descripcion,
                                 Fecha = t.Fecha,
                                 Costo = t.Costo,
                                 PacienteId = t.PacienteId,
                                 NombrePaciente = p.nombre
                             }).ToList();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            try
            {
                if (oTratamientoCLS.Id == 0)
                {
                    return _context.Database.ExecuteSqlRaw("EXEC usp_InsertarTratamiento @p0, @p1, @p2, @p3",
                        oTratamientoCLS.Descripcion, oTratamientoCLS.Fecha, oTratamientoCLS.Costo, oTratamientoCLS.PacienteId);
                }
                else
                {
                    return _context.Database.ExecuteSqlRaw("EXEC usp_ActualizarTratamiento @p0, @p1, @p2, @p3, @p4",
                        oTratamientoCLS.Id, oTratamientoCLS.Descripcion, oTratamientoCLS.Fecha, oTratamientoCLS.Costo, oTratamientoCLS.PacienteId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GuardarTratamiento: " + ex.Message);
                throw;
            }
        }

        public TratamientosCLS RecuperarTratamiento(int id)
        {
            try
            {
                return _context.Tratamientos
                    .FromSqlRaw("EXEC usp_RecuperarTratamiento @p0", id)
                    .AsEnumerable()
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EliminarTratamiento(int id)
        {
            try
            {
                return _context.Database.ExecuteSqlRaw("EXEC usp_EliminarTratamiento @p0", id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
