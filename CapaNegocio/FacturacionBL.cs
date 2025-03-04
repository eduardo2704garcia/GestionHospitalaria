using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class FacturacionBL
    {
        private readonly FacturacionDAL _facturaDAL;

        public FacturacionBL(FacturacionDAL facturaDAL)
        {
            _facturaDAL = facturaDAL;
        }

        public List<FacturacionCLS> ListarFacturas()
        {
            return _facturaDAL.ListarFacturas();
        }

        public int GuardarFactura(FacturacionCLS oFacturaCLS)
        {
            return _facturaDAL.GuardarFactura(oFacturaCLS);
        }

        public FacturacionCLS RecuperarFactura(int id)
        {
            return _facturaDAL.RecuperarFactura(id);
        }

        public int EliminarFactura(int id)
        {
            return _facturaDAL.EliminarFactura(id);
        }
    }
}
