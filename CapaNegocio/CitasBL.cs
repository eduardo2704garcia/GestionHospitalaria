using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CitasBL
    {
        private readonly CitasDAL _citasDAL;

        public CitasBL(CitasDAL citasDAL)
        {
            _citasDAL = citasDAL;
        }

        public List<CitasCLS> ListarCitas()
        {
            return _citasDAL.ListarCitas();
        }

        public int GuardarCita(CitasCLS oCitaCLS)
        {
            return _citasDAL.GuardarCita(oCitaCLS);
        }

        public CitasCLS RecuperarCita(int id)
        {
            return _citasDAL.RecuperarCita(id);
        }

        public int EliminarCita(int id)
        {
            return _citasDAL.EliminarCita(id);
        }
    }
}
