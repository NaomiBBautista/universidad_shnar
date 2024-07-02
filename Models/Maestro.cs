using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHNAR.Models
{
    public class Maestro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [Column("Nombre")]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [Required]
        [Column("Correo")]
        [Display(Name = "Correo")]
        [StringLength(50)]
        public string Correo { get; set; }

        public string CoordinacionNombre { get; set; }


        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get { return Apellido + ", " + Nombre; }
        }

        public Coordinacion Coordinacion { get; set; }
        public Edificio Edificio {get; set;}
    }
}