using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class MedicosController : Controller
    {
        // GET: MedicosController
        public ActionResult Index()
        {
            return View();
        }
    }
}
