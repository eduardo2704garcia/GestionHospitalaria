using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos
{
    public class EspecialidadesDAL
    {
        private readonly HospitalDBContext _context;

        // Inyección del DbContext mediante constructor
        public EspecialidadesDAL(HospitalDBContext context)
        {
            _context = context;
        }

        // Método para guardar una nueva especialidad
        public int GuardarEspecialidades(EspecialidadesCLS oEspecialidadesCLS)
        {
            try
            {
                _context.Especialidades.Add(oEspecialidadesCLS);
                return _context.SaveChanges(); // Retorna la cantidad de registros afectados
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método para listar todas las especialidades
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

        // Método para filtrar especialidades por nombre o ID
        public List<EspecialidadesCLS> filtrarEspecialidades(string busqueda)
        {
            var query = _context.Especialidades.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(x =>
                    x.Id.ToString().Contains(busqueda) ||
                    x.Nombre.Contains(busqueda)
                );
            }

            return query.ToList();
        }
    }
}
