using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CapaDatos
{
    public class AdministradorDAL
    {
        private readonly HospitalDBContext _context;

        public AdministradorDAL(HospitalDBContext context)
        {
            _context = context;
        }

        public AdministradorCLS LoginAdministrador(string correo, string clave)
        {
            var paramCorreo = new SqlParameter("@correo", correo);
            var paramClave = new SqlParameter("@clave", clave);

            var admin = _context.Administrador
                .FromSqlRaw("EXEC uspLoginAdministrador @correo, @clave", paramCorreo, paramClave)
                .AsEnumerable()
                .FirstOrDefault();

            return admin;
        }

        public int RegistrarAdministrador(AdministradorCLS admin)
        {
            var paramNombre = new SqlParameter("@nombre", admin.Nombre);
            var paramApellido = new SqlParameter("@apellido", admin.Apellido);
            var paramCorreo = new SqlParameter("@correo", admin.Correo);
            var paramClave = new SqlParameter("@clave", admin.Clave);

            int result = _context.Database.ExecuteSqlRaw(
                "EXEC uspRegistrarAdministrador @nombre, @apellido, @correo, @clave",
                paramNombre, paramApellido, paramCorreo, paramClave);

            return result;
        }
    }
}
