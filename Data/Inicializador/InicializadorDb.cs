using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinalAlexGonzalezMorales.Models;
using TFinalAlexGonzalezMorales.Utilities;

namespace TFinalAlexGonzalezMorales.Data.Inicializador
{
    public class InicializadorDb : IInicializadorDb
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorDb(ApplicationDbContext db , UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
           
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public void Inicializar()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

             
            }
            if (_db.Roles.Any(ro => ro.Name == Roles.Secretaria)) return;
            _roleManager.CreateAsync(new IdentityRole(Roles.Secretaria)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.Profesor)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.Alumno)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser()
            {
                UserName = "secretaria@gmail.com",
                Email = "secretaria@gmail.com",
                EmailConfirmed = true ,
               
                
               
            },"Secre1$").GetAwaiter().GetResult();
            ApplicationUser usuario = _db.ApplicationUser
                .Where(us => us.Email == "secretaria@gmail.com")
                .FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, Roles.Secretaria).GetAwaiter().GetResult();
        }
    }
}
