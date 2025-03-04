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
        public int Id { get; set; }                
        public int PacienteId { get; set; }          
        [NotMapped]
        public string NombrePaciente { get; set; }   
        public int MedicoId { get; set; }           
        [NotMapped]
        public string NombreMedico { get; set; }       
        public DateTime FechaHora { get; set; }        
        public string Estado { get; set; }           

    }
}
