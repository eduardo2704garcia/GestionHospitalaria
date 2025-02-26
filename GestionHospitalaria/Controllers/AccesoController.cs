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

    }
}
