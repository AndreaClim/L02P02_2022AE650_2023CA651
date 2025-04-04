using L02P02_2022AE650_2023CA651.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022AE650_2023CA651.Controllers
{

    public class LibrosController : Controller
    {
        private readonly libreriaDbContext _context;

        public LibrosController(libreriaDbContext context)
        {
            _context = context;
        }
        public IActionResult Prototipo02(int id)
        {
            var libros = _context.libros.Where(l => l.id_autor == id).ToList();

            return View(libros);
        }
    }
}
