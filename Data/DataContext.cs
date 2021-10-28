using Microsoft.EntityFrameworkCore;
using ProgettoRistorazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoRistorazione.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ristorante> Ristoranti { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Menu>().HasKey(m => new { m.RistoranteId, m.PiattoId });
            mb.Entity<Procedimento>().HasKey(p => new { p.PiattoId, p.IngredienteId });
            mb.Entity<Preavviso>().HasKey(p => new { p.PiattoId, p.AllergeneId });
        }

        public DbSet<Ingrediente> Ingredienti { get; set; }
        public DbSet<Allergene> Allergeni { get; set; }
        public DbSet<Procedimento> Procedimenti { get; set; }
        public DbSet<Preavviso> Preavvisi { get; set; }
        

    }
}
