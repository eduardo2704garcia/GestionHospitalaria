using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class PacientesBL
    {
        private readonly PacientesDAL _pacientesDAL;

        // Inyección de dependencias a través del constructor
        public PacientesBL(PacientesDAL pacientesDAL)
        {
            _pacientesDAL = pacientesDAL;
        }

        public int GuardarPaciente(PacientesCLS oPacienteCLS)
        {
            return _pacientesDAL.GuardarPacientes(oPacienteCLS);
        }

        public List<PacientesCLS> listarPacientes()
        {
            return _pacientesDAL.listarPacientes();
        }

        public List<PacientesCLS> filtrarPacientes(PacientesCLS objPaciente)
        {
            return _pacientesDAL.filtrarPacientes(objPaciente);
        }
    }
}
