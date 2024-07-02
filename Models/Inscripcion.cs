using System.ComponentModel.DataAnnotations;

namespace SHNAR.Models
{

    using System.ComponentModel.DataAnnotations;
    public class Inscripcion
    {
        public int ID { get; set; }
        public string AlumnoNombre { get; set; }
        public string MateriaNombre { get; set; }

        public ICollection<Materia> Materias {get; set;}
        public Alumno Alumno { get; set; }
    }
}