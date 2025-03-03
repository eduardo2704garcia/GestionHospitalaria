using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TratamientosCLS
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }
        public int PacienteId { get; set; }
        [NotMapped]
        public string NombrePaciente { get; set; }
    }

}
