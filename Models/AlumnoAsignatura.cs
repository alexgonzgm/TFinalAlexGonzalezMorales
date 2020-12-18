using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAlexGonzalezMorales.Models
{
    public class AlumnoAsignatura
    {
        public int AlumnoAsignaturaId { get; set; }
        public int IdAlumno { get; set; }
        public Alumno Alumno { get; set; }
       
        public int IdAsignatura { get; set; } 
        public Asignatura Asignatura { get; set; }
        public int Convocatorias { get; set; }
        public int Nota { get; set; }
        public bool AsignaturaNula { get; set; }


    }
}
