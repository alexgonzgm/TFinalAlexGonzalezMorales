using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinalAlexGonzalezMorales.Models;

namespace ProyectoFinalAlexGonzalezMorales.Models
{
    public class Asignatura
    {
        public int Id { get; set; }
        public int Creditos { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Profesor Profesor { get; set; }
        public Curso Curso { get; set; }
        public bool Obligatoria { get; set; }
        public int Precio { get; set; }
    }
}
