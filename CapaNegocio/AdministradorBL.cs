using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class AdministradorBL
    {
        private readonly AdministradorDAL _adminDAL;

        public AdministradorBL(AdministradorDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public AdministradorCLS LoginAdministrador(string correo, string clave)
        {
            return _adminDAL.LoginAdministrador(correo, clave);
        }

        public int RegistrarAdministrador(AdministradorCLS admin)
        {
            return _adminDAL.RegistrarAdministrador(admin);
        }
    }

}
