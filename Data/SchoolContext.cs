using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHNAR.Models;

namespace SHNAR.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Coordinacion> Coordinaciones { get; set; }

        public DbSet<Edificio> Edificios { get; set; }

        public DbSet<Inscripcion> Inscripciones { get; set; }

        public DbSet<Maestro> Maestros { get; set; }

        public DbSet<Materia> Materias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Alumno>().ToTable(nameof(Alumno));

            modelBuilder.Entity<Coordinacion>().ToTable(nameof(Coordinacion));

            modelBuilder.Entity<Edificio>().ToTable(nameof(Edificio));

            modelBuilder.Entity<Inscripcion>().ToTable(nameof(Inscripcion));

            modelBuilder.Entity<Materia>().ToTable(nameof(Materia));

            modelBuilder.Entity<Materia>().ToTable(nameof(Maestro));

            // Puedes especificar el nombre de la tabla de unión aquí

        }

    }
}
