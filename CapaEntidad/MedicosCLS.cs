using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MedicosCLS
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int EspecialidadId { get; set; }
        [NotMapped]
        public string NombreEspecialidad { get; set; }
    }
}
