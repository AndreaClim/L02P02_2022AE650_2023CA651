﻿using System.ComponentModel.DataAnnotations;

namespace L02P02_2022AE650_2023CA651.Models
{
    public class autores
    {
        [Key]
        public int id { get; set; }
        public string? autor { get; set; }
    }
}
