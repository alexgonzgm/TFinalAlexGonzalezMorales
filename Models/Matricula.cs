using ProyectoFinalAlexGonzalezMorales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFinalAlexGonzalezMorales.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }
    }
}
