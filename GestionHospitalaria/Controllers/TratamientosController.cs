using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapaPresentacion.Controllers
{
    public class TratamientosController : Controller
    {
        // GET: TratamientosController
        public ActionResult Index()
        {
            return View();
        }
    }
}
