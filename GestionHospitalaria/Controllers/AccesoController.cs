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
        private readonly AdministradorBL _administradorBL;

        public AccesoController(AdministradorBL administradorBL)
        {
            _administradorBL = administradorBL;
        }

        public IActionResult Login()
        {
            return View(); 
        }

        public IActionResult IniciarSesion(string correo, string clave)
        {
            bool credencialesValidas = _administradorBL.ValidarCredenciales(correo, clave);

            if (credencialesValidas)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Correo o contraseña incorrectos";
                return View("Login");
            }
        }

        public IActionResult Registrar()
        {
            return View(); 
        }

        [HttpPost]
        // POST: Acceso/Registrar
        [HttpPost]
        public IActionResult Registrar(AdministradorCLS administrador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool resultado = _administradorBL.RegistrarAdministrador(administrador);

                    if (resultado)
                    {
                        return RedirectToAction("Login", "Acceso");
                    }
                    else
                    {
                        ViewBag.Error = "Error al registrar el administrador";
                    }
                }
                return View(administrador);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(administrador);
            }
        }
    }
}
