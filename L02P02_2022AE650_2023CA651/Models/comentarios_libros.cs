using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace L02P02_2022AE650_2023CA651.Models
{
    public class comentarios_libros
    {
        [Key]
        public int id { get; set; }
        public int? id_libro { get; set; }
        public string? comentarios { get; set; }
        public string? usuario { get; set; }
        public DateTime created_at { get; set; }
    }
}
