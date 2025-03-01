using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class EspecialidadesBL
    {
        private readonly EspecialidadesDAL _especialidadesDAL;

        
        public EspecialidadesBL(EspecialidadesDAL especialidadesDAL)
        {
            _especialidadesDAL = especialidadesDAL;
        }

        
        public int GuardarEspecialidades(EspecialidadesCLS oEspecialidadCLS)
        {
            return _especialidadesDAL.GuardarEspecialidades(oEspecialidadCLS);
        }

        
        public List<EspecialidadesCLS> listarEspecialidades()
        {
            return _especialidadesDAL.listarEspecialidades();
        }

        
        public List<EspecialidadesCLS> filtrarEspecialidades(string busqueda)
        {
            return _especialidadesDAL.filtrarEspecialidades(busqueda);
        }
    }
}
