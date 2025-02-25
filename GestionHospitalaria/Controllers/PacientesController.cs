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
        public IActionResult Guardar(PacientesCLS paciente)
        {
            int resultado = _pacientesBL.GuardarPaciente(paciente);
            if (resultado > 0)
                return RedirectToAction("Index");
            return View(paciente);
        }
    }
}