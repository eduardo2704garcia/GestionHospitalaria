using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class EspecialidadesDAL
    {
        private readonly HospitalDBContext _context;


        public EspecialidadesDAL(HospitalDBContext context)
        {
            _context = context;
        }

        public List<EspecialidadesCLS> listarEspecialidades()
        {
            try
            {
                return _context.Especialidades.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GuardarEspecialidades(EspecialidadesCLS oEspecialidadesCLS)
        {
            try
            {
                if (oEspecialidadesCLS.id == 0)
                {
                    _context.Especialidades.Add(oEspecialidadesCLS);
                }
                else
                {
                    var especialidadDB = _context.Especialidades.FirstOrDefault(p => p.id == oEspecialidadesCLS.id);
                    if (especialidadDB != null)
                    {
                        especialidadDB.Nombre = oEspecialidadesCLS.Nombre;
                    }
                }

                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Método para filtrar especialidades por nombre o ID
        public List<EspecialidadesCLS> filtrarEspecialidades(string busqueda)
        {
            var query = _context.Especialidades.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(x =>
                    x.id.ToString().Contains(busqueda) ||
                    x.Nombre.Contains(busqueda)
                );
            }

            return query.ToList();
        }

        public EspecialidadesCLS RecuperarEspecialidad(int idEspecialidad)
        {
            try
            {
                return _context.Especialidades.FirstOrDefault(p => p.id == idEspecialidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Eliminar un paciente (eliminación física)
        public int EliminarEspecialidad(int idEspecialidad)
        {
            try
            {
                var especialidad = _context.Especialidades.FirstOrDefault(p => p.id == idEspecialidad);
                if (especialidad != null)
                {
                    _context.Especialidades.Remove(especialidad);
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
