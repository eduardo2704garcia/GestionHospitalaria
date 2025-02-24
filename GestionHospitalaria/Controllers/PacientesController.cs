using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class PacientesController : Controller
    {
        // GET: PacientesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public class PacienteController
        {
            public List<PacientesCLS> listarPacientes()
            {
                PacientesDAL obj = new PacientesDAL();
                return obj.listarPacientes();
            }

            public List<PacientesCLS> filtrarPacientes(PacientesCLS objPaciente)
            {
                PacientesDAL obj = new PacientesDAL();
                return obj.filtrarPacientes(objPaciente);
            }

            public int GuardarPaciente(PacientesCLS oPacienteCLS)
            {
                PacientesBL obj = new PacientesBL();
                return obj.GuardarPaciente(oPacienteCLS);
            }
        }
}
