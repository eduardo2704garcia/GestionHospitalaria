using System.Collections.Generic;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class TratamientosBL
    {
        private readonly TratamientosDAL _tratamientosDAL;

        public TratamientosBL(TratamientosDAL tratamientosDAL)
        {
            _tratamientosDAL = tratamientosDAL;
        }

        public List<TratamientosCLS> ListarTratamientos()
        {
            return _tratamientosDAL.ListarTratamientos();
        }

        public int GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            return _tratamientosDAL.GuardarTratamiento(oTratamientoCLS);
        }

        public TratamientosCLS RecuperarTratamiento(int id)
        {
            return _tratamientosDAL.RecuperarTratamiento(id);
        }

        public int EliminarTratamiento(int id)
        {
            return _tratamientosDAL.EliminarTratamiento(id);
        }
    }
}
