using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHNAR.Models
{

    public class Edificio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicio")]
        public DateTime? InicioFecha { get; set; }

        public string MaestroNombre {get; set;}
        public ICollection<Maestro> Maestros { get; set; }
    }
}