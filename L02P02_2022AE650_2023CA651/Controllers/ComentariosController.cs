using L02P02_2022AE650_2023CA651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L02P02_2022AE650_2023CA651.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly libreriaDbContext _context;

        public ComentariosController(libreriaDbContext context)
        {
            _context = context;
        }

        // Mostrar los comentarios del libro
        public IActionResult Prototipo03(int id_libro)
        {
            // Obtener los comentarios asociados al libro
            var comentarios = _context.comentarios_libros
                .Where(c => c.id_libro == id_libro)
                .ToList();

            // Obtener información del libro y su autor
            var libro = _context.libros
             
                .FirstOrDefault(l => l.id == id_libro);

            if (libro == null)
            {
                return NotFound();
            }

            ViewData["LibroNombre"] = libro?.nombre;

            return View(comentarios);
        }


        // Agregar un comentario
        [HttpPost]
        public IActionResult AgregarComentario(string comentarios, int id_libro)
        {
            if (!string.IsNullOrEmpty(comentarios))
            {
                // Verificar si el libro existe
                var libro = _context.libros.FirstOrDefault(l => l.id == id_libro);
                if (libro == null)
                {
                    return NotFound();
                }

                // Crear nuevo comentario
                var nuevoComentario = new comentarios_libros
                {
                    id_libro = id_libro,
                    comentarios = comentarios,
                    created_at = DateTime.Now,
                };

                // Agregar comentario a la base de datos
                _context.comentarios_libros.Add(nuevoComentario);
                _context.SaveChanges();
            }

            // Redirigir al Prototipo04 para la confirmación
            return RedirectToAction("Prototipo04", new { id_libro = id_libro });
        }



        // Mostrar el último comentario agregado
        public IActionResult Prototipo04(int id_libro)
        {
            // Obtener el último comentario agregado para el libro
            var ultimoComentario = _context.comentarios_libros
                .Where(c => c.id_libro == id_libro)
                .OrderByDescending(c => c.created_at)
                .FirstOrDefault();

            var libro = _context.libros
                .FirstOrDefault(l => l.id == id_libro);

            if (libro == null || ultimoComentario == null)
            {
                return NotFound();
            }

            // Mostrar el nombre del libro, comentario y fecha
            ViewData["LibroNombre"] = libro?.nombre;
            ViewData["Comentario"] = ultimoComentario?.comentarios;
            ViewData["FechaComentario"] = ultimoComentario?.created_at.ToString("dd/MM/yyyy HH:mm");

            // Mensaje de confirmación
            ViewData["Mensaje"] = "Comentario agregado exitosamente.";

            return View();
        }


    }
}
