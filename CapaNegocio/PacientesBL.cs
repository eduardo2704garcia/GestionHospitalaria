using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class PacientesBL
    {
        public int GuardarPaciente(PacientesCLS oPacienteCLS)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.GuardarPacientes(oPacienteCLS);
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

    }
}
