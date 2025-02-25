using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class PacientesController : Controller
    {
        private readonly PacientesBL _pacientesBL;

        public PacientesController(PacientesBL pacientesBL)
        {
            _pacientesBL = pacientesBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult listarPacientes()
        {
            List<PacientesCLS> lista = _pacientesBL.listarPacientes();
            return Json(lista);
        }

        [HttpPost]
        public IActionResult GuardarPaciente(PacientesCLS paciente)
        {
            int resultado = _pacientesBL.GuardarPaciente(paciente);
            // Puedes retornar un simple mensaje o el número de registros afectados
            return Content(resultado.ToString());
        }

        [HttpGet]
        public JsonResult filtrarPacientes(string busqueda)
        {
            List<PacientesCLS> lista = _pacientesBL.filtrarPacientes(busqueda);
            return Json(lista);
        }
    }
}