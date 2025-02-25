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
