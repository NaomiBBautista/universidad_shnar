using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHNAR.Models
{
    public class Materia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Número")]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Range(0, 30)]
        public int Creditos { get; set; }

        public string MaestroNombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inscripción")]
        public DateTime? InscripcionFecha { get; set; }

        public ICollection<Maestro> Maestros {get; set;}
        public ICollection<Inscripcion> Inscripciones { get; set; }
    }
}