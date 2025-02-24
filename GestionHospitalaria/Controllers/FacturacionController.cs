using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class FacturacionController : Controller
    {
        // GET: FacturacionController
        public ActionResult Index()
        {
            return View();
        }
    }
}
