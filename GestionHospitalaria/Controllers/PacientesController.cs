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

        public JsonResult listarPacientes()
        {
            List<PacientesCLS> lista = _pacientesBL.listarPacientes();
            return Json(lista);
        }

        public IActionResult GuardarPaciente(PacientesCLS paciente)
        {
            int resultado = _pacientesBL.GuardarPaciente(paciente);
            return Content(resultado.ToString());
        }

        public JsonResult filtrarPacientes(string busqueda)
        {
            List<PacientesCLS> lista = _pacientesBL.filtrarPacientes(busqueda);
            return Json(lista);
        }

        public JsonResult RecuperarPaciente(int id)
        {
            PacientesCLS paciente = _pacientesBL.RecuperarPaciente(id);
            return Json(paciente);
        }

        public IActionResult EliminarPaciente(int id)
        {
            int resultado = _pacientesBL.EliminarPaciente(id);
            return Content(resultado.ToString());
        }

    }
}