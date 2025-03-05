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

        public List<AdministradorCLS> ListarAdministradores()
        {
            return _context.Administrador.ToList();
        }
        public bool ExisteCorreo(string correo)
        {
            return _context.Administrador.Any(a => a.Correo == correo);
        }

        public bool CrearAdministrador(AdministradorCLS administrador)
        {
            try
            {
                _context.Administrador.Add(administrador);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
