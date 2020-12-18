using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFinalAlexGonzalezMorales.Data.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCurso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    DNI = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.DNI);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    DNI = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GrupoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.DNI);
                    table.ForeignKey(
                        name: "FK_Alumnos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creditos = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    ProfesorDNI = table.Column<string>(nullable: true),
                    CursoId = table.Column<int>(nullable: true),
                    Obligatoria = table.Column<bool>(nullable: false),
                    Precio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignatura_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asignatura_Profesores_ProfesorDNI",
                        column: x => x.ProfesorDNI,
                        principalTable: "Profesores",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnosAsignaturas",
                columns: table => new
                {
                    AlumnoAsignaturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlumno = table.Column<int>(nullable: false),
                    AlumnoDNI = table.Column<string>(nullable: true),
                    IdAsignatura = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: true),
                    Convocatorias = table.Column<int>(nullable: false),
                    Nota = table.Column<int>(nullable: false),
                    AsignaturaNula = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosAsignaturas", x => x.AlumnoAsignaturaId);
                    table.ForeignKey(
                        name: "FK_AlumnosAsignaturas_Alumnos_AlumnoDNI",
                        column: x => x.AlumnoDNI,
                        principalTable: "Alumnos",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlumnosAsignaturas_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    MatriculaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(nullable: false),
                    AlumnoDNI = table.Column<string>(nullable: true),
                    AsignaturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.MatriculaId);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alumnos_AlumnoDNI",
                        column: x => x.AlumnoDNI,
                        principalTable: "Alumnos",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_GrupoId",
                table: "Alumnos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosAsignaturas_AlumnoDNI",
                table: "AlumnosAsignaturas",
                column: "AlumnoDNI");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnosAsignaturas_AsignaturaId",
                table: "AlumnosAsignaturas",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_CursoId",
                table: "Asignatura",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_ProfesorDNI",
                table: "Asignatura",
                column: "ProfesorDNI");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlumnoDNI",
                table: "Matriculas",
                column: "AlumnoDNI");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AsignaturaId",
                table: "Matriculas",
                column: "AsignaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnosAsignaturas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");
        }
    }
}
