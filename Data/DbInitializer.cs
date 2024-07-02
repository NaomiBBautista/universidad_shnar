using System.Data;
using SHNAR.Models;

namespace SHNAR.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for any alumnos.
            if (context.Alumnos.Any())
            {
                return;   // DB has been seeded
            }

            var alumnos = new Alumno[]
            {
                new Alumno { ID = 78365, Nombre = "Javier", Apellido = "Mejia", InscripcionFecha = DateTime.Parse("2021-07-06") },
                new Alumno { ID = 77561, Nombre="Ana", Apellido="González", InscripcionFecha=DateTime.Parse("2020-08-15")},
                new Alumno { ID = 78242, Nombre="Juan", Apellido="Martínez", InscripcionFecha=DateTime.Parse("2019-09-01")},
                new Alumno { ID = 79543, Nombre="María", Apellido="López", InscripcionFecha=DateTime.Parse("2018-10-20")},
                new Alumno { ID = 73514, Nombre="Carlos", Apellido="Sánchez", InscripcionFecha=DateTime.Parse("2019-07-05")},
                new Alumno { ID = 72315, Nombre="Isabel", Apellido="Hernández", InscripcionFecha=DateTime.Parse("2020-01-12")},
                new Alumno { ID = 76556, Nombre="Pedro", Apellido="Díaz", InscripcionFecha=DateTime.Parse("2018-11-30")},
                new Alumno { ID = 74777, Nombre="Laura", Apellido="Ramírez", InscripcionFecha=DateTime.Parse("2019-03-25")},
                new Alumno { ID = 78991, Nombre="Ricardo", Apellido="Pérez", InscripcionFecha=DateTime.Parse("2020-02-18")},
                new Alumno { ID = 73015, Nombre = "Ana", Apellido = "Gomez", InscripcionFecha = DateTime.Parse("2021-08-15") },
                new Alumno { ID = 76304, Nombre = "Carlos", Apellido = "Rodriguez", InscripcionFecha = DateTime.Parse("2021-09-22") },
                new Alumno { ID = 73042, Nombre = "Laura", Apellido = "Perez", InscripcionFecha = DateTime.Parse("2021-10-10") },
                new Alumno { ID = 71024, Nombre = "Roberto", Apellido = "Lopez", InscripcionFecha = DateTime.Parse("2021-11-28") }

            };

            context.Alumnos.AddRange(alumnos);
            context.SaveChanges();

            var coordinaciones = new Coordinacion[]
            {
                new Coordinacion { ID = 1, Nombre = "Miguel Gómez", InicioFecha = DateTime.Parse("2002-05-30") },
                new Coordinacion { ID = 2, Nombre = "Ana Rodriguez", InicioFecha = DateTime.Parse("2005-10-15") },
                new Coordinacion { ID = 3, Nombre = "Carlos Pérez", InicioFecha = DateTime.Parse("2008-03-22") },
                new Coordinacion { ID = 4, Nombre = "Laura Martínez", InicioFecha = DateTime.Parse("2011-08-10") },
                new Coordinacion { ID = 5, Nombre = "Roberto López", InicioFecha = DateTime.Parse("2014-12-28") }
        };

            context.Coordinaciones.AddRange(coordinaciones);
            context.SaveChanges();

            var edificios = new Edificio[]
            {
                new Edificio { ID = 1, Nombre = "Lenguas", InicioFecha = DateTime.Parse("1980-07-35"), MaestroNombre = "Manuel Hernández"},
                new Edificio { ID = 2, Nombre = "Ciencias", InicioFecha = DateTime.Parse("1985-12-15"), MaestroNombre = "María González" },
                new Edificio { ID = 3, Nombre = "Artes", InicioFecha = DateTime.Parse("1990-03-22"), MaestroNombre = "Carlos Rodríguez" },
                new Edificio { ID = 4, Nombre = "Matemáticas", InicioFecha = DateTime.Parse("1995-08-10"), MaestroNombre = "Manuel Hernández" },
                new Edificio { ID = 5, Nombre = "Historia", InicioFecha = DateTime.Parse("2000-12-28"), MaestroNombre = "Roberto López" }
            };


            context.Edificios.AddRange(edificios);
            context.SaveChanges();

            var inscripciones = new Inscripcion[]
            {
                new Inscripcion { ID = 1, AlumnoNombre = "Javier Mejia", MateriaNombre = "Física Cuántica"},
                new Inscripcion { ID = 2, AlumnoNombre = "María López", MateriaNombre = "Biología Avanzada" },
                new Inscripcion { ID = 3, AlumnoNombre = "Pedro Díaz", MateriaNombre = "Matemáticas Aplicadas" },
                new Inscripcion { ID = 4, AlumnoNombre = "Laura Perez", MateriaNombre = "Artes Escenicas" },
                new Inscripcion { ID = 5, AlumnoNombre = "Ricardo Pérez", MateriaNombre = "Historia del Arte" }
            };

            context.Inscripciones.AddRange(inscripciones);
            context.SaveChanges();

            var maestros = new Maestro[]
            {
                new Maestro { ID = 1, Nombre = "Manuel", Apellido = "Hernández", Correo = "manuhernan@correo", CoordinacionNombre = "Miguel Gómez"},
                new Maestro { ID = 2, Nombre = "María", Apellido = "González", Correo = "mariagonz@correo", CoordinacionNombre = "Carlos Pérez"},
                new Maestro { ID = 3, Nombre = "Carlos", Apellido = "Rodríguez", Correo = "carlorod@correo", CoordinacionNombre = "Ana Rodriguez"},
                new Maestro { ID = 4, Nombre = "Laura", Apellido = "Pérez", Correo = "laurapere@correo", CoordinacionNombre = "Laura Martínez"},
                new Maestro { ID = 5, Nombre = "Roberto", Apellido = "López", Correo = "roberlope@correo", CoordinacionNombre = "Roberto López" }
            };

            context.Maestros.AddRange(maestros);
            context.SaveChanges();

            var materias = new Materia[]
            {
                new Materia { ID = 1, Nombre = "Artes Escenicas", Creditos = 10, MaestroNombre = "Carlos Rodríguez", InscripcionFecha = DateTime.Parse("2021-07-06")},
                new Materia { ID = 2, Nombre = "Biología Avanzada", Creditos = 15, MaestroNombre = "Laura Pérez", InscripcionFecha = DateTime.Parse("2014-12-28")},
                new Materia { ID = 3, Nombre = "Matemáticas Aplicadas", Creditos = 15, MaestroNombre = "María González" , InscripcionFecha = DateTime.Parse("2019-03-25")},
                new Materia { ID = 4, Nombre = "Historia del Arte", Creditos = 10, MaestroNombre = "Roberto López", InscripcionFecha = DateTime.Parse("2000-12-28") },
                new Materia { ID = 5, Nombre = "Italiano", Creditos = 15, MaestroNombre = "Manuel Hernández", InscripcionFecha = DateTime.Parse("2006-11-14") }
            };

            context.Materias.AddRange(materias);
            context.SaveChanges();

        }
    }
}