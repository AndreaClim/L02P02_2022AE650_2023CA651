using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L02P02_2022AE650_2023CA651.Models;

public class libreriaDbContext : DbContext
{
    public libreriaDbContext(DbContextOptions<libreriaDbContext> options) : base(options)
    {
    }
    public DbSet<marcas> marcas { get; set; }
    public DbSet<equipos> equipos { get; set; }
    public DbSet<usuarios> usuarios { get; set; }

}

