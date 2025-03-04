using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionHospitalaria.Controllers
{
    public class CitasController : Controller
    {
        private readonly CitasBL _citasBL;
        public CitasController(CitasBL citasBL)
        {
            _citasBL = citasBL;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarCitas()
        {
            List<CitasCLS> lista = _citasBL.ListarCitas();
            return Json(lista);
        }

        public IActionResult GuardarCita(CitasCLS oCitaCLS)
        {
            int resultado = _citasBL.GuardarCita(oCitaCLS);
            return Content(resultado.ToString());
        }

        public JsonResult RecuperarCita(int id)
        {
            CitasCLS cita = _citasBL.RecuperarCita(id);
            return Json(cita);
        }

        public IActionResult EliminarCita(int id)
        {
            int resultado = _citasBL.EliminarCita(id);
            return Content(resultado.ToString());
        }
    }
}
