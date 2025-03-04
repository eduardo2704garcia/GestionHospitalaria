using CapaEntidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                    return _context.Database.ExecuteSqlRaw(
                        "EXEC usp_InsertarEspecialidad @p0",
                        oEspecialidadesCLS.nombre
                    );
                }
                else
                {
                    return _context.Database.ExecuteSqlRaw(
                        "EXEC usp_ActualizarEspecialidad @p0, @p1",
                        oEspecialidadesCLS.id,
                        oEspecialidadesCLS.nombre
                    );
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public EspecialidadesCLS RecuperarEspecialidad(int idEspecialidad)
        {
            try
            {
                return _context.Especialidades
                    .FromSqlRaw("EXEC usp_RecuperarEspecialidad @p0", idEspecialidad)
                    .AsEnumerable()
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int EliminarEspecialidad(int idEspecialidad)
        {
            try
            {
                return _context.Database.ExecuteSqlRaw(
                    "EXEC usp_EliminarEspecialidad @p0",
                    idEspecialidad
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
