using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHNAR.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InscripcionFecha = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coordinacion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    InicioFecha = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinacion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Edificio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    InicioFecha = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MaestroNombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Maestro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Creditos = table.Column<int>(type: "INTEGER", nullable: false),
                    MaestroNombre = table.Column<string>(type: "TEXT", nullable: true),
                    InscripcionFecha = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlumnoNombre = table.Column<string>(type: "TEXT", nullable: true),
                    MateriaNombre = table.Column<string>(type: "TEXT", nullable: true),
                    AlumnoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Alumno_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumno",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CoordinacionNombre = table.Column<string>(type: "TEXT", nullable: true),
                    CoordinacionID = table.Column<int>(type: "INTEGER", nullable: true),
                    EdificioID = table.Column<int>(type: "INTEGER", nullable: true),
                    MateriaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Maestros_Coordinacion_CoordinacionID",
                        column: x => x.CoordinacionID,
                        principalTable: "Coordinacion",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Maestros_Edificio_EdificioID",
                        column: x => x.EdificioID,
                        principalTable: "Edificio",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Maestros_Maestro_MateriaID",
                        column: x => x.MateriaID,
                        principalTable: "Maestro",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InscripcionMateria",
                columns: table => new
                {
                    InscripcionesID = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriasID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionMateria", x => new { x.InscripcionesID, x.MateriasID });
                    table.ForeignKey(
                        name: "FK_InscripcionMateria_Inscripcion_InscripcionesID",
                        column: x => x.InscripcionesID,
                        principalTable: "Inscripcion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscripcionMateria_Maestro_MateriasID",
                        column: x => x.MateriasID,
                        principalTable: "Maestro",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_AlumnoID",
                table: "Inscripcion",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionMateria_MateriasID",
                table: "InscripcionMateria",
                column: "MateriasID");

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_CoordinacionID",
                table: "Maestros",
                column: "CoordinacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_EdificioID",
                table: "Maestros",
                column: "EdificioID");

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_MateriaID",
                table: "Maestros",
                column: "MateriaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscripcionMateria");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Coordinacion");

            migrationBuilder.DropTable(
                name: "Edificio");

            migrationBuilder.DropTable(
                name: "Maestro");

            migrationBuilder.DropTable(
                name: "Alumno");
        }
    }
}
