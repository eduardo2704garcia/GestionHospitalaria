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
        private readonly AdministradorDAL _administradorDAL;

        public AdministradorBL(AdministradorDAL administradorDAL)
        {
            _administradorDAL = administradorDAL;
        }

        public bool ValidarCredenciales(string correo, string clave)
        {
            List<AdministradorCLS> administradores = _administradorDAL.ListarAdministradores();
            return administradores.Any(a => a.Correo == correo && a.Clave == clave);
        }
        public bool RegistrarAdministrador(AdministradorCLS administrador)
        {
            // Validar correo único
            if (_administradorDAL.ExisteCorreo(administrador.Correo))
            {
                throw new Exception("El correo electrónico ya está registrado");
            }

            return _administradorDAL.CrearAdministrador(administrador);
        }
    }

}
