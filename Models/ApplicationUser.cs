using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFinalAlexGonzalezMorales.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser():base()
        {

        }
        public int DNI { get; set; }
        public string Nombre   { get; set; }
        public int Edad { get; set; }
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
      

    }
}
