using EdunovaWP1.Models;
using Microsoft.EntityFrameworkCore;

namespace EdunovaWP1.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> opcije) 
            : base(opcije) {
            
        }
        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<Oglas> Oglas { get; set; }
        public DbSet<Upit> Upit { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vozilo>().HasOne(os => os.Osoba);
            modelBuilder.Entity<Oglas>().HasOne(os => os.Osoba);
            modelBuilder.Entity<Upit>().HasOne(os => os.Osoba);
            modelBuilder.Entity<Upit>().HasOne(og => og.Oglas);
            
                
                
                
        }
    }
}
