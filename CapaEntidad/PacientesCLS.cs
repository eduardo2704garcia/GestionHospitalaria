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
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(16)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; }
    }
}
