using Microsoft.AspNetCore.Mvc;
using CapaNegocio;
using CapaEntidad;
using CapaDatos;
using System.Collections.Generic;

namespace CapaPresentacion.Controllers
{
    public class EspecialidadesController : Controller
    {
        private readonly EspecialidadesBL _especialidadesBL;

        // Constructor con inyección de dependencias
        public EspecialidadesController(EspecialidadesBL especialidadesBL)
        {
            _especialidadesBL = especialidadesBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult listarEspecialidades()
        {
            List<EspecialidadesCLS> lista = _especialidadesBL.listarEspecialidades();
            return Json(lista);
        }

        [HttpPost]
        public IActionResult GuardarEspecialidades([FromBody] EspecialidadesCLS especialidad)
        {
            int resultado = _especialidadesBL.GuardarEspecialidades(especialidad);
            return Content(resultado.ToString());
        }

        [HttpGet]
        public JsonResult filtrarEspecialidades(string busqueda)
        {
            List<EspecialidadesCLS> lista = _especialidadesBL.filtrarEspecialidades(busqueda);
            return Json(lista);
        }
    }
}
