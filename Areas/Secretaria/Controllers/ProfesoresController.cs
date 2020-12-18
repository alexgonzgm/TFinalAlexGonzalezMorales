using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFinalAlexGonzalezMorales.Data;
using TFinalAlexGonzalezMorales.Models;
using TFinalAlexGonzalezMorales.Utilities;

namespace TFinalAlexGonzalezMorales.Areas.Secretaria.Controllers
{
    [Area("Secretaria")]
    public class ProfesoresController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public ProfesoresController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
       
        public async Task<IActionResult> Index()
        {
            List<Profesor> lista = new List<Profesor>();
            var profesores = await _userManager.GetUsersInRoleAsync(Roles.Profesor);
            foreach (var profe in profesores)
            {
                Profesor nuevoP = new Profesor();
                nuevoP.Nombre = ((ApplicationUser)profe).Nombre;
                nuevoP.DNI = ((ApplicationUser)profe).DNI.ToString();
                nuevoP.Direccion = ((ApplicationUser)profe).Direccion;
                nuevoP.Edad = ((ApplicationUser)profe).Edad;
                nuevoP.Email = ((ApplicationUser)profe).Email;
                lista.Add(nuevoP);
            }
            return View(lista);
        }
    }
}