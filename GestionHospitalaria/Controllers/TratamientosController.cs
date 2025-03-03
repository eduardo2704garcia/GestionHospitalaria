using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CapaPresentacion.Controllers
{
    public class TratamientosController : Controller
    {
        private readonly TratamientosBL _tratamientosBL;
        public TratamientosController(TratamientosBL tratamientosBL)
        {
            _tratamientosBL = tratamientosBL;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTratamientos()
        {
            List<TratamientosCLS> lista = _tratamientosBL.ListarTratamientos();
            return Json(lista);
        }

        public IActionResult GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            int resultado = _tratamientosBL.GuardarTratamiento(oTratamientoCLS);
            return Content(resultado.ToString());
        }

        public JsonResult RecuperarTratamiento(int id)
        {
            TratamientosCLS tratamiento = _tratamientosBL.RecuperarTratamiento(id);
            return Json(tratamiento);
        }

        public IActionResult EliminarTratamiento(int id)
        {
            int resultado = _tratamientosBL.EliminarTratamiento(id);
            return Content(resultado.ToString());
        }
    }
}
