using L02P02_2022AE650_2023CA651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2022AE650_2023CA651.Controllers
{
    public class librosController : Controller
    {
        private readonly libreriaDbContext _context;

        public librosController(libreriaDbContext context)
        {
            _context = context;
        }

        // Acción que recibe el ID del autor seleccionado desde el Prototipo 01
        public IActionResult Prototipo02(int idAutor)
        {
            // Cargar el nombre del autor seleccionado (opcional, para mostrarlo en la vista)
            var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);
            ViewData["NombreAutor"] = autor?.autor;

            // Obtener todos los libros de ese autor
            var libros = _context.libros
                .Where(l => l.id_autor == idAutor)
                .ToList();

            return View(libros);
        }

        // Acción que se llamará desde el botón Seleccionar libro (para ir al Prototipo 03)
        public IActionResult Prototipo03(int idLibro)
        {
            // Redirige al controlador de comentarios
            return RedirectToAction("ComentariosPorLibro", "Comentarios", new { idLibro = idLibro });
        }
    }
}
