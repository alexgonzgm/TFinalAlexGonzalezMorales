using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAlexGonzalezMorales.Models
{
    public class Alumno
    {
        [Key]
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        [Display(Description = "Dirección")]
        public string Direccion { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
