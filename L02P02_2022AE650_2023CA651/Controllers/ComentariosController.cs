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

        // +
        public IActionResult Prototipo03(int id_libro)
        {
            
            var comentarios = _context.comentarios_libros
                .Where(c => c.id_libro == id_libro)
                .ToList();

         
            var libro = _context.libros
             
                .FirstOrDefault(l => l.id == id_libro);

            if (libro == null)
            {
                return NotFound();
            }

            ViewData["LibroNombre"] = libro?.nombre;

            return View(comentarios);
        }


        //comentario
        [HttpPost]
        public IActionResult AgregarComentario(string comentarios, int id_libro)
        {
            if (!string.IsNullOrEmpty(comentarios))
            {
              
                var libro = _context.libros.FirstOrDefault(l => l.id == id_libro);
                if (libro == null)
                {
                    return NotFound();
                }

               
                var nuevoComentario = new comentarios_libros
                {
                    id_libro = id_libro,
                    comentarios = comentarios,
                    created_at = DateTime.Now,
                };

           
                _context.comentarios_libros.Add(nuevoComentario);
                _context.SaveChanges();

        
                var comentariosLibro = _context.comentarios_libros
                    .Where(c => c.id_libro == id_libro)
                    .ToList();

                var libroInfo = _context.libros.FirstOrDefault(l => l.id == id_libro);
                if (libroInfo == null)
                {
                    return NotFound();
                }

                ViewData["LibroNombre"] = libroInfo?.nombre;

               
                return View("Prototipo03", comentariosLibro);
            }

            return RedirectToAction("Prototipo03", new { id_libro = id_libro });
        }






        public IActionResult Prototipo04(int id_libro)
        {
            // Obtener el último comentario agregado para el libro por su ID
            var ultimoComentario = _context.comentarios_libros
                .FirstOrDefault(c => c.id == id_libro);

            if (ultimoComentario == null)
            {
                return NotFound();
            }

            // Obtener el libro asociado con el comentario
            var libro = _context.libros
                .FirstOrDefault(l => l.id == ultimoComentario.id_libro);

            if (libro == null)
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
