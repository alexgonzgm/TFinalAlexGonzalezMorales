using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAlexGonzalezMorales.Models
{
    public class AlumnoAsignatura
    {
        public int IdAlumno { get; set; }
        public int IdAsignatura { get; set; }
        public int Convocatorias { get; set; }
        public int Nota { get; set; }
        public bool AsignaturaNula { get; set; }


    }
}
