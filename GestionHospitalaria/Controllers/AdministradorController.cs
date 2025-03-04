using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly AdministradorBL _adminBL;

        public AdministradorController(AdministradorBL adminBL)
        {
            _adminBL = adminBL;
        }

        // Acción para mostrar la vista de login (por ejemplo, Login.cshtml)
        public IActionResult Login()
        {
            return View();
        }

        // Acción para procesar el login (por ejemplo, llamada vía AJAX o formulario)
        [HttpPost]
        public IActionResult LoginAdministrador(string correo, string clave)
        {
            var admin = _adminBL.LoginAdministrador(correo, clave);
            if (admin != null)
            {
                // Por ejemplo, establecer la sesión o devolver un JSON con éxito.
                return Json(new { success = true, adminId = admin.Id, nombre = admin.Nombre });
            }
            else
            {
                return Json(new { success = false, message = "Credenciales inválidas." });
            }
        }

        // Acción para mostrar la vista de registro (por ejemplo, Registro.cshtml)
        public IActionResult Registro()
        {
            return View();
        }

        // Acción para registrar un nuevo administrador
        [HttpPost]
        public IActionResult RegistrarAdministrador(AdministradorCLS admin)
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
