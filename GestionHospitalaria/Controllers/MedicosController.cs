using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class MedicosController : Controller
    {
        private readonly MedicosBL _medicosBL;
        public MedicosController(MedicosBL medicosBL)
        {
            _medicosBL = medicosBL;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarMedicos()
        {
            List<MedicosCLS> lista = _medicosBL.ListarMedicos();
            return Json(lista);
        }

        public IActionResult GuardarMedico(MedicosCLS oMedicoCLS)
        {
            int resultado = _medicosBL.GuardarMedico(oMedicoCLS);
            return Content(resultado.ToString());
        }

        public JsonResult RecuperarMedico(int id)
        {
            MedicosCLS medico = _medicosBL.RecuperarMedico(id);
            return Json(medico);
        }

        public IActionResult EliminarMedico(int id)
        {
            int resultado = _medicosBL.EliminarMedico(id);
            return Content(resultado.ToString());
        }
    }
}
