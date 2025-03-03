﻿using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class EspecialidadesBL
    {
        private readonly EspecialidadesDAL _especialidadesDAL;


        public EspecialidadesBL(EspecialidadesDAL especialidadDAL)
        {
            _especialidadesDAL = especialidadDAL;
        }

        public int GuardarEspecialidades(EspecialidadesCLS oEspecialidadCLS)
        {
            return _especialidadesDAL.GuardarEspecialidades(oEspecialidadCLS);
        }

        public List<EspecialidadesCLS> listarEspecialidades()
        {
            return _especialidadesDAL.listarEspecialidades();
        }
        public EspecialidadesCLS RecuperarEspecialidad(int idEspecialidad)
        {
            return _especialidadesDAL.RecuperarEspecialidad(idEspecialidad);
        }

        public int EliminarEspecialidad(int idEspecialidad)
        {
            return _especialidadesDAL.EliminarEspecialidad(idEspecialidad);
        }
    }
}
