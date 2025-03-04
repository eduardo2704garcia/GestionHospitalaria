using Microsoft.AspNetCore.Mvc;
using GestionHospitalaria.Controllers;
using CapaEntidad;
using System.Text;
using System.Security.Cryptography;
using CapaNegocio;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace CapaPresentacion.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            return View();
        }


        private readonly AdministradorBL _adminBL;

        public AccesoController(AdministradorBL adminBL)
        {
            _adminBL = adminBL;
        }

        [HttpPost]
        public IActionResult LoginAdministrador([FromBody] AdministradorCLS admin)
        {
            var usuario = _adminBL.LoginAdministrador(admin.Correo, admin.Clave);
            if (usuario != null)
            {
                // Por ejemplo, establecer la sesión o devolver un JSON con éxito.
                return Json(new { success = true, adminId = usuario.Id, nombre = usuario.Nombre });
            }
            else
            {
                return Json(new { success = false, message = "Credenciales inválidas." });
            }
        }

        [HttpPost]
        public IActionResult RegistrarAdministrador([FromBody] AdministradorCLS admin)
        {
            int result = _adminBL.RegistrarAdministrador(admin);
            if (result > 0)
            {
                return Json(new { success = true, message = "Registrado con éxito." });
            }
            else
            {
                return Json(new { success = false, message = "Error al registrar." });
            }
        }
    }
}
