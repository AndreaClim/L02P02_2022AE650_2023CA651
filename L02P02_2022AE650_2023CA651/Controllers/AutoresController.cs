using System.Linq;
using L02P02_2022AE650_2023CA651.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022AE650_2023CA651.Controllers
{
    public class AutoresController : Controller
    {
        private readonly libreriaDbContext _context;

        public AutoresController(libreriaDbContext context)
        {
            _context = context;
        }

        public IActionResult Prototipo01()
        {
            var listaAutores = _context.autores.ToList();
            return View(listaAutores);
        }


    }
}
