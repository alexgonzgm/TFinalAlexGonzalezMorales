using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TFinalAlexGonzalezMorales.Areas.Secretaria.Controllers
{
    [Area("Secretaria")]
    public class ProfesoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}