using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class MedicosBL
    {
        private readonly MedicosDAL _medicosDAL;

        public MedicosBL(MedicosDAL medicosDAL)
        {
            _medicosDAL = medicosDAL;
        }

        public List<MedicosCLS> ListarMedicos()
        {
            return _medicosDAL.ListarMedicos();
        }

        public int GuardarMedico(MedicosCLS oMedicosCLS)
        {
            return _medicosDAL.GuardarMedico(oMedicosCLS);
        }

        public MedicosCLS RecuperarMedico(int id)
        {
            return _medicosDAL.RecuperarMedico(id);
        }

        public int EliminarMedico(int id)
        {
            return _medicosDAL.EliminarMedico(id);
        }
    }
}
