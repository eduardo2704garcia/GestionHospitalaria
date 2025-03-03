using CapaEntidad;
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

        // Listar tratamientos con el nombre del paciente (JOIN con Pacientes)
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

        // Guardar o actualizar un tratamiento
        public int GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            try
            {
                if (oTratamientoCLS.Id == 0)
                {
                    _context.Tratamientos.Add(oTratamientoCLS);
                }
                else
                {
                    var tratamientoDB = _context.Tratamientos.FirstOrDefault(t => t.Id == oTratamientoCLS.Id);
                    if (tratamientoDB != null)
                    {
                        tratamientoDB.Descripcion = oTratamientoCLS.Descripcion;
                        tratamientoDB.Fecha = oTratamientoCLS.Fecha;
                        tratamientoDB.Costo = oTratamientoCLS.Costo;
                        tratamientoDB.PacienteId = oTratamientoCLS.PacienteId;
                    }
                }
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GuardarTratamiento: " + ex.Message);
                throw;
            }
        }



        // Recuperar un tratamiento por su Id (incluye NombrePaciente vía JOIN)
        public TratamientosCLS RecuperarTratamiento(int id)
        {
            try
            {
                var tratamiento = (from t in _context.Tratamientos
                                   join p in _context.Pacientes on t.PacienteId equals p.id
                                   where t.Id == id
                                   select new TratamientosCLS
                                   {
                                       Id = t.Id,
                                       Descripcion = t.Descripcion,
                                       Fecha = t.Fecha,
                                       Costo = t.Costo,
                                       PacienteId = t.PacienteId,
                                       NombrePaciente = p.nombre
                                   }).FirstOrDefault();
                return tratamiento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Eliminar un tratamiento (eliminación física)
        public int EliminarTratamiento(int id)
        {
            try
            {
                var tratamiento = _context.Tratamientos.FirstOrDefault(t => t.Id == id);
                if (tratamiento != null)
                {
                    _context.Tratamientos.Remove(tratamiento);
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
