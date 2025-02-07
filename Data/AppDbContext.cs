/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/


//using MiProyecto.Models;

using Microsoft.EntityFrameworkCore;
using MauiApp1.Models;

namespace MauiApp1.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración del contexto.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tablas representadas como DbSet.
        public DbSet<Albaran> Albaranes { get; set; }
        public DbSet<LineaAlbaran> LineasAlbaranes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Repartidor> Repartidores { get; set; }

        // Configuración de las relaciones entre tablas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación uno-a-muchos entre Albarán y Línea.
            modelBuilder.Entity<LineaAlbaran>()
                .HasOne(l => l.Albaran) // Línea pertenece a un Albarán.
                .WithMany(a => a.Lineas) // Un Albarán tiene muchas Líneas.
                .HasForeignKey(l => l.AlbaranId); // Clave foránea.
        }
    }
}