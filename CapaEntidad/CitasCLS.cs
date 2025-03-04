using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CitasCLS
    {
        [Key]
        public int Id { get; set; }                // Debe llamarse "Id"
        public int PacienteId { get; set; }          // Debe llamarse "PacienteId"
        [NotMapped]
        public string NombrePaciente { get; set; }   // Solo para mostrar en listados
        public int MedicoId { get; set; }            // Debe llamarse "MedicoId"
        [NotMapped]
        public string NombreMedico { get; set; }       // Solo para listados
        public DateTime FechaHora { get; set; }        // Debe llamarse "FechaHora"
        public string Estado { get; set; }           // Debe llamarse "Estado"

    }
}
