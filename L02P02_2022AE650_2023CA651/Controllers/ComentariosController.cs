using L02P02_2022AE650_2023CA651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2022AE650_2023CA651.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly libreriaDbContext _context;

        public ComentariosController(libreriaDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Prototipo03(int id_libro)
        {
            var comentarios = _context.comentarios_libros
                .Where(c => c.id_libro == id_libro)
                .OrderByDescending(c => c.created_at)
                .ToList();

            var libro = _context.libros.FirstOrDefault(l => l.id == id_libro);
            if (libro == null) return NotFound();

            ViewData["LibroNombre"] = libro.nombre;
            ViewData["id_libro"] = id_libro;

            return View(comentarios);
        }
        [HttpPost]
        public IActionResult AgregarComentario(string comentarios, int id_libro)
        {
            if (string.IsNullOrWhiteSpace(comentarios) || id_libro == 0)
            {
                ModelState.AddModelError("", "Comentario inválido.");
            }
            else
            {
                var nuevoComentario = new comentarios_libros
                {
                    id_libro = id_libro,
                    comentarios = comentarios,
                    usuario = "Anónimo",
                    created_at = DateTime.Now
                };

                _context.comentarios_libros.Add(nuevoComentario);
                _context.SaveChanges();
            }

    
            var comentariosActualizados = _context.comentarios_libros
                .Where(c => c.id_libro == id_libro)
                .OrderByDescending(c => c.created_at)
                .ToList();

            var libro = _context.libros.FirstOrDefault(l => l.id == id_libro);
            ViewData["LibroNombre"] = libro?.nombre;
            ViewData["id_libro"] = id_libro;

            return View("Prototipo03", comentariosActualizados);
        }


    }
}
