using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PacientesCLS
    {
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion {  get; set; }

    }
}
