using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFinalAlexGonzalezMorales.Areas.Alumno.Controllers
{
    [Area("Alumno")]
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
