using System;
using System.ComponentModel.DataAnnotations;

namespace SHNAR.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? InscripcionFecha { get; set; }

        public int AlumnoCount { get; set; }
    }
}