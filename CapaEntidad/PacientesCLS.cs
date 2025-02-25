using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    [Table("Pacientes")]
    public class PacientesCLS
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string apellido { get; set; }

        [Required]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        [MaxLength(16)]
        public string telefono { get; set; }

        [Required]
        [MaxLength(100)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string direccion { get; set; }
    }
}
