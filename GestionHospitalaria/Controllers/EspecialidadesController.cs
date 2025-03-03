using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacion.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly EspecialidadesBL _especialidadesBL;

        public EspecialidadesController(EspecialidadesBL especialidadesBL)
        {
            _especialidadesBL = especialidadesBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult listarEspecialidades()
        {
            List<EspecialidadesCLS> lista = _especialidadesBL.listarEspecialidades();
            return Json(lista);
        }

        public IActionResult GuardarEspecialidades(EspecialidadesCLS especialidad)
        {
            int resultado = _especialidadesBL.GuardarEspecialidades(especialidad);
            return Content(resultado.ToString());
        }

        public JsonResult RecuperarEspecialidad(int id)
        {
            EspecialidadesCLS especialidad = _especialidadesBL.RecuperarEspecialidad(id);
            return Json(especialidad);
        }

        public IActionResult EliminarEspecialidad(int id)
        {
            int resultado = _especialidadesBL.EliminarEspecialidad(id);
            return Content(resultado.ToString());
        }
    }
}
