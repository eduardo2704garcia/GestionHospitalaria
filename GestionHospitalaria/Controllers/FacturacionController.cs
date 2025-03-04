using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly FacturacionBL _facturaBL;
        public FacturacionController(FacturacionBL facturaBL)
        {
            _facturaBL = facturaBL;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarFacturas()
        {
            List<FacturacionCLS> lista = _facturaBL.ListarFacturas();
            return Json(lista);
        }

        public IActionResult GuardarFactura(FacturacionCLS oFacturaCLS)
        {
            int resultado = _facturaBL.GuardarFactura(oFacturaCLS);
            return Content(resultado.ToString());
        }

        public JsonResult RecuperarFactura(int id)
        {
            FacturacionCLS factura = _facturaBL.RecuperarFactura(id);
            return Json(factura);
        }

        public IActionResult EliminarFactura(int id)
        {
            int resultado = _facturaBL.EliminarFactura(id);
            return Content(resultado.ToString());
        }
    }
}
