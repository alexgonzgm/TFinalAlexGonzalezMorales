using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAlexGonzalezMorales.Models;
using TFinalAlexGonzalezMorales.Models;

namespace TFinalAlexGonzalezMorales.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<AlumnoAsignatura> AlumnosAsignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
