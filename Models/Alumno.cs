using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHNAR.Models
{
    public class Alumno
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("Nombre")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inscripción")]
        public DateTime? InscripcionFecha { get; set; }
        
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto
        {
            get
            {
                return Apellido + ", " + Nombre;
            }
        }

        public ICollection<Inscripcion> Inscripciones { get; set; }
    }

}