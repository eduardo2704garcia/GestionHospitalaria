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

        // Inyección de dependencias a través del constructor
        public PacientesController(PacientesBL pacientesBL)
        {
            _pacientesBL = pacientesBL;
        }

        // Acción principal para mostrar la vista
        public IActionResult Index()
        {
            List<PacientesCLS> lista = _pacientesBL.listarPacientes();
            return View(lista);
        }

        // Acción para guardar un paciente (por ejemplo, a través de un formulario)
        [HttpPost]
        public IActionResult Guardar(PacientesCLS paciente)
        {
            int resultado = _pacientesBL.GuardarPaciente(paciente);
            if (resultado > 0)
                return RedirectToAction("Index");

            return View(paciente);
        }

        // Ejemplo de acción que devuelve JSON (por ejemplo, para una llamada AJAX)
        [HttpGet]
        public JsonResult listarPacientesJson()
        {
            List<PacientesCLS> lista = _pacientesBL.listarPacientes();
            return Json(lista);
        }
    }
}